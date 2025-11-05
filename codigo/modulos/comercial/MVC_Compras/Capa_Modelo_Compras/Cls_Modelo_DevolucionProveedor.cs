using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Compras
{
    public class Cls_Modelo_DevolucionProveedor
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        // ==================== 1. Obtener Proveedores ====================
        public DataTable ObtenerProveedores()
        {
            DataTable tabla = new DataTable();
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = "SELECT Cmp_Id_Proveedor, Cmp_Nombre_Proveedor FROM Tbl_Proveedor ORDER BY Cmp_Nombre_Proveedor;";
                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(tabla);
            }
            return tabla;
        }

        // ==================== 2. Obtener Facturas por Proveedor ====================
        public DataTable ObtenerFacturasPorProveedor(int idProveedor)
        {
            DataTable tabla = new DataTable();
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"SELECT Cmp_Id_Factura_Proveedor, Cmp_Numero_Factura 
                                 FROM Tbl_Factura_Proveedor 
                                 WHERE Cmp_Id_Proveedor = ?;";
                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", idProveedor);

                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(tabla);
            }
            return tabla;
        }

        // ==================== 3. Guardar Devolución (encabezado) ====================
        public int GuardarDevolucion(int idProveedor, int idFactura, string tipo, DateTime fecha, string motivo, decimal monto, int idUsuario)
        {
            int idDevolucion = 0;
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"
                INSERT INTO Tbl_Devolucion_Proveedor 
                (Cmp_Id_Proveedor, Cmp_Id_Factura_Proveedor, Cmp_Tipo_Devolucion, Cmp_Fecha_Devolucion, 
                 Cmp_Motivo, Cmp_Monto_Devuelto, Cmp_Id_Usuario)
                VALUES (?,?,?,?,?,?,?);";

                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.Add("@prov", OdbcType.Int).Value = idProveedor;
                cmd.Parameters.Add("@fact", OdbcType.Int).Value = idFactura;
                cmd.Parameters.Add("@tipo", OdbcType.VarChar).Value = tipo;
                cmd.Parameters.Add("@fecha", OdbcType.Date).Value = fecha;
                cmd.Parameters.Add("@motivo", OdbcType.VarChar).Value = motivo;
                cmd.Parameters.Add("@monto", OdbcType.Double).Value = Convert.ToDouble(monto);
                cmd.Parameters.Add("@user", OdbcType.Int).Value = idUsuario;

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT LAST_INSERT_ID();";
                idDevolucion = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return idDevolucion;
        }

        // ==================== 4. Guardar Detalle y actualizar inventario ====================
        public void GuardarDetalleYActualizarInventario(int idDevolucion, int idProducto, decimal cantidad, decimal precioUnitario)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                // 1️⃣ Insertar detalle
                string queryDet = @"
                    INSERT INTO Tbl_Devolucion_Proveedor_Det
                    (Cmp_Id_Devolucion_Proveedor, Cmp_Id_Producto, Cmp_Cantidad_Devuelta, Cmp_Precio_Unitario)
                    VALUES (?,?,?,?);";

                OdbcCommand cmd = new OdbcCommand(queryDet, conn);
                cmd.Parameters.AddWithValue("?", idDevolucion);
                cmd.Parameters.AddWithValue("?", idProducto);
                cmd.Parameters.AddWithValue("?", cantidad);
                cmd.Parameters.AddWithValue("?", precioUnitario);
                cmd.ExecuteNonQuery();

                // 2️⃣ Actualizar inventario (restar existencia)
                string queryUpd = @"
                    UPDATE Tbl_Existencia
                    SET Cmp_Cantidad = Cmp_Cantidad - ?
                    WHERE Cmp_Id_Producto = ?;";

                OdbcCommand cmdUpd = new OdbcCommand(queryUpd, conn);
                cmdUpd.Parameters.AddWithValue("?", cantidad);
                cmdUpd.Parameters.AddWithValue("?", idProducto);
                cmdUpd.ExecuteNonQuery();
            }
        }

        // ==================== 5. Obtener productos de factura ====================
        public DataTable ObtenerProductosDeFactura(int idFactura)
        {
            DataTable tabla = new DataTable();
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"
                SELECT 
                    d.Cmp_Id_Producto AS ID,
                    p.Cmp_Nombre_Producto AS Producto,
                    d.Cmp_Cantidad AS Cantidad,
                    d.Cmp_Precio_Unitario AS Precio_Unitario,
                    d.Cmp_Total_Linea AS Subtotal
                FROM Tbl_Factura_Proveedor_Det d
                INNER JOIN Tbl_Producto p ON d.Cmp_Id_Producto = p.Cmp_Id_Producto
                WHERE d.Cmp_Id_Factura_Proveedor = ?;";

                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", idFactura);
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(tabla);
            }
            return tabla;
        }
    }
}

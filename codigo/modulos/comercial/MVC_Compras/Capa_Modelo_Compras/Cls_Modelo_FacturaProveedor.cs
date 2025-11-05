using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Compras
{
   public class Cls_Modelo_FacturaProveedor
    {
        private Cls_Conexion conexion = new Cls_Conexion();

        // ==================== 1. OBTENER PROVEEDORES ====================
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

        // ==================== 2. OBTENER ORDENES DE COMPRA ====================
        public DataTable ObtenerOrdenesCompra()
        {
            DataTable tabla = new DataTable();
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = "SELECT Cmp_Id_OC, CONCAT('OC-', Cmp_Id_OC) AS Numero_OC FROM Tbl_OC ORDER BY Cmp_Id_OC DESC;";
                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(tabla);
            }
            return tabla;
        }

        // ==================== 3. OBTENER PRODUCTOS POR ORDEN ====================
        public DataTable ObtenerProductosPorOrden(int idOrden)
        {
            DataTable tabla = new DataTable();
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"
            SELECT 
                p.Cmp_Id_Producto AS ID,
                CONCAT(p.Cmp_Nombre_Producto, ' (', c.Cmp_Nombre_Categoria, ')') AS Producto,
                d.Cmp_Cantidad AS Cantidad,
                d.Cmp_Precio_Unitario AS Precio_Unitario,
                (d.Cmp_Cantidad * d.Cmp_Precio_Unitario) AS Subtotal
            FROM Tbl_OC_Det d
            INNER JOIN Tbl_Producto p ON d.Cmp_Id_Producto = p.Cmp_Id_Producto
            INNER JOIN Tbl_Categoria_Producto c ON p.Cmp_Id_Categoria_Producto = c.Cmp_Id_Categoria_Producto
            WHERE d.Cmp_Id_OC = ?;";

                OdbcCommand cmd = new OdbcCommand(query, conn);
                cmd.Parameters.AddWithValue("?", idOrden);

                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(tabla);
            }
            return tabla;
        }

        // ==================== 4. GUARDAR FACTURA ENCABEZADO ====================
        public int GuardarFactura(int idProveedor, DateTime fecha, string numero, decimal total, int idUsuario)
        {
            int idFactura = 0;

            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"
            INSERT INTO Tbl_Factura_Proveedor
            (Cmp_Id_Proveedor, Cmp_Fecha_Factura, Cmp_Numero_Factura, Cmp_Total_Factura, Cmp_Id_Usuario)
            VALUES (?,?,?,?,?);";

                using (OdbcCommand cmd = new OdbcCommand(query, conn))
                {
                    // 🔹 Parámetros en orden exacto
                    cmd.Parameters.Add("@prov", OdbcType.Int).Value = idProveedor;
                    cmd.Parameters.Add("@fecha", OdbcType.Date).Value = fecha; // se envía como tipo Date, no string
                    cmd.Parameters.Add("@num", OdbcType.VarChar).Value = numero;
                    cmd.Parameters.Add("@total", OdbcType.Double).Value = Convert.ToDouble(total);
                    cmd.Parameters.Add("@user", OdbcType.Int).Value = idUsuario;

                    try
                    {
                        int filas = cmd.ExecuteNonQuery();

                        if (filas == 0)
                            throw new Exception("No se insertó ninguna fila.");

                        cmd.CommandText = "SELECT LAST_INSERT_ID();";
                        idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (OdbcException ex)
                    {
                        throw new Exception("Error al insertar la factura en la base de datos: " + ex.Message);
                    }
                }
            }

            return idFactura;
        }

        // ==================== 5. GUARDAR DETALLE FACTURA ====================
        public void GuardarDetalleFactura(int idFactura, int idProducto, decimal cantidad, decimal precioUnit)
        {
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"
            INSERT INTO Tbl_Factura_Proveedor_Det 
            (Cmp_Id_Factura_Proveedor, Cmp_Id_Producto, Cmp_Cantidad, Cmp_Precio_Unitario, Cmp_Total_Linea)
            VALUES (?,?,?,?,?);";

                OdbcCommand cmd = new OdbcCommand(query, conn);

                // 🔹 Parámetros en el orden exacto (sin nombres)
                cmd.Parameters.AddWithValue("?", idFactura);
                cmd.Parameters.AddWithValue("?", idProducto);
                cmd.Parameters.AddWithValue("?", cantidad);
                cmd.Parameters.AddWithValue("?", precioUnit);
                cmd.Parameters.AddWithValue("?", cantidad * precioUnit);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OdbcException ex)
                {
                    throw new Exception("Error al insertar el detalle de factura: " + ex.Message, ex);
                }
            }
        }

        // ==================== 6. OBTENER LISTA DE PRODUCTOS (para el combo del DataGridView) ====================
        public DataTable ObtenerTodosLosProductos()
        {
            DataTable tabla = new DataTable();
            using (OdbcConnection conn = conexion.conexion())
            {
                string query = @"
            SELECT 
                p.Cmp_Id_Producto AS ID,
                CONCAT(p.Cmp_Nombre_Producto, ' (', c.Cmp_Nombre_Categoria, ')') AS Producto
            FROM Tbl_Producto p
            INNER JOIN Tbl_Categoria_Producto c 
                ON p.Cmp_Id_Categoria_Producto = c.Cmp_Id_Categoria_Producto
            ORDER BY p.Cmp_Nombre_Producto;";

                OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                da.Fill(tabla);
            }
            return tabla;
        }
    }
}

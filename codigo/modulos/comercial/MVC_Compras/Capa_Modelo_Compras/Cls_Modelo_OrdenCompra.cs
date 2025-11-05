using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;

namespace Capa_Modelo_Compras
{
    public class Cls_Modelo_OrdenCompra
    {
        private Cls_Conexion conexion;

        public Cls_Modelo_OrdenCompra()
        {
            conexion = new Cls_Conexion();
        }

        // ======== INSERTAR ENCABEZADO ========
        public int InsertarOrdenCompra(int idProveedor, int idCondicionPago, DateTime fecha, string observaciones, decimal total, int idUsuario)
        {
            int idGenerado = 0;

            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = @"INSERT INTO Tbl_OC 
                                    (Cmp_Fecha_OC, Cmp_Id_Proveedor, Cmp_Id_Condicion_Pago, Cmp_Total_OC, Cmp_Observaciones, Cmp_Id_Usuario)
                                     VALUES (?,?,?,?,?,?)";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@proveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@condicion", idCondicionPago);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@obs", observaciones);
                    cmd.Parameters.AddWithValue("@usuario", idUsuario);
                    cmd.ExecuteNonQuery();

                    // Recuperar el último ID insertado
                    OdbcCommand cmdId = new OdbcCommand("SELECT LAST_INSERT_ID()", conn);
                    idGenerado = Convert.ToInt32(cmdId.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar orden de compra: " + ex.Message);
            }

            return idGenerado;
        }

        // ======== INSERTAR DETALLE ========
        public void InsertarDetalleOrden(int idOrden, int idProducto, decimal cantidad, decimal precioUnitario, decimal totalLinea)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = @"INSERT INTO Tbl_OC_Det 
                                    (Cmp_Id_OC, Cmp_Id_Producto, Cmp_Cantidad, Cmp_Precio_Unitario, Cmp_Total_Linea)
                                     VALUES (?,?,?,?,?)";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orden", idOrden);
                    cmd.Parameters.AddWithValue("@producto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precio", precioUnitario);
                    cmd.Parameters.AddWithValue("@total", totalLinea);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar detalle: " + ex.Message);
            }
        }

        // ======== LISTAR PROVEEDORES ========
        public List<KeyValuePair<int, string>> ObtenerProveedores()
        {
            List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = "SELECT Cmp_Id_Proveedor, Cmp_Nombre_Proveedor FROM Tbl_Proveedor";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new KeyValuePair<int, string>(dr.GetInt32(0), dr.GetString(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener proveedores: " + ex.Message);
            }
            return lista;
        }

        // ======== LISTAR CONDICIONES DE PAGO ========
        public List<KeyValuePair<int, string>> ObtenerCondicionesPago()
        {
            List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = "SELECT Cmp_Id_Condicion_Pago, Cmp_Descripcion FROM Tbl_Condicion_Pago";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    OdbcDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new KeyValuePair<int, string>(dr.GetInt32(0), dr.GetString(1)));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener condiciones de pago: " + ex.Message);
            }
            return lista;
        }

        // ======== OBTENER PRODUCTOS (con datos de Inventario) ========
        public List<KeyValuePair<int, string>> ObtenerProductos()
        {
            List<KeyValuePair<int, string>> lista = new List<KeyValuePair<int, string>>();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    // 👇 Trae productos activos desde el submódulo INVENTARIO
                    string query = @"
                SELECT 
                    p.Cmp_Id_Producto,
                    CONCAT(p.Cmp_Nombre_Producto, ' (', c.Cmp_Nombre_Categoria, ')') AS ProductoCompleto
                FROM Tbl_Producto p
                INNER JOIN Tbl_Categoria_Producto c 
                    ON p.Cmp_Id_Categoria_Producto = c.Cmp_Id_Categoria_Producto
                WHERE p.Cmp_Activo = 1
                ORDER BY p.Cmp_Nombre_Producto;";

                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    OdbcDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string nombre = dr.GetString(1);
                        lista.Add(new KeyValuePair<int, string>(id, nombre));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos del inventario: " + ex.Message);
            }
            return lista;
        }

        // ======== OBTENER PRODUCTOS COMPLETOS PARA LA TABLA ========
        public DataTable ObtenerProductosTabla()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = @"
                SELECT 
                    p.Cmp_Id_Producto AS ID,
                    CONCAT(p.Cmp_Nombre_Producto, ' (', c.Cmp_Nombre_Categoria, ')') AS Producto,
                    0 AS Cantidad,
                    0.00 AS Precio_Unitario,
                    0.00 AS Subtotal
                FROM Tbl_Producto p
                INNER JOIN Tbl_Categoria_Producto c 
                    ON p.Cmp_Id_Categoria_Producto = c.Cmp_Id_Categoria_Producto
                WHERE p.Cmp_Activo = 1
                ORDER BY p.Cmp_Nombre_Producto;";

                    OdbcDataAdapter da = new OdbcDataAdapter(query, conn);
                    da.Fill(tabla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos para la tabla: " + ex.Message);
            }
            return tabla;
        }

    }
}

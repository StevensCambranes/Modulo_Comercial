using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Capa_Modelo_Compras
{
    public class Cls_Modelo_Proveedor
    {
        private Cls_Conexion conexion;
        public Cls_Modelo_Proveedor()
        {
            conexion = new Cls_Conexion();
        }

        // ========== INSERTAR ==========
        public void InsertarProveedor(string nombre, string nit, string direccion, string telefono, string correo)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = "INSERT INTO Tbl_Proveedor (Cmp_Nombre_Proveedor, Cmp_NIT_Proveedor, Cmp_Direccion, Cmp_Telefono, Cmp_Correo_Electronico) VALUES (?,?,?,?,?)";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@nit", nit);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar proveedor: " + ex.Message);
            }
        }

        // ========== OBTENER TODOS ==========
        public List<string[]> ObtenerProveedores()
        {
            List<string[]> lista = new List<string[]>();
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = "SELECT Cmp_Id_Proveedor, Cmp_Nombre_Proveedor, Cmp_NIT_Proveedor, Cmp_Direccion, Cmp_Telefono, Cmp_Correo_Electronico FROM Tbl_Proveedor";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    OdbcDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lista.Add(new string[]
                        {
                            dr.GetInt32(0).ToString(),
                            dr.GetString(1),
                            dr.GetString(2),
                            dr.GetString(3),
                            dr.GetString(4),
                            dr.GetString(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener proveedores: " + ex.Message);
            }
            return lista;
        }

        // ========== ACTUALIZAR ==========
        public void ActualizarProveedor(int id, string nombre, string nit, string direccion, string telefono, string correo)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = "UPDATE Tbl_Proveedor SET Cmp_Nombre_Proveedor=?, Cmp_NIT_Proveedor=?, Cmp_Direccion=?, Cmp_Telefono=?, Cmp_Correo_Electronico=? WHERE Cmp_Id_Proveedor=?";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@nit", nit);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar proveedor: " + ex.Message);
            }
        }

        // ========== ELIMINAR ==========
        public void EliminarProveedor(int id)
        {
            try
            {
                using (OdbcConnection conn = conexion.conexion())
                {
                    string query = "DELETE FROM Tbl_Proveedor WHERE Cmp_Id_Proveedor=?";
                    OdbcCommand cmd = new OdbcCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar proveedor: " + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Capa_Modelo_Compras
{
    public class Cls_Conexion
    {
        public OdbcConnection conexion()
        {
            // Conexión ODBC a la base de datos Bd_Comercial
            OdbcConnection conn = new OdbcConnection("Dsn=Bd_hoteleria");
            try
            {
                conn.Open();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("Error al conectar con la base de datos: " + ex.Message);
            }
            return conn;
        }

        public void desconexion(OdbcConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}
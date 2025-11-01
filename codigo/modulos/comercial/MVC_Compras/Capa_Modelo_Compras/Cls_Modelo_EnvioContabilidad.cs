using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Modelo_Compras
{
   public class Cls_Modelo_EnvioContabilidad
    {
        public List<(int Id, string Proveedor, DateTime Fecha, decimal Total, string Estado)> ObtenerPendientes()
        {
            // 🔧 Simulación temporal — luego se reemplaza por consulta SQL
            return new List<(int, string, DateTime, decimal, string)>
            {
                (1, "Distribuidora La Unión", new DateTime(2025, 10, 20), 1250.50m, "Pendiente"),
                (2, "Proveedores del Norte", new DateTime(2025, 10, 22), 875.00m, "Pendiente"),
                (3, "Alimentos Bonanza", new DateTime(2025, 10, 23), 1540.75m, "Pendiente")
            };
        }
    }
}

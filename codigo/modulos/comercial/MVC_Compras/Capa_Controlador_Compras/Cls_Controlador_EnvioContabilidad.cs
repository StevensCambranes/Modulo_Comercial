using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Compras;

namespace Capa_Controlador_Compras
{
    public class Cls_Controlador_EnvioContabilidad
    {
        private Cls_Modelo_EnvioContabilidad _modelo = new Cls_Modelo_EnvioContabilidad();

        public List<(int Id, string Proveedor, DateTime Fecha, decimal Total, string Estado)> ObtenerPendientes()
        {
            // Cuando exista la base de datos, esto vendrá del modelo.
            return _modelo.ObtenerPendientes();
        }

        public async Task EnviarAContabilidadAsync(
            List<(int Id, string Proveedor, DateTime Fecha, decimal Total, string Estado)> seleccionados,
            Action<int> actualizarProgreso)
        {
            int total = seleccionados.Count;
            for (int i = 0; i < total; i++)
            {
                // Simula proceso de envío con retardo
                await Task.Delay(500);

                // Actualiza porcentaje
                int porcentaje = (int)(((i + 1) / (double)total) * 100);
                actualizarProgreso(porcentaje);
            }
        }
    }
}

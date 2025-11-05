using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Modelo_Compras;

namespace Capa_Controlador_Compras
{
    public class Cls_Controlador_DevolucionProveedor
    {
        private Cls_Modelo_DevolucionProveedor modelo = new Cls_Modelo_DevolucionProveedor();

        public DataTable ObtenerProveedores() => modelo.ObtenerProveedores();
        public DataTable ObtenerFacturasPorProveedor(int idProveedor) => modelo.ObtenerFacturasPorProveedor(idProveedor);
        public DataTable ObtenerProductosDeFactura(int idFactura) => modelo.ObtenerProductosDeFactura(idFactura);

        public int GuardarDevolucion(int idProveedor, int idFactura, string tipo, DateTime fecha, string motivo, decimal monto, int idUsuario)
            => modelo.GuardarDevolucion(idProveedor, idFactura, tipo, fecha, motivo, monto, idUsuario);

        public void GuardarDetalleYActualizarInventario(int idDevolucion, int idProducto, decimal cantidad, decimal precioUnitario)
            => modelo.GuardarDetalleYActualizarInventario(idDevolucion, idProducto, cantidad, precioUnitario);
    }
}

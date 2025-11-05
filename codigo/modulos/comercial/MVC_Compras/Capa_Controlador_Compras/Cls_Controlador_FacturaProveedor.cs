using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Modelo_Compras;

namespace Capa_Controlador_Compras
{
   public class Cls_Controlador_FacturaProveedor
    {
        private Cls_Modelo_FacturaProveedor modelo = new Cls_Modelo_FacturaProveedor();

        public DataTable ObtenerProveedores() => modelo.ObtenerProveedores();
        public DataTable ObtenerOrdenesCompra() => modelo.ObtenerOrdenesCompra();
        public DataTable ObtenerProductosPorOrden(int idOrden) => modelo.ObtenerProductosPorOrden(idOrden);

        public DataTable ObtenerTodosLosProductos()
        {
            return modelo.ObtenerTodosLosProductos();
        }

        public int GuardarFactura(int idProveedor, DateTime fecha, string numero, decimal total, int idUsuario)
            => modelo.GuardarFactura(idProveedor, fecha, numero, total, idUsuario);

        public void GuardarDetalleFactura(int idFactura, int idProducto, decimal cantidad, decimal precioUnit)
            => modelo.GuardarDetalleFactura(idFactura, idProducto, cantidad, precioUnit);
    }
}

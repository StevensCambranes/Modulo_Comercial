using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Modelo_Compras;

namespace Capa_Controlador_Compras
{
    public class Cls_Controlador_OrdenCompra
    {
        private Cls_Modelo_OrdenCompra modelo = new Cls_Modelo_OrdenCompra();

        public int GuardarOrdenCompra(int idProveedor, int idCondicionPago, DateTime fecha, string observaciones, decimal total, int idUsuario)
        {
            return modelo.InsertarOrdenCompra(idProveedor, idCondicionPago, fecha, observaciones, total, idUsuario);
        }

        public void GuardarDetalleOrden(int idOrden, int idProducto, decimal cantidad, decimal precio, decimal totalLinea)
        {
            modelo.InsertarDetalleOrden(idOrden, idProducto, cantidad, precio, totalLinea);
        }

        public List<KeyValuePair<int, string>> ObtenerProveedores()
        {
            return modelo.ObtenerProveedores();
        }

        public List<KeyValuePair<int, string>> ObtenerCondicionesPago()
        {
            return modelo.ObtenerCondicionesPago();
        }

        public List<KeyValuePair<int, string>> ObtenerProductos()
        {
            return modelo.ObtenerProductos();
        }

        public DataTable ObtenerProductosTabla()
        {
            return modelo.ObtenerProductosTabla();
        }
    }
}

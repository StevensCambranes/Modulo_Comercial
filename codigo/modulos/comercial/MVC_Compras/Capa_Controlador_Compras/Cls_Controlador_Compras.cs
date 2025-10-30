using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Capa_Controlador_Compras
{
   public class Cls_Controlador_Compras
    {
        private class LineaCompra
        {
            public string IdProducto { get; set; }
            public string NombreProducto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal => Cantidad * PrecioUnitario;
        }

        private BindingList<LineaCompra> _lineas;

        public Cls_Controlador_Compras()
        {
            _lineas = new BindingList<LineaCompra>();
        }

        public (string id, string nombre, int cantidad, decimal precioUnit, decimal subtotal)
            AgregarLinea(string id, string nombre, int cantidad, decimal precioUnit)
        {
            var nueva = new LineaCompra
            {
                IdProducto = id,
                NombreProducto = nombre,
                Cantidad = cantidad,
                PrecioUnitario = precioUnit
            };

            _lineas.Add(nueva);
            return (nueva.IdProducto, nueva.NombreProducto, nueva.Cantidad, nueva.PrecioUnitario, nueva.Subtotal);
        }

        public void QuitarLinea(int index)
        {
            if (index >= 0 && index < _lineas.Count)
                _lineas.RemoveAt(index);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in _lineas)
                total += item.Subtotal;
            return total;
        }

        // =====================================================
        // Obtener productos asociados a una orden de compra
        // =====================================================
        public List<(string id, string nombre, int cantidad, decimal precio)>
            ObtenerProductosPorOrden(string idOrden)
        {
            // 🔸 Simulación temporal de datos (luego se conecta a la BD)
            var lista = new List<(string, string, int, decimal)>();

            if (idOrden == "OC001")
            {
                lista.Add(("P001", "Café molido 500g", 10, 30.50m));
                lista.Add(("P002", "Azúcar 25kg", 2, 200.00m));
            }
            else if (idOrden == "OC002")
            {
                lista.Add(("P010", "Leche entera 1L", 15, 12.75m));
                lista.Add(("P011", "Chocolate polvo 1kg", 5, 45.00m));
            }
            else
            {
                // En caso de no encontrar productos
                lista.Add(("—", "Sin productos", 0, 0.00m));
            }

            return lista;
        }

        // =====================================================
        // Obtener monto total de una factura del proveedor
        // =====================================================
        public decimal ObtenerTotalFactura(string idFactura)
        {
            // Simulación temporal de montos por factura
            switch (idFactura)
            {
                case "F001": return 1250.75m;
                case "F002": return 950.00m;
                case "F003": return 745.20m;
                default: return 0.00m;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Controlador_Compras;

namespace Capa_Vista_Compras
{
    public partial class Frm_Factura_Proveedor : Form
    {
        private Cls_Controlador_Compras _controlador;
        public Frm_Factura_Proveedor()
        {
            InitializeComponent();
            _controlador = new Cls_Controlador_Compras();

            // Estado inicial
            Txt_TotalFactura.Text = "0.00";
            //al combobox de orden de compra eliminar luego con bd
            Cbo_OrdenCompra.SelectedIndexChanged += Cbo_OrdenCompra_SelectedIndexChanged;
            Cbo_OrdenCompra.Items.AddRange(new string[] { "OC001", "OC002", "OC003" });
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            // ================= NUEVA FACTURA =================
            Cbo_Proveedor.SelectedIndex = -1;
            Cbo_OrdenCompra.SelectedIndex = -1;
            Dtp_FechaFactura.Value = DateTime.Today;
            Txt_Numerofactura.Clear();
            Txt_TotalFactura.Text = "0.00";
            Dgv_DetalleFactura.Rows.Clear();

            CambiarModoEdicion(true);
            MessageBox.Show("Formulario listo para nueva factura.", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            // ================= AGREGAR PRODUCTO =================
            if (Dgv_DetalleFactura.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para ingresar datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = Dgv_DetalleFactura.CurrentRow;

            string id = Convert.ToString(fila.Cells["id_prducto"].Value)?.Trim();
            string producto = Convert.ToString(fila.Cells["producto"].Value)?.Trim();
            string strCantidad = Convert.ToString(fila.Cells["cantidad"].Value)?.Trim();
            string strPrecio = Convert.ToString(fila.Cells["preciounit"].Value)?.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(producto))
            {
                MessageBox.Show("Debe ingresar el ID y nombre del producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(strCantidad, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(strPrecio, out decimal precioUnitario) || precioUnitario <= 0)
            {
                MessageBox.Show("Precio inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datos = _controlador.AgregarLinea(id, producto, cantidad, precioUnitario);
            fila.Cells["subtotal"].Value = datos.subtotal.ToString("0.00");

            Txt_TotalFactura.Text = _controlador.CalcularTotal().ToString("0.00");

            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

    }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            // ================= ELIMINAR PRODUCTO =================
            if (Dgv_DetalleFactura.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una línea para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = Dgv_DetalleFactura.CurrentRow.Index;
            _controlador.QuitarLinea(rowIndex);
            Dgv_DetalleFactura.Rows.RemoveAt(rowIndex);
            Txt_TotalFactura.Text = _controlador.CalcularTotal().ToString("0.00");
    }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // ================= GUARDAR FACTURA =================
            if (Cbo_Proveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Txt_Numerofactura.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el número de factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Dgv_DetalleFactura.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CambiarModoEdicion(false);
            MessageBox.Show("Factura registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            // ================= EDITAR FACTURA =================
            var confirmar = MessageBox.Show("¿Desea habilitar la edición de esta factura?", "Editar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                CambiarModoEdicion(true);
                MessageBox.Show("Edición habilitada.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Anular_Click(object sender, EventArgs e)
        {
            // ================= ANULAR FACTURA =================
            var confirmar = MessageBox.Show("¿Desea anular esta factura?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar == DialogResult.Yes)
            {
                CambiarModoEdicion(false);
                MessageBox.Show("Factura anulada correctamente.", "Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            // ================= CANCELAR =================
            var confirmar = MessageBox.Show("¿Desea cancelar y cerrar el formulario?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
                this.Close();
        }

        // ================= FUNCIONES AUXILIARES =================
        private void CambiarModoEdicion(bool habilitar)
        {
            Cbo_Proveedor.Enabled = habilitar;
            Cbo_OrdenCompra.Enabled = habilitar;
            Dtp_FechaFactura.Enabled = habilitar;
            Txt_Numerofactura.ReadOnly = !habilitar;
            Dgv_DetalleFactura.ReadOnly = !habilitar;
            Btn_Agregar.Enabled = habilitar;
            Btn_Eliminar.Enabled = habilitar;
        }

        private void Cbo_OrdenCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cuando cambia la orden de compra seleccionada
            if (Cbo_OrdenCompra.SelectedIndex == -1)
                return;

            string idOrden = Cbo_OrdenCompra.SelectedItem.ToString();

            // Obtener productos de la orden seleccionada
            var productos = _controlador.ObtenerProductosPorOrden(idOrden);

            // Limpiar detalle actual
            Dgv_DetalleFactura.Rows.Clear();

            foreach (var p in productos)
            {
                if (p.id != "—")
                {
                    int n = Dgv_DetalleFactura.Rows.Add();
                    Dgv_DetalleFactura.Rows[n].Cells["id_prducto"].Value = p.id;
                    Dgv_DetalleFactura.Rows[n].Cells["producto"].Value = p.nombre;
                    Dgv_DetalleFactura.Rows[n].Cells["cantidad"].Value = p.cantidad;
                    Dgv_DetalleFactura.Rows[n].Cells["preciounit"].Value = p.precio.ToString("0.00");
                    Dgv_DetalleFactura.Rows[n].Cells["subtotal"].Value = (p.cantidad * p.precio).ToString("0.00");
                }
            }

            // Calcular total general
            Txt_TotalFactura.Text = _controlador.CalcularTotal().ToString("0.00");

            MessageBox.Show("Productos cargados desde la orden de compra seleccionada.",
                "Carga completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    }
}

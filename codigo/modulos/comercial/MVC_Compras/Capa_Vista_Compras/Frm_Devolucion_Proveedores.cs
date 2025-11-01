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
    public partial class Frm_Devolucion_Proveedores : Form
    {
        private Cls_Controlador_Compras _controlador;
        public Frm_Devolucion_Proveedores()
        {
            InitializeComponent();
            _controlador = new Cls_Controlador_Compras();

            // Configuración inicial
            this.Text = "Devolución a Proveedores";
            Gpb_DatosNota.Text = "Datos de la Devolución";
            Lbl_Monto.Text = "Monto devuelto";
            Lbl_Motivo.Text = "Motivo de devolución";
            Lbl_FacturaAfectada.Text = "Factura a devolver";
            Lbl_Devolucion.Text = "Tipo devolución";

            Dgv_DetalleDevolucion.CellEndEdit += Dgv_DetalleDevolucion_CellEndEdit;

            Cbo_TipoDevolucion.Items.Clear();
            Cbo_TipoDevolucion.Items.AddRange(new string[] { "Devolución total", "Devolución parcial" });

            // Inicialización visual
            Txt_Monto.Text = "0.00";
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            // ================= NUEVA DEVOLUCIÓN =================
            Cbo_Proveedor.SelectedIndex = -1;
            Cbo_Factura.SelectedIndex = -1;
            Cbo_TipoDevolucion.SelectedIndex = -1;
            Dtp_Fecha.Value = DateTime.Today;
            Txt_Monto.Text = "0.00";
            Txt_Motivo.Clear();

            CambiarModoEdicion(true);
            MessageBox.Show("Formulario listo para nueva devolución.", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

        private void Cbo_Factura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_Factura.SelectedIndex == -1) return;

            string idFactura = Cbo_Factura.SelectedItem.ToString();

            // Simulación: obtener el total de la factura seleccionada
            decimal totalFactura = _controlador.ObtenerTotalFactura(idFactura);

            Txt_Monto.Text = totalFactura.ToString("0.00");
            MessageBox.Show($"Factura {idFactura} seleccionada. Monto total: Q{totalFactura:N2}",
                "Factura seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

    }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // ================= GUARDAR DEVOLUCIÓN =================
            // Validaciones
            if (Cbo_Proveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Cbo_Factura.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una factura para devolver.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(Txt_Monto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Monto inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Txt_Motivo.Text))
            {
                MessageBox.Show("Debe especificar el motivo de la devolución.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CambiarModoEdicion(false);

            MessageBox.Show("Devolución registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            // ================= EDITAR DEVOLUCIÓN =================
            var confirmar = MessageBox.Show("¿Desea editar esta devolución?", "Editar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                CambiarModoEdicion(true);
                MessageBox.Show("Edición habilitada.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Anular_Click(object sender, EventArgs e)
        {
            // ================= ANULAR DEVOLUCIÓN =================
            var confirmar = MessageBox.Show("¿Desea anular esta devolución?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar == DialogResult.Yes)
            {
                CambiarModoEdicion(false);
                MessageBox.Show("Devolución anulada correctamente.", "Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            // ================= CANCELAR =================
            var confirmar = MessageBox.Show("¿Desea cerrar el formulario de devoluciones?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
                this.Close();
        }

        // ================= FUNCIÓN AUXILIAR =================
        private void CambiarModoEdicion(bool habilitar)
        {
            Cbo_Proveedor.Enabled = habilitar;
            Cbo_Factura.Enabled = habilitar;
            Cbo_TipoDevolucion.Enabled = habilitar;
            Dtp_Fecha.Enabled = habilitar;
            Txt_Motivo.ReadOnly = !habilitar;
            Txt_Monto.ReadOnly = !habilitar;
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            // ================= AGREGAR PRODUCTO =================
            if (Dgv_DetalleDevolucion.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para ingresar datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = Dgv_DetalleDevolucion.CurrentRow;

            string id = Convert.ToString(fila.Cells["id_producto"].Value)?.Trim();
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

            decimal subtotal = cantidad * precioUnitario;
            fila.Cells["subtotal"].Value = subtotal.ToString("0.00");

            RecalcularTotal();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            // ================= ELIMINAR PRODUCTO =================
            if (Dgv_DetalleDevolucion.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una línea para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dgv_DetalleDevolucion.Rows.RemoveAt(Dgv_DetalleDevolucion.CurrentRow.Index);
            RecalcularTotal();
        }

        // ================= REACCIONAR A EDICIÓN =================
        private void Dgv_DetalleDevolucion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = Dgv_DetalleDevolucion.Rows[e.RowIndex];
            if (!int.TryParse(fila.Cells["cantidad"].Value?.ToString(), out int cantidad)) cantidad = 0;
            if (!decimal.TryParse(fila.Cells["preciounit"].Value?.ToString(), out decimal precio)) precio = 0.00m;

            fila.Cells["subtotal"].Value = (cantidad * precio).ToString("0.00");
            RecalcularTotal();
        }

        // ================= RECALCULAR TOTAL =================
        private void RecalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in Dgv_DetalleDevolucion.Rows)
            {
                if (fila.Cells["subtotal"].Value != null && decimal.TryParse(fila.Cells["subtotal"].Value.ToString(), out decimal sub))
                    total += sub;
            }
            Txt_Monto.Text = total.ToString("0.00");
        }
    }
}

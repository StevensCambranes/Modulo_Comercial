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
            Lbl_TipoNota.Text = "Tipo devolución";

            Cbo_TipoNota.Items.Clear();
            Cbo_TipoNota.Items.AddRange(new string[] { "Devolución total", "Devolución parcial" });

            // Inicialización visual
            Txt_Monto.Text = "0.00";
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            // ================= NUEVA DEVOLUCIÓN =================
            Cbo_Proveedor.SelectedIndex = -1;
            Cbo_Factura.SelectedIndex = -1;
            Cbo_TipoNota.SelectedIndex = -1;
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
            Cbo_TipoNota.Enabled = habilitar;
            Dtp_Fecha.Enabled = habilitar;
            Txt_Motivo.ReadOnly = !habilitar;
            Txt_Monto.ReadOnly = !habilitar;
        }
    }
}

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
    public partial class Frm_Envio_Contabilidad : Form
    {
        private Cls_Controlador_EnvioContabilidad _controlador;
        private List<(int Id, string Proveedor, DateTime Fecha, decimal Total, string Estado)> _comprasPendientes;

        public Frm_Envio_Contabilidad()
        {
            InitializeComponent();
            _controlador = new Cls_Controlador_EnvioContabilidad();

            Btn_Enviar.Click += async (s, e) => await EnviarSeleccionadas();
            Btn_Actualizar.Click += (s, e) => CargarPendientes();
            Btn_Historial.Click += (s, e) => MostrarHistorial();
            Btn_Cerrar.Click += (s, e) => Close();

            CargarPendientes();
        }

        private void CargarPendientes()
        {
            Dgv_Pendientes.Rows.Clear();
            _comprasPendientes = _controlador.ObtenerPendientes();

            foreach (var c in _comprasPendientes)
            {
                Dgv_Pendientes.Rows.Add(c.Id, c.Proveedor, c.Fecha.ToShortDateString(), c.Total.ToString("0.00"), c.Estado);
            }
        }

        private async Task EnviarSeleccionadas()
        {
            if (Dgv_Pendientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una compra para enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var seleccionados = new List<(int, string, DateTime, decimal, string)>();

            foreach (DataGridViewRow fila in Dgv_Pendientes.SelectedRows)
            {
                int id = Convert.ToInt32(fila.Cells["id_compra"].Value);
                var compra = _comprasPendientes.First(c => c.Id == id);
                seleccionados.Add(compra);
            }

            Lbl_Progreso.Text = "Progreso: 0%";
            Pgb_Envio.Value = 0;
            Btn_Enviar.Enabled = false;

            await _controlador.EnviarAContabilidadAsync(seleccionados, (porcentaje) =>
            {
                Pgb_Envio.Value = porcentaje;
                Lbl_Progreso.Text = $"Progreso: {porcentaje}%";
            });

            MessageBox.Show("Las compras seleccionadas fueron enviadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Btn_Enviar.Enabled = true;
            CargarPendientes();
        }

        private void MostrarHistorial()
        {
            MessageBox.Show("Aquí se mostrará el historial de envíos a contabilidad (pendiente de BD).",
                "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

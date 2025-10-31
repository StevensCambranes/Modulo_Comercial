using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista_Compras
{
    public partial class Frm_Compras_Periodo : Form
    {
        private List<Compra> _compras;
        public Frm_Compras_Periodo()
        {
            InitializeComponent();
            InicializarDatosPrueba();

            CargarListado(_compras);
        }

        private void InicializarDatosPrueba()
        {
            _compras = new List<Compra>
            {
                new Compra(1, "Proveedor A", new DateTime(2025,10,20), 1500.00m, "Aprobada"),
                new Compra(2, "Proveedor B", new DateTime(2025,10,23), 890.50m, "Pendiente"),
                new Compra(3, "Proveedor C", new DateTime(2025,10,25), 1250.75m, "Aprobada"),
                new Compra(4, "Proveedor D", new DateTime(2025,10,27), 600.00m, "Anulada"),
                new Compra(5, "Proveedor E", new DateTime(2025,10,29), 400.00m, "Aprobada")
            };
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            // ================== BUSCAR POR RANGO ==================
            DateTime fechaInicio = Dtp_FechaInicio.Value.Date;
            DateTime fechaFin = Dtp_FechaFin.Value.Date;

            if (fechaFin < fechaInicio)
            {
                MessageBox.Show("La fecha final no puede ser menor que la fecha inicial.",
                    "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var comprasFiltradas = _compras.FindAll(c =>
                c.FechaCompra.Date >= fechaInicio && c.FechaCompra.Date <= fechaFin);

            CargarListado(comprasFiltradas);

            MessageBox.Show($"Se encontraron {comprasFiltradas.Count} compras en el rango seleccionado.",
                "Búsqueda completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            // ================== LIMPIAR ==================
            Dtp_FechaInicio.Value = DateTime.Today.AddDays(-7);
            Dtp_FechaFin.Value = DateTime.Today;
            CargarListado(_compras);
        }

        // ================== CARGAR EN GRID ==================
        private void CargarListado(List<Compra> lista)
        {
            Dgv_Compras.Rows.Clear();

            decimal total = 0;
            foreach (var c in lista)
            {
                Dgv_Compras.Rows.Add(c.IdCompra, c.Proveedor, c.FechaCompra.ToShortDateString(),
                    c.TotalCompra.ToString("0.00"), c.Estado);
                total += c.TotalCompra;
            }

            Txt_TotalCompras.Text = total.ToString("0.00");
        }
    }

    // Clase auxiliar simulada
    public class Compra
    {
        public int IdCompra { get; set; }
        public string Proveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public string Estado { get; set; }

        public Compra(int id, string proveedor, DateTime fecha, decimal total, string estado)
        {
            IdCompra = id;
            Proveedor = proveedor;
            FechaCompra = fecha;
            TotalCompra = total;
            Estado = estado;
        }
    }
}

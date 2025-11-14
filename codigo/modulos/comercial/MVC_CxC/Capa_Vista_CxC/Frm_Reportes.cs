using System;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Capa_Controlador_CxC;

namespace Capa_Vista_CxC
{
    public partial class Frm_Reportes : Form
    {
        private readonly Cls_Controlador _ctrl = new Cls_Controlador();
        private DataTable _dt;

        public Frm_Reportes()
        {
            InitializeComponent();
            Load += Frm_Reportes_Load;
            Cbo_Tipo.SelectedIndexChanged += (s, e) => ToggleParametros();
            Btn_Ver.Click += (s, e) => Ver();
            Btn_Exportar.Click += (s, e) => ExportarCsv();
            Btn_Imprimir.Click += (s, e) => PrintPreview();
        }

        private void Frm_Reportes_Load(object sender, EventArgs e)
        {
            // Tipos
            Cbo_Tipo.Items.Clear();
            Cbo_Tipo.Items.Add("Antigüedad");
            Cbo_Tipo.Items.Add("Cierre de caja");
            Cbo_Tipo.SelectedIndex = 0;

            // Fechas por defecto
            Dtp_FechaCorte.Value = DateTime.Today;
            Dtp_FechaCaja.Value = DateTime.Today;

            // Obtener clientes como DataTable
            var clientes = _ctrl.ObtenerClientes();

            // Determinar columnas (ajusta si tus nombres son otros)
            string colId = clientes.Columns.Contains("Cmp_Id_Cliente") ? "Cmp_Id_Cliente"
                           : clientes.Columns.Contains("IdCliente") ? "IdCliente"
                           : clientes.Columns[0].ColumnName;

            string colName = clientes.Columns.Contains("Cmp_Nombre_Cliente") ? "Cmp_Nombre_Cliente"
                           : clientes.Columns.Contains("Cliente") ? "Cliente"
                           : clientes.Columns[1].ColumnName;

            // Insertar opción "(Todos)" al inicio
            var filaTodos = clientes.NewRow();
            filaTodos[colId] = 0;
            filaTodos[colName] = "(Todos)";
            clientes.Rows.InsertAt(filaTodos, 0);

            // Enlazar combo
            Cbo_Cliente.DataSource = clientes;
            Cbo_Cliente.DisplayMember = colName;
            Cbo_Cliente.ValueMember = colId;
            Cbo_Cliente.SelectedIndex = 0;

        }

        private void ToggleParametros()
        {
            bool esAntig = Cbo_Tipo.SelectedItem != null && Cbo_Tipo.SelectedItem.ToString() == "Antigüedad";

            // Antigüedad visible
            Lbl_Cliente.Visible = esAntig;
            Cbo_Cliente.Visible = esAntig;
            Lbl_Corte.Visible = esAntig;
            Dtp_FechaCorte.Visible = esAntig;

            // Cierre visible
            Lbl_FechaCaja.Visible = !esAntig;
            Dtp_FechaCaja.Visible = !esAntig;

            // Total (solo cierre)
            Lbl_Total.Text = "";
        }

        private void Ver()
        {
            if (Cbo_Tipo.SelectedItem == null) { MessageBox.Show("Seleccione un tipo de reporte."); return; }

            string tipo = Cbo_Tipo.SelectedItem.ToString();

            if (tipo == "Antigüedad")
            {
                // Validaciones mínimas
                DateTime corte = Dtp_FechaCorte.Value.Date;

                string cli = null;
                if (Cbo_Cliente.SelectedIndex > 0) cli = Cbo_Cliente.SelectedItem.ToString();

                _dt = _ctrl.ObtenerAntiguedadDT(corte, cli);
                Dgv_Reporte.DataSource = _dt;

                // Headers bonitos
                if (Dgv_Reporte.Columns.Contains("0_30")) Dgv_Reporte.Columns["0_30"].HeaderText = "0–30";
                if (Dgv_Reporte.Columns.Contains("31_60")) Dgv_Reporte.Columns["31_60"].HeaderText = "31–60";
                if (Dgv_Reporte.Columns.Contains("61_90")) Dgv_Reporte.Columns["61_90"].HeaderText = "61–90";
                if (Dgv_Reporte.Columns.Contains("Mas_90")) Dgv_Reporte.Columns["Mas_90"].HeaderText = ">90";

                Lbl_Total.Text = ""; // no aplica
            }
            else // Cierre de caja
            {
                DateTime fecha = Dtp_FechaCaja.Value.Date;
                decimal total;
                _dt = _ctrl.ObtenerCajaDiaDT(fecha, out total);
                Dgv_Reporte.DataSource = _dt;
                Lbl_Total.Text = "Total del día: " + total.ToString("0.00");
            }
        }

        // ===== utilidades simples =====
        private void ExportarCsv()
        {
            if (_dt == null || _dt.Rows.Count == 0) { MessageBox.Show("No hay datos para exportar."); return; }
            var sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = "reporte.csv" };
            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            var sb = new StringBuilder();
            for (int c = 0; c < _dt.Columns.Count; c++)
            {
                if (c > 0) sb.Append(",");
                sb.Append("\"" + _dt.Columns[c].ColumnName.Replace("\"", "\"\"") + "\"");
            }
            sb.AppendLine();
            for (int r = 0; r < _dt.Rows.Count; r++)
            {
                for (int c = 0; c < _dt.Columns.Count; c++)
                {
                    if (c > 0) sb.Append(",");
                    string val = _dt.Rows[r][c] == null ? "" : _dt.Rows[r][c].ToString();
                    sb.Append("\"" + val.Replace("\"", "\"\"") + "\"");
                }
                sb.AppendLine();
            }
            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Exportado.");
        }

        private void PrintPreview()
        {
            if (_dt == null || _dt.Rows.Count == 0) { MessageBox.Show("No hay datos para imprimir."); return; }
            // CTRL + P
            // mantener este botón para futura integración con PrintDocument/RDLC.
            MessageBox.Show("Impresión básica pendiente (opcional).");
        }

        private void mnuRecibos_Click(object sender, EventArgs e)
        {
            Frm_AplicarPago Recibos = new Frm_AplicarPago();
            Recibos.Show();
            this.Close();
        }

        private void mnuAplicarPago_Click(object sender, EventArgs e)
        {
            Frm_AplicarPago frm = new Frm_AplicarPago();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
        private void ExportarDataTableAPdf(DataTable dt, string titulo, string rutaArchivo)
        {
            // Documento horizontal tamaño carta
            Document doc = new Document(PageSize.LETTER.Rotate(), 40, 40, 40, 40);

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                // Fuentes
                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                var fontSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontCabecera = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                var fontCelda = FontFactory.GetFont(FontFactory.HELVETICA, 9);

                // Título
                doc.Add(new Paragraph(titulo, fontTitulo));
                doc.Add(new Paragraph("Fecha de impresión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontSubtitulo));
                doc.Add(new Paragraph(" "));

                // Tabla con el mismo número de columnas que el DataTable
                PdfPTable table = new PdfPTable(dt.Columns.Count);
                table.WidthPercentage = 100;

                // Encabezados
                foreach (DataColumn col in dt.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName, fontCabecera));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                // Filas
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        string texto = item == null ? "" : item.ToString();
                        PdfPCell cell = new PdfPCell(new Phrase(texto, fontCelda));
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        table.AddCell(cell);
                    }
                }

                doc.Add(table);
                doc.Close();
                writer.Close();
            }
        }
        private void Btn_Imprimir_Click(object sender, EventArgs e)
        {
            if (_dt == null || _dt.Rows.Count == 0) { MessageBox.Show("No hay datos para imprimir."); return; }
            var dt = Dgv_Reporte.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Título según el tipo de reporte seleccionado
            string tipo = Cbo_Tipo.SelectedItem?.ToString() ?? "Reporte";
            string titulo = "";

            if (tipo.Contains("Antigüedad"))
            {
                titulo = "Antigüedad de saldos al " + Dtp_FechaCorte.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                titulo = "Reporte de " + tipo + " al " + Dtp_FechaCorte.Value.ToString("dd/MM/yyyy");
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName = tipo.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportarDataTableAPdf(dt, titulo, sfd.FileName);
                        MessageBox.Show("Reporte generado correctamente:\n" + sfd.FileName,
                                        "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar el PDF:\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

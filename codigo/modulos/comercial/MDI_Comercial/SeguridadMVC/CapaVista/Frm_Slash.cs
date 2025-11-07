using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capa_Vista_Comercial
{
    public partial class Frm_Slash : Form
    {
        public Frm_Slash()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Resize += (s, e) => ApplyLayout();
        }

        private void Frm_Slash_Load(object sender, EventArgs e)
        {
            // ===== CONFIGURACIÓN GENERAL =====
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // ===== LOGO DEL MÓDULO (CENTRADO) =====
            try
            {
                Pic_Logo_Modulo_Comercial.Image = Properties.Resources.Logo_Modulo_Comercial;
            }
            catch
            {
                // si el recurso no existe, no rompe
            }
            Pic_Logo_Modulo_Comercial.SizeMode = PictureBoxSizeMode.Zoom;
            Pic_Logo_Modulo_Comercial.BackColor = Color.Transparent;

            // ===== LOGO DE LA EMPRESA (ESQUINA SUPERIOR IZQUIERDA) =====
            try
            {
                Pic_Logo_Empresa.Image = Properties.Resources.Logo_Empresa_General; // ajusta al nombre real del recurso
            }
            catch { }

            Pic_Logo_Empresa.SizeMode = PictureBoxSizeMode.Zoom;
            Pic_Logo_Empresa.BackColor = Color.Transparent;

            // ===== BARRA DE PROGRESO =====
            Pgb_Carga.Style = ProgressBarStyle.Continuous;
            Pgb_Carga.Minimum = 0;
            Pgb_Carga.Maximum = 100;
            Pgb_Carga.Value = 0;

            // ===== LABEL DEL PORCENTAJE =====
            Lbl_Porcentaje.Text = "0%";
            Lbl_Porcentaje.Font = new Font("Rockwell", 18, FontStyle.Bold);
            Lbl_Porcentaje.ForeColor = Color.Black;
            Lbl_Porcentaje.TextAlign = ContentAlignment.MiddleCenter;

            // ===== TIMER =====
            Tmr_Carga.Interval = 100; // velocidad de animación
            Tmr_Carga.Enabled = true;
            Tmr_Carga.Start();

            ApplyLayout();
        }

        private void Tmr_Carga_Tick(object sender, EventArgs e)
        {
            if (Pgb_Carga.Value < Pgb_Carga.Maximum)
            {
                Pgb_Carga.Increment(2);
                Lbl_Porcentaje.Text = Pgb_Carga.Value + "%";
            }
            else
            {
                Tmr_Carga.Stop();
                this.Hide();
                // new Frm_Login().Show(); // aquí puedes abrir tu siguiente formulario
            }
        }

        /// <summary>
        /// Posiciona los elementos del splash dinámicamente.
        /// </summary>
        private void ApplyLayout()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            int margin = 20;

            // ===== LOGO EMPRESA (ARRIBA IZQUIERDA) =====
            int empresaSize = Math.Max(60, Math.Min((int)(w * 0.08), 100));
            Pic_Logo_Empresa.Size = new Size(empresaSize, empresaSize);
            Pic_Logo_Empresa.Location = new Point(margin, margin);
            Pic_Logo_Empresa.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // ===== LOGO PRINCIPAL (CENTRADO Y ELEVADO) =====
            int logoW = Math.Max(200, Math.Min((int)(w * 0.32), 420));
            int logoH = logoW;
            Pic_Logo_Modulo_Comercial.Size = new Size(logoW, logoH);

            // subido a ~15% de la altura de la ventana
            int topLogo = Math.Max(margin + empresaSize + 10, (int)(h * 0.15));
            Pic_Logo_Modulo_Comercial.Location = new Point((w - logoW) / 2, topLogo);

            // ===== BARRA DE PROGRESO =====
            int barWidth = Math.Max(300, Math.Min((int)(w * 0.72), 640));
            int barLeft = (w - barWidth) / 2;

            int gapBelowLogo = 28;                 // separación entre logo y barra
            int bottomMargin = 90;                 // evita que se pegue al borde inferior
            int maxBarTop = h - bottomMargin;      // límite inferior
            int preferredTop = Pic_Logo_Modulo_Comercial.Bottom + gapBelowLogo;

            // Usa el menor para que no se vaya muy abajo
            int barTop = Math.Min(preferredTop, maxBarTop);
            Pgb_Carga.SetBounds(barLeft, barTop, barWidth, 24);

            // ===== PORCENTAJE =====
            Lbl_Porcentaje.SetBounds(barLeft, Pgb_Carga.Bottom + 6, barWidth, 22);
            Lbl_Porcentaje.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}

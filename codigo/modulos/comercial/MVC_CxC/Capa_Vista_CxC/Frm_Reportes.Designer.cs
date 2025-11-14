using System;
using System.Windows.Forms;

namespace Capa_Vista_CxC
{
    partial class Frm_Reportes
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.mnuRecibos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAplicarPago = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.Gpb_Params = new System.Windows.Forms.GroupBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Cbo_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Cbo_Cliente = new System.Windows.Forms.ComboBox();
            this.Lbl_Corte = new System.Windows.Forms.Label();
            this.Dtp_FechaCorte = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FechaCaja = new System.Windows.Forms.Label();
            this.Dtp_FechaCaja = new System.Windows.Forms.DateTimePicker();
            this.Btn_Ver = new System.Windows.Forms.Button();
            this.Btn_Imprimir = new System.Windows.Forms.Button();
            this.Btn_Exportar = new System.Windows.Forms.Button();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.Dgv_Reporte = new System.Windows.Forms.DataGridView();
            this.menu.SuspendLayout();
            this.Gpb_Params.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRecibos,
            this.mnuAplicarPago,
            this.mnuReportes,
            this.mnuSalir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1200, 24);
            this.menu.TabIndex = 2;
            // 
            // mnuRecibos
            // 
            this.mnuRecibos.Name = "mnuRecibos";
            this.mnuRecibos.Size = new System.Drawing.Size(66, 20);
            this.mnuRecibos.Text = "Recibos";
            this.mnuRecibos.Click += new System.EventHandler(this.mnuRecibos_Click);
            // 
            // mnuAplicarPago
            // 
            this.mnuAplicarPago.Name = "mnuAplicarPago";
            this.mnuAplicarPago.Size = new System.Drawing.Size(94, 20);
            this.mnuAplicarPago.Text = "Aplicar Pago";
            this.mnuAplicarPago.Click += new System.EventHandler(this.mnuAplicarPago_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(72, 20);
            this.mnuReportes.Text = "Reportes";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(45, 20);
            this.mnuSalir.Text = "Salir";
            // 
            // Gpb_Params
            // 
            this.Gpb_Params.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gpb_Params.Controls.Add(this.Lbl_Tipo);
            this.Gpb_Params.Controls.Add(this.Cbo_Tipo);
            this.Gpb_Params.Controls.Add(this.Lbl_Cliente);
            this.Gpb_Params.Controls.Add(this.Cbo_Cliente);
            this.Gpb_Params.Controls.Add(this.Lbl_Corte);
            this.Gpb_Params.Controls.Add(this.Dtp_FechaCorte);
            this.Gpb_Params.Controls.Add(this.Lbl_FechaCaja);
            this.Gpb_Params.Controls.Add(this.Dtp_FechaCaja);
            this.Gpb_Params.Controls.Add(this.Btn_Ver);
            this.Gpb_Params.Controls.Add(this.Btn_Imprimir);
            this.Gpb_Params.Controls.Add(this.Btn_Exportar);
            this.Gpb_Params.Controls.Add(this.Lbl_Total);
            this.Gpb_Params.Location = new System.Drawing.Point(12, 32);
            this.Gpb_Params.Name = "Gpb_Params";
            this.Gpb_Params.Size = new System.Drawing.Size(1176, 92);
            this.Gpb_Params.TabIndex = 1;
            this.Gpb_Params.TabStop = false;
            this.Gpb_Params.Text = "Parámetros";
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Location = new System.Drawing.Point(16, 32);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(37, 16);
            this.Lbl_Tipo.TabIndex = 0;
            this.Lbl_Tipo.Text = "Tipo:";
            // 
            // Cbo_Tipo
            // 
            this.Cbo_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Tipo.Location = new System.Drawing.Point(56, 28);
            this.Cbo_Tipo.Name = "Cbo_Tipo";
            this.Cbo_Tipo.Size = new System.Drawing.Size(220, 24);
            this.Cbo_Tipo.TabIndex = 1;
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Location = new System.Drawing.Point(300, 32);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(53, 16);
            this.Lbl_Cliente.TabIndex = 2;
            this.Lbl_Cliente.Text = "Cliente:";
            // 
            // Cbo_Cliente
            // 
            this.Cbo_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Cliente.Location = new System.Drawing.Point(351, 28);
            this.Cbo_Cliente.Name = "Cbo_Cliente";
            this.Cbo_Cliente.Size = new System.Drawing.Size(240, 24);
            this.Cbo_Cliente.TabIndex = 3;
            // 
            // Lbl_Corte
            // 
            this.Lbl_Corte.AutoSize = true;
            this.Lbl_Corte.Location = new System.Drawing.Point(610, 32);
            this.Lbl_Corte.Name = "Lbl_Corte";
            this.Lbl_Corte.Size = new System.Drawing.Size(80, 16);
            this.Lbl_Corte.TabIndex = 4;
            this.Lbl_Corte.Text = "Fecha corte:";
            // 
            // Dtp_FechaCorte
            // 
            this.Dtp_FechaCorte.Location = new System.Drawing.Point(685, 28);
            this.Dtp_FechaCorte.Name = "Dtp_FechaCorte";
            this.Dtp_FechaCorte.Size = new System.Drawing.Size(180, 23);
            this.Dtp_FechaCorte.TabIndex = 5;
            // 
            // Lbl_FechaCaja
            // 
            this.Lbl_FechaCaja.AutoSize = true;
            this.Lbl_FechaCaja.Location = new System.Drawing.Point(300, 61);
            this.Lbl_FechaCaja.Name = "Lbl_FechaCaja";
            this.Lbl_FechaCaja.Size = new System.Drawing.Size(47, 16);
            this.Lbl_FechaCaja.TabIndex = 6;
            this.Lbl_FechaCaja.Text = "Fecha:";
            // 
            // Dtp_FechaCaja
            // 
            this.Dtp_FechaCaja.Location = new System.Drawing.Point(351, 57);
            this.Dtp_FechaCaja.Name = "Dtp_FechaCaja";
            this.Dtp_FechaCaja.Size = new System.Drawing.Size(180, 23);
            this.Dtp_FechaCaja.TabIndex = 7;
            // 
            // Btn_Ver
            // 
            this.Btn_Ver.Location = new System.Drawing.Point(885, 27);
            this.Btn_Ver.Name = "Btn_Ver";
            this.Btn_Ver.Size = new System.Drawing.Size(80, 24);
            this.Btn_Ver.TabIndex = 8;
            this.Btn_Ver.Text = "Ver";
            // 
            // Btn_Imprimir
            // 
            this.Btn_Imprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Imprimir.Location = new System.Drawing.Point(994, 27);
            this.Btn_Imprimir.Name = "Btn_Imprimir";
            this.Btn_Imprimir.Size = new System.Drawing.Size(80, 24);
            this.Btn_Imprimir.TabIndex = 9;
            this.Btn_Imprimir.Text = "Imprimir";
            this.Btn_Imprimir.Click += new System.EventHandler(this.Btn_Imprimir_Click);
            // 
            // Btn_Exportar
            // 
            this.Btn_Exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Exportar.Location = new System.Drawing.Point(1090, 27);
            this.Btn_Exportar.Name = "Btn_Exportar";
            this.Btn_Exportar.Size = new System.Drawing.Size(90, 24);
            this.Btn_Exportar.TabIndex = 10;
            this.Btn_Exportar.Text = "Exportar CSV";
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Total.AutoSize = true;
            this.Lbl_Total.Location = new System.Drawing.Point(995, 61);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(0, 16);
            this.Lbl_Total.TabIndex = 11;
            // 
            // Dgv_Reporte
            // 
            this.Dgv_Reporte.AllowUserToAddRows = false;
            this.Dgv_Reporte.AllowUserToDeleteRows = false;
            this.Dgv_Reporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dgv_Reporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Reporte.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Dgv_Reporte.Location = new System.Drawing.Point(12, 134);
            this.Dgv_Reporte.Name = "Dgv_Reporte";
            this.Dgv_Reporte.ReadOnly = true;
            this.Dgv_Reporte.RowHeadersVisible = false;
            this.Dgv_Reporte.Size = new System.Drawing.Size(1176, 504);
            this.Dgv_Reporte.TabIndex = 0;
            // 
            // Frm_Reportes
            // 
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.Dgv_Reporte);
            this.Controls.Add(this.Gpb_Params);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menu;
            this.Name = "Frm_Reportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por Cobrar — Reportes (Antigüedad / Cierre de Caja)";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.Gpb_Params.ResumeLayout(false);
            this.Gpb_Params.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Reporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mnuRecibos;
        private System.Windows.Forms.ToolStripMenuItem mnuAplicarPago;
        private System.Windows.Forms.ToolStripMenuItem mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;

        private System.Windows.Forms.GroupBox Gpb_Params;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.ComboBox Cbo_Tipo;

        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.ComboBox Cbo_Cliente;
        private System.Windows.Forms.Label Lbl_Corte;
        private System.Windows.Forms.DateTimePicker Dtp_FechaCorte;

        private System.Windows.Forms.Label Lbl_FechaCaja;
        private System.Windows.Forms.DateTimePicker Dtp_FechaCaja;

        private System.Windows.Forms.Button Btn_Ver;
        private System.Windows.Forms.Button Btn_Exportar;
        private System.Windows.Forms.Button Btn_Imprimir;
        private System.Windows.Forms.Label Lbl_Total;

        private System.Windows.Forms.DataGridView Dgv_Reporte;
    }
}

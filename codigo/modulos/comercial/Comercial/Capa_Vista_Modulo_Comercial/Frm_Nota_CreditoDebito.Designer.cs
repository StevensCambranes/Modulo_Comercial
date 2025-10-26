﻿
namespace Capa_Vista_Modulo_Comercial
{
    partial class Frm_Nota_CreditoDebito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Gpb_DatosNota = new System.Windows.Forms.GroupBox();
            this.Cbo_Proveedor = new System.Windows.Forms.ComboBox();
            this.Lbl_Proveedor = new System.Windows.Forms.Label();
            this.Lbl_TipoNota = new System.Windows.Forms.Label();
            this.Cbo_TipoNota = new System.Windows.Forms.ComboBox();
            this.Lbl_FacturaAfectada = new System.Windows.Forms.Label();
            this.Cbo_Factura = new System.Windows.Forms.ComboBox();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Monto = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Lbl_Motivo = new System.Windows.Forms.Label();
            this.Txt_Motivo = new System.Windows.Forms.TextBox();
            this.Pnl_AccionesNota = new System.Windows.Forms.Panel();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Anular = new System.Windows.Forms.Button();
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Gpb_DatosNota.SuspendLayout();
            this.Pnl_AccionesNota.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gpb_DatosNota
            // 
            this.Gpb_DatosNota.Controls.Add(this.Txt_Motivo);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Motivo);
            this.Gpb_DatosNota.Controls.Add(this.textBox1);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Monto);
            this.Gpb_DatosNota.Controls.Add(this.Dtp_Fecha);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Fecha);
            this.Gpb_DatosNota.Controls.Add(this.Cbo_Factura);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_FacturaAfectada);
            this.Gpb_DatosNota.Controls.Add(this.Cbo_TipoNota);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_TipoNota);
            this.Gpb_DatosNota.Controls.Add(this.Cbo_Proveedor);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Proveedor);
            this.Gpb_DatosNota.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_DatosNota.Location = new System.Drawing.Point(20, 20);
            this.Gpb_DatosNota.Name = "Gpb_DatosNota";
            this.Gpb_DatosNota.Size = new System.Drawing.Size(830, 300);
            this.Gpb_DatosNota.TabIndex = 0;
            this.Gpb_DatosNota.TabStop = false;
            this.Gpb_DatosNota.Text = "Datos de la Nota de Credito o Debito";
            // 
            // Cbo_Proveedor
            // 
            this.Cbo_Proveedor.FormattingEnabled = true;
            this.Cbo_Proveedor.Location = new System.Drawing.Point(110, 30);
            this.Cbo_Proveedor.Name = "Cbo_Proveedor";
            this.Cbo_Proveedor.Size = new System.Drawing.Size(250, 28);
            this.Cbo_Proveedor.TabIndex = 8;
            // 
            // Lbl_Proveedor
            // 
            this.Lbl_Proveedor.AutoSize = true;
            this.Lbl_Proveedor.Location = new System.Drawing.Point(20, 35);
            this.Lbl_Proveedor.Name = "Lbl_Proveedor";
            this.Lbl_Proveedor.Size = new System.Drawing.Size(92, 20);
            this.Lbl_Proveedor.TabIndex = 7;
            this.Lbl_Proveedor.Text = "Proveedor";
            // 
            // Lbl_TipoNota
            // 
            this.Lbl_TipoNota.AutoSize = true;
            this.Lbl_TipoNota.Location = new System.Drawing.Point(400, 35);
            this.Lbl_TipoNota.Name = "Lbl_TipoNota";
            this.Lbl_TipoNota.Size = new System.Drawing.Size(108, 20);
            this.Lbl_TipoNota.TabIndex = 9;
            this.Lbl_TipoNota.Text = "Tipo de Nota";
            // 
            // Cbo_TipoNota
            // 
            this.Cbo_TipoNota.FormattingEnabled = true;
            this.Cbo_TipoNota.Items.AddRange(new object[] {
            "Crédito",
            "Débito"});
            this.Cbo_TipoNota.Location = new System.Drawing.Point(514, 30);
            this.Cbo_TipoNota.Name = "Cbo_TipoNota";
            this.Cbo_TipoNota.Size = new System.Drawing.Size(150, 28);
            this.Cbo_TipoNota.TabIndex = 10;
            // 
            // Lbl_FacturaAfectada
            // 
            this.Lbl_FacturaAfectada.AutoSize = true;
            this.Lbl_FacturaAfectada.Location = new System.Drawing.Point(20, 75);
            this.Lbl_FacturaAfectada.Name = "Lbl_FacturaAfectada";
            this.Lbl_FacturaAfectada.Size = new System.Drawing.Size(140, 20);
            this.Lbl_FacturaAfectada.TabIndex = 11;
            this.Lbl_FacturaAfectada.Text = "Factura Afectada";
            // 
            // Cbo_Factura
            // 
            this.Cbo_Factura.FormattingEnabled = true;
            this.Cbo_Factura.Location = new System.Drawing.Point(160, 72);
            this.Cbo_Factura.Name = "Cbo_Factura";
            this.Cbo_Factura.Size = new System.Drawing.Size(200, 28);
            this.Cbo_Factura.TabIndex = 12;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(400, 75);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(56, 20);
            this.Lbl_Fecha.TabIndex = 13;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Location = new System.Drawing.Point(462, 70);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(316, 27);
            this.Dtp_Fecha.TabIndex = 14;
            // 
            // Lbl_Monto
            // 
            this.Lbl_Monto.AutoSize = true;
            this.Lbl_Monto.Location = new System.Drawing.Point(20, 115);
            this.Lbl_Monto.Name = "Lbl_Monto";
            this.Lbl_Monto.Size = new System.Drawing.Size(59, 20);
            this.Lbl_Monto.TabIndex = 15;
            this.Lbl_Monto.Text = "Monto";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 27);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_Motivo
            // 
            this.Lbl_Motivo.AutoSize = true;
            this.Lbl_Motivo.Location = new System.Drawing.Point(20, 155);
            this.Lbl_Motivo.Name = "Lbl_Motivo";
            this.Lbl_Motivo.Size = new System.Drawing.Size(63, 20);
            this.Lbl_Motivo.TabIndex = 17;
            this.Lbl_Motivo.Text = "Motivo";
            // 
            // Txt_Motivo
            // 
            this.Txt_Motivo.Location = new System.Drawing.Point(110, 150);
            this.Txt_Motivo.Multiline = true;
            this.Txt_Motivo.Name = "Txt_Motivo";
            this.Txt_Motivo.Size = new System.Drawing.Size(700, 25);
            this.Txt_Motivo.TabIndex = 18;
            // 
            // Pnl_AccionesNota
            // 
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Cancelar);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Anular);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Editar);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Guardar);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Nuevo);
            this.Pnl_AccionesNota.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_AccionesNota.Location = new System.Drawing.Point(20, 340);
            this.Pnl_AccionesNota.Name = "Pnl_AccionesNota";
            this.Pnl_AccionesNota.Size = new System.Drawing.Size(830, 60);
            this.Pnl_AccionesNota.TabIndex = 3;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(564, 15);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.Btn_Cancelar.TabIndex = 6;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // Btn_Anular
            // 
            this.Btn_Anular.Location = new System.Drawing.Point(454, 15);
            this.Btn_Anular.Name = "Btn_Anular";
            this.Btn_Anular.Size = new System.Drawing.Size(100, 30);
            this.Btn_Anular.TabIndex = 4;
            this.Btn_Anular.Text = "Anular";
            this.Btn_Anular.UseVisualStyleBackColor = true;
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.Location = new System.Drawing.Point(344, 15);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(100, 30);
            this.Btn_Editar.TabIndex = 3;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.UseVisualStyleBackColor = true;
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(234, 15);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(100, 30);
            this.Btn_Guardar.TabIndex = 2;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Location = new System.Drawing.Point(124, 15);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(100, 30);
            this.Btn_Nuevo.TabIndex = 1;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            // 
            // Frm_Nota_CreditoDebito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(863, 450);
            this.Controls.Add(this.Pnl_AccionesNota);
            this.Controls.Add(this.Gpb_DatosNota);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Nota_CreditoDebito";
            this.Text = "Frm_Nota_CreditoDebito";
            this.Gpb_DatosNota.ResumeLayout(false);
            this.Gpb_DatosNota.PerformLayout();
            this.Pnl_AccionesNota.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_DatosNota;
        private System.Windows.Forms.ComboBox Cbo_Factura;
        private System.Windows.Forms.Label Lbl_FacturaAfectada;
        private System.Windows.Forms.ComboBox Cbo_TipoNota;
        private System.Windows.Forms.Label Lbl_TipoNota;
        private System.Windows.Forms.ComboBox Cbo_Proveedor;
        private System.Windows.Forms.Label Lbl_Proveedor;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.TextBox Txt_Motivo;
        private System.Windows.Forms.Label Lbl_Motivo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Lbl_Monto;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Panel Pnl_AccionesNota;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Anular;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Nuevo;
    }
}

namespace Capa_Vista_Compras
{
    partial class Frm_Devolucion_Proveedores
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
            this.Txt_Motivo = new System.Windows.Forms.TextBox();
            this.Lbl_Motivo = new System.Windows.Forms.Label();
            this.Txt_Monto = new System.Windows.Forms.TextBox();
            this.Lbl_Monto = new System.Windows.Forms.Label();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Cbo_Factura = new System.Windows.Forms.ComboBox();
            this.Lbl_FacturaAfectada = new System.Windows.Forms.Label();
            this.Cbo_TipoDevolucion = new System.Windows.Forms.ComboBox();
            this.Lbl_Devolucion = new System.Windows.Forms.Label();
            this.Cbo_Proveedor = new System.Windows.Forms.ComboBox();
            this.Lbl_Proveedor = new System.Windows.Forms.Label();
            this.Pnl_AccionesNota = new System.Windows.Forms.Panel();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Anular = new System.Windows.Forms.Button();
            this.Btn_Editar = new System.Windows.Forms.Button();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Gpb_DetalleDevolucion = new System.Windows.Forms.GroupBox();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Dgv_DetalleDevolucion = new System.Windows.Forms.DataGridView();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciounit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gpb_DatosNota.SuspendLayout();
            this.Pnl_AccionesNota.SuspendLayout();
            this.Gpb_DetalleDevolucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DetalleDevolucion)).BeginInit();
            this.SuspendLayout();
            // 
            // Gpb_DatosNota
            // 
            this.Gpb_DatosNota.Controls.Add(this.Txt_Motivo);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Motivo);
            this.Gpb_DatosNota.Controls.Add(this.Txt_Monto);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Monto);
            this.Gpb_DatosNota.Controls.Add(this.Dtp_Fecha);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Fecha);
            this.Gpb_DatosNota.Controls.Add(this.Cbo_Factura);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_FacturaAfectada);
            this.Gpb_DatosNota.Controls.Add(this.Cbo_TipoDevolucion);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Devolucion);
            this.Gpb_DatosNota.Controls.Add(this.Cbo_Proveedor);
            this.Gpb_DatosNota.Controls.Add(this.Lbl_Proveedor);
            this.Gpb_DatosNota.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_DatosNota.Location = new System.Drawing.Point(25, 25);
            this.Gpb_DatosNota.Margin = new System.Windows.Forms.Padding(4);
            this.Gpb_DatosNota.Name = "Gpb_DatosNota";
            this.Gpb_DatosNota.Padding = new System.Windows.Forms.Padding(4);
            this.Gpb_DatosNota.Size = new System.Drawing.Size(1038, 213);
            this.Gpb_DatosNota.TabIndex = 0;
            this.Gpb_DatosNota.TabStop = false;
            this.Gpb_DatosNota.Text = "Datos de la Devolución al Proveedor";
            // 
            // Txt_Motivo
            // 
            this.Txt_Motivo.Location = new System.Drawing.Point(211, 177);
            this.Txt_Motivo.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_Motivo.Multiline = true;
            this.Txt_Motivo.Name = "Txt_Motivo";
            this.Txt_Motivo.Size = new System.Drawing.Size(798, 30);
            this.Txt_Motivo.TabIndex = 18;
            // 
            // Lbl_Motivo
            // 
            this.Lbl_Motivo.AutoSize = true;
            this.Lbl_Motivo.Location = new System.Drawing.Point(22, 184);
            this.Lbl_Motivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Motivo.Name = "Lbl_Motivo";
            this.Lbl_Motivo.Size = new System.Drawing.Size(181, 20);
            this.Lbl_Motivo.TabIndex = 17;
            this.Lbl_Motivo.Text = "Motivo de Devolución";
            // 
            // Txt_Monto
            // 
            this.Txt_Monto.Location = new System.Drawing.Point(737, 76);
            this.Txt_Monto.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_Monto.Name = "Txt_Monto";
            this.Txt_Monto.Size = new System.Drawing.Size(149, 27);
            this.Txt_Monto.TabIndex = 16;
            this.Txt_Monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_Monto
            // 
            this.Lbl_Monto.AutoSize = true;
            this.Lbl_Monto.Location = new System.Drawing.Point(577, 83);
            this.Lbl_Monto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Monto.Name = "Lbl_Monto";
            this.Lbl_Monto.Size = new System.Drawing.Size(134, 20);
            this.Lbl_Monto.TabIndex = 15;
            this.Lbl_Monto.Text = "Monto Devuelto";
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Location = new System.Drawing.Point(165, 130);
            this.Dtp_Fecha.Margin = new System.Windows.Forms.Padding(4);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(394, 27);
            this.Dtp_Fecha.TabIndex = 14;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Location = new System.Drawing.Point(27, 137);
            this.Lbl_Fecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(56, 20);
            this.Lbl_Fecha.TabIndex = 13;
            this.Lbl_Fecha.Text = "Fecha";
            // 
            // Cbo_Factura
            // 
            this.Cbo_Factura.FormattingEnabled = true;
            this.Cbo_Factura.Location = new System.Drawing.Point(165, 76);
            this.Cbo_Factura.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Factura.Name = "Cbo_Factura";
            this.Cbo_Factura.Size = new System.Drawing.Size(249, 28);
            this.Cbo_Factura.TabIndex = 12;
            this.Cbo_Factura.SelectedIndexChanged += new System.EventHandler(this.Cbo_Factura_SelectedIndexChanged);
            // 
            // Lbl_FacturaAfectada
            // 
            this.Lbl_FacturaAfectada.AutoSize = true;
            this.Lbl_FacturaAfectada.Location = new System.Drawing.Point(22, 84);
            this.Lbl_FacturaAfectada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_FacturaAfectada.Name = "Lbl_FacturaAfectada";
            this.Lbl_FacturaAfectada.Size = new System.Drawing.Size(140, 20);
            this.Lbl_FacturaAfectada.TabIndex = 11;
            this.Lbl_FacturaAfectada.Text = "Factura Afectada";
            // 
            // Cbo_TipoDevolucion
            // 
            this.Cbo_TipoDevolucion.FormattingEnabled = true;
            this.Cbo_TipoDevolucion.Location = new System.Drawing.Point(737, 28);
            this.Cbo_TipoDevolucion.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_TipoDevolucion.Name = "Cbo_TipoDevolucion";
            this.Cbo_TipoDevolucion.Size = new System.Drawing.Size(186, 28);
            this.Cbo_TipoDevolucion.TabIndex = 10;
            // 
            // Lbl_Devolucion
            // 
            this.Lbl_Devolucion.AutoSize = true;
            this.Lbl_Devolucion.Location = new System.Drawing.Point(577, 35);
            this.Lbl_Devolucion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Devolucion.Name = "Lbl_Devolucion";
            this.Lbl_Devolucion.Size = new System.Drawing.Size(162, 20);
            this.Lbl_Devolucion.TabIndex = 9;
            this.Lbl_Devolucion.Text = "Tipo de Devolución";
            // 
            // Cbo_Proveedor
            // 
            this.Cbo_Proveedor.FormattingEnabled = true;
            this.Cbo_Proveedor.Location = new System.Drawing.Point(165, 28);
            this.Cbo_Proveedor.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Proveedor.Name = "Cbo_Proveedor";
            this.Cbo_Proveedor.Size = new System.Drawing.Size(312, 28);
            this.Cbo_Proveedor.TabIndex = 8;
            // 
            // Lbl_Proveedor
            // 
            this.Lbl_Proveedor.AutoSize = true;
            this.Lbl_Proveedor.Location = new System.Drawing.Point(22, 34);
            this.Lbl_Proveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Proveedor.Name = "Lbl_Proveedor";
            this.Lbl_Proveedor.Size = new System.Drawing.Size(92, 20);
            this.Lbl_Proveedor.TabIndex = 7;
            this.Lbl_Proveedor.Text = "Proveedor";
            // 
            // Pnl_AccionesNota
            // 
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Cancelar);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Anular);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Editar);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Guardar);
            this.Pnl_AccionesNota.Controls.Add(this.Btn_Nuevo);
            this.Pnl_AccionesNota.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_AccionesNota.Location = new System.Drawing.Point(28, 557);
            this.Pnl_AccionesNota.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_AccionesNota.Name = "Pnl_AccionesNota";
            this.Pnl_AccionesNota.Size = new System.Drawing.Size(1038, 75);
            this.Pnl_AccionesNota.TabIndex = 3;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(705, 18);
            this.Btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(125, 38);
            this.Btn_Cancelar.TabIndex = 6;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Anular
            // 
            this.Btn_Anular.Location = new System.Drawing.Point(568, 18);
            this.Btn_Anular.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Anular.Name = "Btn_Anular";
            this.Btn_Anular.Size = new System.Drawing.Size(125, 38);
            this.Btn_Anular.TabIndex = 4;
            this.Btn_Anular.Text = "Anular";
            this.Btn_Anular.UseVisualStyleBackColor = true;
            this.Btn_Anular.Click += new System.EventHandler(this.Btn_Anular_Click);
            // 
            // Btn_Editar
            // 
            this.Btn_Editar.Location = new System.Drawing.Point(430, 18);
            this.Btn_Editar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Editar.Name = "Btn_Editar";
            this.Btn_Editar.Size = new System.Drawing.Size(125, 38);
            this.Btn_Editar.TabIndex = 3;
            this.Btn_Editar.Text = "Editar";
            this.Btn_Editar.UseVisualStyleBackColor = true;
            this.Btn_Editar.Click += new System.EventHandler(this.Btn_Editar_Click);
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.Location = new System.Drawing.Point(292, 18);
            this.Btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(125, 38);
            this.Btn_Guardar.TabIndex = 2;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = true;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Location = new System.Drawing.Point(155, 18);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(125, 38);
            this.Btn_Nuevo.TabIndex = 1;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Gpb_DetalleDevolucion
            // 
            this.Gpb_DetalleDevolucion.Controls.Add(this.Btn_Eliminar);
            this.Gpb_DetalleDevolucion.Controls.Add(this.Btn_Agregar);
            this.Gpb_DetalleDevolucion.Controls.Add(this.Dgv_DetalleDevolucion);
            this.Gpb_DetalleDevolucion.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Gpb_DetalleDevolucion.Location = new System.Drawing.Point(28, 250);
            this.Gpb_DetalleDevolucion.Name = "Gpb_DetalleDevolucion";
            this.Gpb_DetalleDevolucion.Size = new System.Drawing.Size(1035, 300);
            this.Gpb_DetalleDevolucion.TabIndex = 4;
            this.Gpb_DetalleDevolucion.TabStop = false;
            this.Gpb_DetalleDevolucion.Text = "Detalle de Productos Devueltos";
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Location = new System.Drawing.Point(293, 239);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(263, 40);
            this.Btn_Eliminar.TabIndex = 2;
            this.Btn_Eliminar.Text = "Eliminar Producto";
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(19, 239);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(263, 40);
            this.Btn_Agregar.TabIndex = 1;
            this.Btn_Agregar.Text = "Agregar Producto";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Dgv_DetalleDevolucion
            // 
            this.Dgv_DetalleDevolucion.AllowUserToAddRows = false;
            this.Dgv_DetalleDevolucion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_DetalleDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_DetalleDevolucion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_producto,
            this.producto,
            this.cantidad,
            this.preciounit,
            this.subtotal});
            this.Dgv_DetalleDevolucion.Location = new System.Drawing.Point(22, 31);
            this.Dgv_DetalleDevolucion.Name = "Dgv_DetalleDevolucion";
            this.Dgv_DetalleDevolucion.RowHeadersWidth = 51;
            this.Dgv_DetalleDevolucion.RowTemplate.Height = 24;
            this.Dgv_DetalleDevolucion.Size = new System.Drawing.Size(983, 202);
            this.Dgv_DetalleDevolucion.TabIndex = 0;
            // 
            // id_producto
            // 
            this.id_producto.HeaderText = "ID";
            this.id_producto.MinimumWidth = 6;
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto";
            this.producto.MinimumWidth = 6;
            this.producto.Name = "producto";
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad Devuelta";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            // 
            // preciounit
            // 
            this.preciounit.HeaderText = "Precio Unitario";
            this.preciounit.MinimumWidth = 6;
            this.preciounit.Name = "preciounit";
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // Frm_Devolucion_Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1109, 700);
            this.Controls.Add(this.Gpb_DetalleDevolucion);
            this.Controls.Add(this.Pnl_AccionesNota);
            this.Controls.Add(this.Gpb_DatosNota);
            this.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Devolucion_Proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Nota_CreditoDebito";
            this.Gpb_DatosNota.ResumeLayout(false);
            this.Gpb_DatosNota.PerformLayout();
            this.Pnl_AccionesNota.ResumeLayout(false);
            this.Gpb_DetalleDevolucion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_DetalleDevolucion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_DatosNota;
        private System.Windows.Forms.ComboBox Cbo_Factura;
        private System.Windows.Forms.Label Lbl_FacturaAfectada;
        private System.Windows.Forms.ComboBox Cbo_TipoDevolucion;
        private System.Windows.Forms.Label Lbl_Devolucion;
        private System.Windows.Forms.ComboBox Cbo_Proveedor;
        private System.Windows.Forms.Label Lbl_Proveedor;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.TextBox Txt_Motivo;
        private System.Windows.Forms.Label Lbl_Motivo;
        private System.Windows.Forms.TextBox Txt_Monto;
        private System.Windows.Forms.Label Lbl_Monto;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Panel Pnl_AccionesNota;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Anular;
        private System.Windows.Forms.Button Btn_Editar;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.GroupBox Gpb_DetalleDevolucion;
        private System.Windows.Forms.DataGridView Dgv_DetalleDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewComboBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciounit;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Btn_Eliminar;
    }
}
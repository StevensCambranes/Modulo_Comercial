
namespace Capa_Vista_Compras
{
    partial class Frm_Compras_Periodo
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
            this.Gpb_Filtros = new System.Windows.Forms.GroupBox();
            this.Lbl_FechaInicio = new System.Windows.Forms.Label();
            this.Dtp_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FechaFin = new System.Windows.Forms.Label();
            this.Dtp_FechaFin = new System.Windows.Forms.DateTimePicker();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Limpiar = new System.Windows.Forms.Button();
            this.Dtp_Filtro = new System.Windows.Forms.DateTimePicker();
            this.Lbl_FechaFiltro = new System.Windows.Forms.Label();
            this.Rdb_Mes = new System.Windows.Forms.RadioButton();
            this.Rdb_Dia = new System.Windows.Forms.RadioButton();
            this.Lbl_TituloFiltro = new System.Windows.Forms.Label();
            this.Gpb_Listado = new System.Windows.Forms.GroupBox();
            this.Dgv_Compras = new System.Windows.Forms.DataGridView();
            this.id_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pnl_Acciones = new System.Windows.Forms.Panel();
            this.Btn_Cerrar = new System.Windows.Forms.Button();
            this.Btn_Exportar = new System.Windows.Forms.Button();
            this.Txt_TotalCompras = new System.Windows.Forms.TextBox();
            this.Lbl_TotalCompras = new System.Windows.Forms.Label();
            this.Gpb_Filtros.SuspendLayout();
            this.Gpb_Listado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Compras)).BeginInit();
            this.Pnl_Acciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gpb_Filtros
            // 
            this.Gpb_Filtros.Controls.Add(this.Lbl_FechaInicio);
            this.Gpb_Filtros.Controls.Add(this.Dtp_FechaInicio);
            this.Gpb_Filtros.Controls.Add(this.Lbl_FechaFin);
            this.Gpb_Filtros.Controls.Add(this.Dtp_FechaFin);
            this.Gpb_Filtros.Controls.Add(this.Btn_Buscar);
            this.Gpb_Filtros.Controls.Add(this.Btn_Limpiar);
            this.Gpb_Filtros.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.Gpb_Filtros.Location = new System.Drawing.Point(25, 25);
            this.Gpb_Filtros.Name = "Gpb_Filtros";
            this.Gpb_Filtros.Size = new System.Drawing.Size(1037, 125);
            this.Gpb_Filtros.TabIndex = 0;
            this.Gpb_Filtros.TabStop = false;
            this.Gpb_Filtros.Text = "Filtro de Compras por Rango de Fechas";
            // 
            // Lbl_FechaInicio
            // 
            this.Lbl_FechaInicio.AutoSize = true;
            this.Lbl_FechaInicio.Location = new System.Drawing.Point(40, 55);
            this.Lbl_FechaInicio.Name = "Lbl_FechaInicio";
            this.Lbl_FechaInicio.Size = new System.Drawing.Size(109, 20);
            this.Lbl_FechaInicio.TabIndex = 0;
            this.Lbl_FechaInicio.Text = "Fecha Inicio:";
            // 
            // Dtp_FechaInicio
            // 
            this.Dtp_FechaInicio.Location = new System.Drawing.Point(160, 50);
            this.Dtp_FechaInicio.Name = "Dtp_FechaInicio";
            this.Dtp_FechaInicio.Size = new System.Drawing.Size(250, 27);
            this.Dtp_FechaInicio.TabIndex = 1;
            // 
            // Lbl_FechaFin
            // 
            this.Lbl_FechaFin.AutoSize = true;
            this.Lbl_FechaFin.Location = new System.Drawing.Point(440, 55);
            this.Lbl_FechaFin.Name = "Lbl_FechaFin";
            this.Lbl_FechaFin.Size = new System.Drawing.Size(89, 20);
            this.Lbl_FechaFin.TabIndex = 2;
            this.Lbl_FechaFin.Text = "Fecha Fin:";
            // 
            // Dtp_FechaFin
            // 
            this.Dtp_FechaFin.Location = new System.Drawing.Point(540, 50);
            this.Dtp_FechaFin.Name = "Dtp_FechaFin";
            this.Dtp_FechaFin.Size = new System.Drawing.Size(250, 27);
            this.Dtp_FechaFin.TabIndex = 3;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(810, 40);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(100, 40);
            this.Btn_Buscar.TabIndex = 4;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Location = new System.Drawing.Point(920, 40);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.Size = new System.Drawing.Size(100, 40);
            this.Btn_Limpiar.TabIndex = 5;
            this.Btn_Limpiar.Text = "Limpiar";
            this.Btn_Limpiar.UseVisualStyleBackColor = true;
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);
            // 
            // Dtp_Filtro
            // 
            this.Dtp_Filtro.Location = new System.Drawing.Point(496, 44);
            this.Dtp_Filtro.Margin = new System.Windows.Forms.Padding(4);
            this.Dtp_Filtro.Name = "Dtp_Filtro";
            this.Dtp_Filtro.Size = new System.Drawing.Size(249, 22);
            this.Dtp_Filtro.TabIndex = 4;
            // 
            // Lbl_FechaFiltro
            // 
            this.Lbl_FechaFiltro.AutoSize = true;
            this.Lbl_FechaFiltro.Location = new System.Drawing.Point(305, 50);
            this.Lbl_FechaFiltro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_FechaFiltro.Name = "Lbl_FechaFiltro";
            this.Lbl_FechaFiltro.Size = new System.Drawing.Size(147, 20);
            this.Lbl_FechaFiltro.TabIndex = 3;
            this.Lbl_FechaFiltro.Text = "Seleccione Fecha";
            // 
            // Rdb_Mes
            // 
            this.Rdb_Mes.AutoSize = true;
            this.Rdb_Mes.Location = new System.Drawing.Point(218, 47);
            this.Rdb_Mes.Margin = new System.Windows.Forms.Padding(4);
            this.Rdb_Mes.Name = "Rdb_Mes";
            this.Rdb_Mes.Size = new System.Drawing.Size(52, 22);
            this.Rdb_Mes.TabIndex = 2;
            this.Rdb_Mes.Text = "Mes";
            this.Rdb_Mes.UseVisualStyleBackColor = true;
            // 
            // Rdb_Dia
            // 
            this.Rdb_Dia.AutoSize = true;
            this.Rdb_Dia.Checked = true;
            this.Rdb_Dia.Location = new System.Drawing.Point(142, 47);
            this.Rdb_Dia.Margin = new System.Windows.Forms.Padding(4);
            this.Rdb_Dia.Name = "Rdb_Dia";
            this.Rdb_Dia.Size = new System.Drawing.Size(47, 22);
            this.Rdb_Dia.TabIndex = 1;
            this.Rdb_Dia.TabStop = true;
            this.Rdb_Dia.Text = "Dia";
            this.Rdb_Dia.UseVisualStyleBackColor = true;
            // 
            // Lbl_TituloFiltro
            // 
            this.Lbl_TituloFiltro.AutoSize = true;
            this.Lbl_TituloFiltro.Location = new System.Drawing.Point(25, 50);
            this.Lbl_TituloFiltro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_TituloFiltro.Name = "Lbl_TituloFiltro";
            this.Lbl_TituloFiltro.Size = new System.Drawing.Size(92, 20);
            this.Lbl_TituloFiltro.TabIndex = 0;
            this.Lbl_TituloFiltro.Text = "Filtrar por:";
            // 
            // Gpb_Listado
            // 
            this.Gpb_Listado.Controls.Add(this.Dgv_Compras);
            this.Gpb_Listado.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gpb_Listado.Location = new System.Drawing.Point(25, 175);
            this.Gpb_Listado.Margin = new System.Windows.Forms.Padding(4);
            this.Gpb_Listado.Name = "Gpb_Listado";
            this.Gpb_Listado.Padding = new System.Windows.Forms.Padding(4);
            this.Gpb_Listado.Size = new System.Drawing.Size(1037, 350);
            this.Gpb_Listado.TabIndex = 1;
            this.Gpb_Listado.TabStop = false;
            this.Gpb_Listado.Text = "Listado de Compras";
            // 
            // Dgv_Compras
            // 
            this.Dgv_Compras.AllowUserToAddRows = false;
            this.Dgv_Compras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Compras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_compra,
            this.proveedor,
            this.fecha,
            this.total,
            this.estado});
            this.Dgv_Compras.Location = new System.Drawing.Point(25, 37);
            this.Dgv_Compras.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_Compras.Name = "Dgv_Compras";
            this.Dgv_Compras.ReadOnly = true;
            this.Dgv_Compras.RowHeadersWidth = 51;
            this.Dgv_Compras.RowTemplate.Height = 24;
            this.Dgv_Compras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Compras.Size = new System.Drawing.Size(987, 275);
            this.Dgv_Compras.TabIndex = 0;
            // 
            // id_compra
            // 
            this.id_compra.HeaderText = "ID";
            this.id_compra.MinimumWidth = 6;
            this.id_compra.Name = "id_compra";
            this.id_compra.ReadOnly = true;
            // 
            // proveedor
            // 
            this.proveedor.HeaderText = "Proveedor";
            this.proveedor.MinimumWidth = 6;
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.MinimumWidth = 6;
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Total (Q)";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // Pnl_Acciones
            // 
            this.Pnl_Acciones.Controls.Add(this.Btn_Cerrar);
            this.Pnl_Acciones.Controls.Add(this.Btn_Exportar);
            this.Pnl_Acciones.Controls.Add(this.Txt_TotalCompras);
            this.Pnl_Acciones.Controls.Add(this.Lbl_TotalCompras);
            this.Pnl_Acciones.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_Acciones.Location = new System.Drawing.Point(25, 550);
            this.Pnl_Acciones.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_Acciones.Name = "Pnl_Acciones";
            this.Pnl_Acciones.Size = new System.Drawing.Size(1037, 100);
            this.Pnl_Acciones.TabIndex = 2;
            // 
            // Btn_Cerrar
            // 
            this.Btn_Cerrar.Location = new System.Drawing.Point(578, 25);
            this.Btn_Cerrar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Cerrar.Name = "Btn_Cerrar";
            this.Btn_Cerrar.Size = new System.Drawing.Size(125, 37);
            this.Btn_Cerrar.TabIndex = 3;
            this.Btn_Cerrar.Text = "Cerrar";
            this.Btn_Cerrar.UseVisualStyleBackColor = true;
            // 
            // Btn_Exportar
            // 
            this.Btn_Exportar.Location = new System.Drawing.Point(375, 25);
            this.Btn_Exportar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Exportar.Name = "Btn_Exportar";
            this.Btn_Exportar.Size = new System.Drawing.Size(196, 37);
            this.Btn_Exportar.TabIndex = 2;
            this.Btn_Exportar.Text = "Exportar Reporte";
            this.Btn_Exportar.UseVisualStyleBackColor = true;
            // 
            // Txt_TotalCompras
            // 
            this.Txt_TotalCompras.Location = new System.Drawing.Point(217, 27);
            this.Txt_TotalCompras.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_TotalCompras.Name = "Txt_TotalCompras";
            this.Txt_TotalCompras.ReadOnly = true;
            this.Txt_TotalCompras.Size = new System.Drawing.Size(149, 27);
            this.Txt_TotalCompras.TabIndex = 1;
            this.Txt_TotalCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_TotalCompras
            // 
            this.Lbl_TotalCompras.AutoSize = true;
            this.Lbl_TotalCompras.Location = new System.Drawing.Point(25, 31);
            this.Lbl_TotalCompras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_TotalCompras.Name = "Lbl_TotalCompras";
            this.Lbl_TotalCompras.Size = new System.Drawing.Size(148, 20);
            this.Lbl_TotalCompras.TabIndex = 0;
            this.Lbl_TotalCompras.Text = "Total de Compras";
            // 
            // Frm_Compras_Periodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1078, 734);
            this.Controls.Add(this.Pnl_Acciones);
            this.Controls.Add(this.Gpb_Listado);
            this.Controls.Add(this.Gpb_Filtros);
            this.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Compras_Periodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Compras_Periodo";
            this.Gpb_Filtros.ResumeLayout(false);
            this.Gpb_Filtros.PerformLayout();
            this.Gpb_Listado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Compras)).EndInit();
            this.Pnl_Acciones.ResumeLayout(false);
            this.Pnl_Acciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gpb_Filtros;
        private System.Windows.Forms.DateTimePicker Dtp_Filtro;
        private System.Windows.Forms.Label Lbl_FechaFiltro;
        private System.Windows.Forms.RadioButton Rdb_Mes;
        private System.Windows.Forms.RadioButton Rdb_Dia;
        private System.Windows.Forms.Label Lbl_TituloFiltro;
        private System.Windows.Forms.Button Btn_Limpiar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.GroupBox Gpb_Listado;
        private System.Windows.Forms.DataGridView Dgv_Compras;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.Panel Pnl_Acciones;
        private System.Windows.Forms.Button Btn_Cerrar;
        private System.Windows.Forms.Button Btn_Exportar;
        private System.Windows.Forms.TextBox Txt_TotalCompras;
        private System.Windows.Forms.Label Lbl_TotalCompras;
        private System.Windows.Forms.Label Lbl_FechaInicio;
        private System.Windows.Forms.Label Lbl_FechaFin;
        private System.Windows.Forms.DateTimePicker Dtp_FechaInicio;
        private System.Windows.Forms.DateTimePicker Dtp_FechaFin;
    }
}
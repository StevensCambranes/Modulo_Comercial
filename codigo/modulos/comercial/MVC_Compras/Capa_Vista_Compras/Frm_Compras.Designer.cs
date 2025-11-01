
namespace Capa_Vista_Compras
{
     partial class Frm_Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Compras));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Btn_Orden = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Btn_FacturaProveedor = new System.Windows.Forms.ToolStripButton();
            this.Btn_Devolucion = new System.Windows.Forms.ToolStripButton();
            this.Btn_Reporte = new System.Windows.Forms.ToolStripButton();
            this.Btn_Contabilidad = new System.Windows.Forms.ToolStripButton();
            this.Btn_Salir = new System.Windows.Forms.ToolStripButton();
            this.Pnl_Contenido = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_Orden,
            this.toolStripButton1,
            this.Btn_FacturaProveedor,
            this.Btn_Devolucion,
            this.Btn_Reporte,
            this.Btn_Contabilidad,
            this.Btn_Salir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1082, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "tool_Compras";
            // 
            // Btn_Orden
            // 
            this.Btn_Orden.Name = "Btn_Orden";
            this.Btn_Orden.Size = new System.Drawing.Size(156, 24);
            this.Btn_Orden.Text = "Orden de Compra";
            this.Btn_Orden.Click += new System.EventHandler(this.Btn_Orden_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(114, 24);
            this.toolStripButton1.Text = "Proveedores";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Btn_FacturaProveedor
            // 
            this.Btn_FacturaProveedor.Name = "Btn_FacturaProveedor";
            this.Btn_FacturaProveedor.Size = new System.Drawing.Size(166, 24);
            this.Btn_FacturaProveedor.Text = "Facturas Proveedor";
            this.Btn_FacturaProveedor.Click += new System.EventHandler(this.Btn_FacturaProveedor_Click);
            // 
            // Btn_Devolucion
            // 
            this.Btn_Devolucion.Name = "Btn_Devolucion";
            this.Btn_Devolucion.Size = new System.Drawing.Size(208, 24);
            this.Btn_Devolucion.Text = "Devolucion Proveedores";
            this.Btn_Devolucion.Click += new System.EventHandler(this.Btn_Devolucion_Click);
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(175, 24);
            this.Btn_Reporte.Text = "Reporte de Compras";
            this.Btn_Reporte.Click += new System.EventHandler(this.Btn_Reporte_Click);
            // 
            // Btn_Contabilidad
            // 
            this.Btn_Contabilidad.Name = "Btn_Contabilidad";
            this.Btn_Contabilidad.Size = new System.Drawing.Size(176, 24);
            this.Btn_Contabilidad.Text = "Envio a Contabilidad";
            this.Btn_Contabilidad.Click += new System.EventHandler(this.Btn_Contabilidad_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Btn_Salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(48, 24);
            this.Btn_Salir.Text = "Salir";
            // 
            // Pnl_Contenido
            // 
            this.Pnl_Contenido.BackColor = System.Drawing.SystemColors.Control;
            this.Pnl_Contenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Contenido.Location = new System.Drawing.Point(0, 27);
            this.Pnl_Contenido.Margin = new System.Windows.Forms.Padding(4);
            this.Pnl_Contenido.Name = "Pnl_Contenido";
            this.Pnl_Contenido.Size = new System.Drawing.Size(1082, 626);
            this.Pnl_Contenido.TabIndex = 1;
            // 
            // Frm_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.Pnl_Contenido);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Rockwell", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Orden_Compra";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Btn_Orden;
        private System.Windows.Forms.ToolStripButton Btn_FacturaProveedor;
        private System.Windows.Forms.ToolStripButton Btn_Devolucion;
        private System.Windows.Forms.ToolStripButton Btn_Reporte;
        private System.Windows.Forms.ToolStripButton Btn_Contabilidad;
        private System.Windows.Forms.ToolStripButton Btn_Salir;
        private System.Windows.Forms.Panel Pnl_Contenido;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
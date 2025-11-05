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
        private Cls_Controlador_DevolucionProveedor controlador = new Cls_Controlador_DevolucionProveedor();
        public Frm_Devolucion_Proveedores()
        {
            InitializeComponent();
            CargarProveedores();
            Cbo_TipoDevolucion.Items.AddRange(new string[] { "Devolucion Total", "Devolucion Parcial" });
            Txt_Monto.Text = "0.00";
        }

        private void CargarProveedores()
        {
            Cbo_Proveedor.DataSource = controlador.ObtenerProveedores();
            Cbo_Proveedor.DisplayMember = "Cmp_Nombre_Proveedor";
            Cbo_Proveedor.ValueMember = "Cmp_Id_Proveedor";
            Cbo_Proveedor.SelectedIndex = -1;
        }


        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            // ================= NUEVA DEVOLUCIÓN =================
            Cbo_Proveedor.SelectedIndex = -1;
            Cbo_Factura.SelectedIndex = -1;
            Cbo_TipoDevolucion.SelectedIndex = -1;
            Dtp_Fecha.Value = DateTime.Today;
            Txt_Monto.Text = "0.00";
            Txt_Motivo.Clear();

            CambiarModoEdicion(true);
            MessageBox.Show("Formulario listo para nueva devolución.", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

        private void Cbo_Factura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_Factura.SelectedIndex == -1)
                return;

            int idFactura;
            if (Cbo_Factura.SelectedValue is DataRowView drv)
                idFactura = Convert.ToInt32(drv["Cmp_Id_Factura_Proveedor"]);
            else
                idFactura = Convert.ToInt32(Cbo_Factura.SelectedValue);

            DataTable productos = controlador.ObtenerProductosDeFactura(idFactura);

            Dgv_DetalleDevolucion.Rows.Clear();
            foreach (DataRow row in productos.Rows)
            {
                int n = Dgv_DetalleDevolucion.Rows.Add();
                Dgv_DetalleDevolucion.Rows[n].Cells["id_producto"].Value = row["ID"].ToString();
                Dgv_DetalleDevolucion.Rows[n].Cells["producto"].Value = row["Producto"].ToString();
                Dgv_DetalleDevolucion.Rows[n].Cells["preciounit"].Value = Convert.ToDecimal(row["Precio_Unitario"]).ToString("0.00");
                Dgv_DetalleDevolucion.Rows[n].Cells["cantidad"].Value = row["Cantidad"].ToString();
                Dgv_DetalleDevolucion.Rows[n].Cells["subtotal"].Value = Convert.ToDecimal(row["Subtotal"]).ToString("0.00");
            }

            // Recalcula el monto total de devolución
            decimal total = productos.AsEnumerable().Sum(r => r.Field<decimal>("Subtotal"));
            Txt_Monto.Text = total.ToString("0.00");

        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            // ================= GUARDAR DEVOLUCIÓN =================
            if (Cbo_Proveedor.SelectedIndex == -1 || Cbo_Factura.SelectedIndex == -1 || Cbo_TipoDevolucion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar proveedor, factura y tipo de devolución.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProveedor = Convert.ToInt32(Cbo_Proveedor.SelectedValue);
            int idFactura = Convert.ToInt32(Cbo_Factura.SelectedValue);
            string tipo = Cbo_TipoDevolucion.Text;
            DateTime fecha = Dtp_Fecha.Value;
            string motivo = Txt_Motivo.Text;
            decimal monto = Convert.ToDecimal(Txt_Monto.Text);
            int idUsuario = 1; // Usuario temporal

            int idDevolucion = controlador.GuardarDevolucion(idProveedor, idFactura, tipo, fecha, motivo, monto, idUsuario);

            foreach (DataGridViewRow fila in Dgv_DetalleDevolucion.Rows)
            {
                int idProducto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                decimal cantidad = Convert.ToDecimal(fila.Cells["cantidad"].Value);
                decimal precio = Convert.ToDecimal(fila.Cells["preciounit"].Value);
                controlador.GuardarDetalleYActualizarInventario(idDevolucion, idProducto, cantidad, precio);
            }

            MessageBox.Show("Devolución guardada correctamente y existencias actualizadas.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CambiarModoEdicion(false);
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
            Cbo_TipoDevolucion.Enabled = habilitar;
            Dtp_Fecha.Enabled = habilitar;
            Txt_Motivo.ReadOnly = !habilitar;
            Txt_Monto.ReadOnly = !habilitar;
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            // ================= AGREGAR PRODUCTO =================
            if (Dgv_DetalleDevolucion.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para ingresar datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = Dgv_DetalleDevolucion.CurrentRow;

            string id = Convert.ToString(fila.Cells["id_producto"].Value)?.Trim();
            string producto = Convert.ToString(fila.Cells["producto"].Value)?.Trim();
            string strCantidad = Convert.ToString(fila.Cells["cantidad"].Value)?.Trim();
            string strPrecio = Convert.ToString(fila.Cells["preciounit"].Value)?.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(producto))
            {
                MessageBox.Show("Debe ingresar el ID y nombre del producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(strCantidad, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(strPrecio, out decimal precioUnitario) || precioUnitario <= 0)
            {
                MessageBox.Show("Precio inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = cantidad * precioUnitario;
            fila.Cells["subtotal"].Value = subtotal.ToString("0.00");

            RecalcularTotal();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            // ================= ELIMINAR PRODUCTO =================
            if (Dgv_DetalleDevolucion.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una línea para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dgv_DetalleDevolucion.Rows.RemoveAt(Dgv_DetalleDevolucion.CurrentRow.Index);
            RecalcularTotal();
        }

        // ================= REACCIONAR A EDICIÓN =================
        private void Dgv_DetalleDevolucion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = Dgv_DetalleDevolucion.Rows[e.RowIndex];
            if (!int.TryParse(fila.Cells["cantidad"].Value?.ToString(), out int cantidad)) cantidad = 0;
            if (!decimal.TryParse(fila.Cells["preciounit"].Value?.ToString(), out decimal precio)) precio = 0.00m;

            fila.Cells["subtotal"].Value = (cantidad * precio).ToString("0.00");
            RecalcularTotal();
        }

        // ================= RECALCULAR TOTAL =================
        private void RecalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in Dgv_DetalleDevolucion.Rows)
            {
                if (fila.Cells["subtotal"].Value != null && decimal.TryParse(fila.Cells["subtotal"].Value.ToString(), out decimal sub))
                    total += sub;
            }
            Txt_Monto.Text = total.ToString("0.00");
        }

        private void Cbo_Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_Proveedor.SelectedIndex == -1)
                return;

            int idProveedor;
            if (Cbo_Proveedor.SelectedValue is DataRowView drv)
                idProveedor = Convert.ToInt32(drv["Cmp_Id_Proveedor"]);
            else
                idProveedor = Convert.ToInt32(Cbo_Proveedor.SelectedValue);

            Cbo_Factura.DataSource = controlador.ObtenerFacturasPorProveedor(idProveedor);
            Cbo_Factura.DisplayMember = "Cmp_Numero_Factura";
            Cbo_Factura.ValueMember = "Cmp_Id_Factura_Proveedor";
            Cbo_Factura.SelectedIndex = -1;
        }
    }
}

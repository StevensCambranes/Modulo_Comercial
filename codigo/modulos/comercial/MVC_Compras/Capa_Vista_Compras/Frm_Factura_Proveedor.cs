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
    public partial class Frm_Factura_Proveedor : Form
    {
        private Cls_Controlador_FacturaProveedor controlador = new Cls_Controlador_FacturaProveedor();
        public Frm_Factura_Proveedor()
        {
            InitializeComponent();
            controlador = new Cls_Controlador_FacturaProveedor();
            CargarProveedores();
            CargarOrdenesCompra();
            Txt_TotalFactura.Text = "0.00";
        }

        private void CargarProveedores()
        {
            Cbo_Proveedor.DataSource = controlador.ObtenerProveedores();
            Cbo_Proveedor.DisplayMember = "Cmp_Nombre_Proveedor";
            Cbo_Proveedor.ValueMember = "Cmp_Id_Proveedor";
            Cbo_Proveedor.SelectedIndex = -1;
        }

        private void CargarOrdenesCompra()
        {
            Cbo_OrdenCompra.DataSource = controlador.ObtenerOrdenesCompra();
            Cbo_OrdenCompra.DisplayMember = "Numero_OC";
            Cbo_OrdenCompra.ValueMember = "Cmp_Id_OC";
            Cbo_OrdenCompra.SelectedIndex = -1;
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            // ================= NUEVA FACTURA =================
            Cbo_Proveedor.SelectedIndex = -1;
            Cbo_OrdenCompra.SelectedIndex = -1;
            Dtp_FechaFactura.Value = DateTime.Today;
            Txt_Numerofactura.Clear();
            Txt_TotalFactura.Text = "0.00";
            Dgv_DetalleFactura.Rows.Clear();

            CambiarModoEdicion(true);
            MessageBox.Show("Formulario listo para nueva factura.", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            // ================= AGREGAR PRODUCTO =================
            if (Dgv_DetalleFactura.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para ingresar datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = Dgv_DetalleFactura.CurrentRow;

            string id = Convert.ToString(fila.Cells["id_prducto"].Value)?.Trim();
            string producto = Convert.ToString(fila.Cells["producto"].Value)?.Trim();
            string strCantidad = Convert.ToString(fila.Cells["cantidad"].Value)?.Trim();
            string strPrecio = Convert.ToString(fila.Cells["preciounit"].Value)?.Trim();

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(producto))
            {
                MessageBox.Show("Debe ingresar el ID y nombre del producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(strCantidad, out decimal cantidad) || cantidad <= 0)
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

            CalcularTotalFactura();

        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            // ================= ELIMINAR PRODUCTO =================
            if (Dgv_DetalleFactura.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una línea para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dgv_DetalleFactura.Rows.Remove(Dgv_DetalleFactura.CurrentRow);
            CalcularTotalFactura();
        }

        private void CalcularTotalFactura()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in Dgv_DetalleFactura.Rows)
            {
                if (fila.Cells["subtotal"].Value != null &&
                    decimal.TryParse(fila.Cells["subtotal"].Value.ToString(), out decimal sub))
                {
                    total += sub;
                }
            }
            Txt_TotalFactura.Text = total.ToString("0.00");
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (Cbo_Proveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Txt_Numerofactura.Text))
            {
                MessageBox.Show("Ingrese el número de factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Dgv_DetalleFactura.Rows.Count == 0)
            {
                MessageBox.Show("Agregue productos antes de guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProveedor = Convert.ToInt32(Cbo_Proveedor.SelectedValue);
            DateTime fecha = Dtp_FechaFactura.Value;
            string numero = Txt_Numerofactura.Text;
            decimal total = Convert.ToDecimal(Txt_TotalFactura.Text);
            int idUsuario = 1; // temporal (se puede pasar luego el usuario actual)

            try
            {
                int idFactura = controlador.GuardarFactura(idProveedor, fecha, numero, total, idUsuario);

                foreach (DataGridViewRow fila in Dgv_DetalleFactura.Rows)
                {
                    int idProducto = Convert.ToInt32(fila.Cells["id_prducto"].Value);
                    decimal cantidad = Convert.ToDecimal(fila.Cells["cantidad"].Value);
                    decimal precio = Convert.ToDecimal(fila.Cells["preciounit"].Value);
                    controlador.GuardarDetalleFactura(idFactura, idProducto, cantidad, precio);
                }

                MessageBox.Show("Factura registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CambiarModoEdicion(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la factura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            // ================= EDITAR FACTURA =================
            var confirmar = MessageBox.Show("¿Desea habilitar la edición de esta factura?", "Editar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                CambiarModoEdicion(true);
            }
        }

        private void Btn_Anular_Click(object sender, EventArgs e)
        {
            // ================= ANULAR FACTURA =================
            var confirmar = MessageBox.Show("¿Desea anular esta factura?", "Anular", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar == DialogResult.Yes)
            {
                CambiarModoEdicion(false);
            }
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            // ================= CANCELAR =================
            var confirmar = MessageBox.Show("¿Desea cancelar y cerrar el formulario?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
                this.Close();
        }

        // ================= FUNCIONES AUXILIARES =================
        private void CambiarModoEdicion(bool habilitar)
        {
            Cbo_Proveedor.Enabled = habilitar;
            Cbo_OrdenCompra.Enabled = habilitar;
            Dtp_FechaFactura.Enabled = habilitar;
            Txt_Numerofactura.ReadOnly = !habilitar;
            Dgv_DetalleFactura.ReadOnly = !habilitar;
            Btn_Agregar.Enabled = habilitar;
            Btn_Eliminar.Enabled = habilitar;
        }

        private void Cbo_OrdenCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_OrdenCompra.SelectedIndex == -1)
                return;

            int idOrden;

            // Manejar DataRowView o int
            if (Cbo_OrdenCompra.SelectedValue is DataRowView drv)
                idOrden = Convert.ToInt32(drv["Cmp_Id_OC"]);
            else
                idOrden = Convert.ToInt32(Cbo_OrdenCompra.SelectedValue);

            DataTable productos = controlador.ObtenerProductosPorOrden(idOrden);
            DataTable listaProductos = controlador.ObtenerTodosLosProductos();

            DataGridViewComboBoxColumn comboProd = (DataGridViewComboBoxColumn)Dgv_DetalleFactura.Columns["producto"];
            comboProd.DataSource = listaProductos;
            comboProd.DisplayMember = "Producto";
            comboProd.ValueMember = "ID";
            comboProd.FlatStyle = FlatStyle.Flat;

            Dgv_DetalleFactura.Rows.Clear();

            foreach (DataRow row in productos.Rows)
            {
                int n = Dgv_DetalleFactura.Rows.Add();
                Dgv_DetalleFactura.Rows[n].Cells["id_prducto"].Value = row["ID"].ToString();
                Dgv_DetalleFactura.Rows[n].Cells["producto"].Value = row["ID"];
                Dgv_DetalleFactura.Rows[n].Cells["cantidad"].Value = row["Cantidad"].ToString();
                Dgv_DetalleFactura.Rows[n].Cells["preciounit"].Value = Convert.ToDecimal(row["Precio_Unitario"]).ToString("0.00");
                Dgv_DetalleFactura.Rows[n].Cells["subtotal"].Value = Convert.ToDecimal(row["Subtotal"]).ToString("0.00");
            }

            Txt_TotalFactura.Text = productos.AsEnumerable().Sum(r => r.Field<decimal>("Subtotal")).ToString("0.00");
        }
    }
}

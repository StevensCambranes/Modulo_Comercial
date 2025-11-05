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
    public partial class Frm_Orden_Compra : Form
    {
        private readonly Cls_Controlador_OrdenCompra controlador = new Cls_Controlador_OrdenCompra();

        public Frm_Orden_Compra()
        {
            InitializeComponent();
            CargarProveedores();
            CargarCondicionesPago();
            CargarProductosEnTabla();
            Txt_Estado.Text = "Pendiente";
            Txt_Total.Text = "0.00";
        }

        // ============================
        // MÉTODOS DE CARGA DE DATOS
        // ============================
        private void CargarProveedores()
        {
            Cbo_Proveedor.DataSource = controlador.ObtenerProveedores();
            Cbo_Proveedor.DisplayMember = "Value";
            Cbo_Proveedor.ValueMember = "Key";
        }

        private void CargarCondicionesPago()
        {
            var lista = controlador.ObtenerCondicionesPago();
            Cbo_CondicionPago.DataSource = lista;
            Cbo_CondicionPago.DisplayMember = "Value";
            Cbo_CondicionPago.ValueMember = "Key";
        }

       // private void CargarProductos()
       // {
          //  var productos = controlador.ObtenerProductos();

          ///  var comboProd = (DataGridViewComboBoxColumn)Dgv_Detalle.Columns["producto"];
          //  comboProd.DataSource = productos;
          //  comboProd.DisplayMember = "Value"; // lo visible: nombre + categoría
          //  comboProd.ValueMember = "Key";     // el ID del producto en la BD
          //  comboProd.FlatStyle = FlatStyle.Flat;
        //}

        // ============================
        // BOTONES PRINCIPALES
        // ============================
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            Dgv_Detalle.Rows.Clear();
            Txt_Total.Text = "0.00";
            Txt_Estado.Text = "Pendiente";
            MessageBox.Show("Formulario listo para nueva orden.", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_AgregarProduc_Click(object sender, EventArgs e)
        {
            Dgv_Detalle.Rows.Add();
        }

        private void Btn_EliminarProduc_Click(object sender, EventArgs e)
        {
            if (Dgv_Detalle.CurrentRow != null)
                Dgv_Detalle.Rows.Remove(Dgv_Detalle.CurrentRow);
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProveedor = (int)Cbo_Proveedor.SelectedValue;
                int idCondicion = (int)Cbo_CondicionPago.SelectedValue;
                DateTime fecha = Dtp_Fecha.Value;
                string observaciones = "Generada desde formulario de compras";
                decimal total = CalcularTotalOrden();
                int idUsuario = 1; // Temporal, luego lo enlazamos con el usuario logueado

                int idOrden = controlador.GuardarOrdenCompra(idProveedor, idCondicion, fecha, observaciones, total, idUsuario);

                foreach (DataGridViewRow fila in Dgv_Detalle.Rows)
                {
                    if (fila.Cells["producto"].Value != null)
                    {
                        int idProd = Convert.ToInt32(fila.Cells["producto"].Value);
                        decimal cantidad = Convert.ToDecimal(fila.Cells["cantidad"].Value);
                        decimal precio = Convert.ToDecimal(fila.Cells["precio_unit"].Value);
                        decimal subtotal = cantidad * precio;

                        controlador.GuardarDetalleOrden(idOrden, idProd, cantidad, precio, subtotal);
                    }
                }

                Txt_Total.Text = total.ToString("F2");
                Txt_Estado.Text = "Pendiente";
                MessageBox.Show("✅ Orden de compra guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la orden: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        // CÁLCULOS Y EVENTOS DE TABLA
        // ============================
        private decimal CalcularTotalOrden()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in Dgv_Detalle.Rows)
            {
                if (fila.Cells["cantidad"].Value != null && fila.Cells["precio_unit"].Value != null)
                {
                    decimal cantidad = Convert.ToDecimal(fila.Cells["cantidad"].Value);
                    decimal precio = Convert.ToDecimal(fila.Cells["precio_unit"].Value);
                    total += cantidad * precio;
                }
            }
            return total;
        }

        private void Dgv_Detalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Dgv_Detalle.Columns["cantidad"].Index ||
                e.ColumnIndex == Dgv_Detalle.Columns["precio_unit"].Index)
            {
                var fila = Dgv_Detalle.Rows[e.RowIndex];
                if (fila.Cells["cantidad"].Value != null && fila.Cells["precio_unit"].Value != null)
                {
                    decimal cantidad = Convert.ToDecimal(fila.Cells["cantidad"].Value);
                    decimal precio = Convert.ToDecimal(fila.Cells["precio_unit"].Value);
                    decimal subtotal = cantidad * precio;
                    fila.Cells["subtotal"].Value = subtotal;
                }
                Txt_Total.Text = CalcularTotalOrden().ToString("F2");
            }
        }

        // ============================
        // BOTONES DE ESTADO
        // ============================
        private void Btn_Aprobar_Click(object sender, EventArgs e)
        {
            if (Txt_Estado.Text == "Anulada")
            {
                MessageBox.Show("No puede aprobar una orden anulada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Txt_Estado.Text == "Aprobada")
            {
                MessageBox.Show("La orden ya fue aprobada anteriormente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Txt_Estado.Text = "Aprobada";
            MessageBox.Show("Orden aprobada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Anular_Click(object sender, EventArgs e)
        {
            if (Txt_Estado.Text == "Aprobada")
            {
                MessageBox.Show("No puede anular una orden ya aprobada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Txt_Estado.Text = "Anulada";
            MessageBox.Show("Orden de compra anulada correctamente.", "Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la operación actual?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        // ============================
        // EDICIÓN
        // ============================
        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            if (Txt_Estado.Text == "Aprobada" || Txt_Estado.Text == "Anulada")
            {
                MessageBox.Show("No puede editar una orden aprobada o anulada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Txt_Estado.Text == "Pendiente")
            {
                MessageBox.Show("Debe guardar la orden antes de editarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea habilitar la edición de esta orden?", "Editar Orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            CambiarModoEdicion(true);
            Txt_Estado.Text = "En Edición";
            MessageBox.Show("Edición habilitada. Puede modificar los datos de la orden.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CambiarModoEdicion(bool habilitar)
        {
            Cbo_Proveedor.Enabled = habilitar;
            Dtp_Fecha.Enabled = habilitar;
            Dgv_Detalle.ReadOnly = !habilitar;
            Btn_AgregarProduc.Enabled = habilitar;
            Btn_EliminarProduc.Enabled = habilitar;
        }

        private void CargarProductosEnTabla()
        {
            DataTable productos = controlador.ObtenerProductosTabla();

            // Limpiar cualquier fila previa
            Dgv_Detalle.Rows.Clear();

            // Llenar el DataGridView con los productos del inventario
            foreach (DataRow fila in productos.Rows)
            {
                int id = Convert.ToInt32(fila["ID"]);
                string nombre = fila["Producto"].ToString();
                decimal cantidad = Convert.ToDecimal(fila["Cantidad"]);
                decimal precio = Convert.ToDecimal(fila["Precio_Unitario"]);
                decimal subtotal = Convert.ToDecimal(fila["Subtotal"]);

                Dgv_Detalle.Rows.Add(id, nombre, cantidad, precio, subtotal);
            }
        }
    }
}

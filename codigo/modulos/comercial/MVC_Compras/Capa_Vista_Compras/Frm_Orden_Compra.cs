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
        private Cls_Controlador_Compras _controlador;
        public Frm_Orden_Compra()
        {
            InitializeComponent();
            _controlador = new Cls_Controlador_Compras();

            // Estado inicial
            Txt_Estado.Text = "Pendiente";
            Txt_Total.Text = "0.00";
        }

        private void Btn_AgregarProduc_Click(object sender, EventArgs e)
        {
            // Obtener datos desde el DataGridView (fila nueva)
            if (Dgv_Detalle.CurrentRow == null)
            {
                MessageBox.Show("No hay fila seleccionada para ingresar datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = Dgv_Detalle.CurrentRow;

            string id = Convert.ToString(fila.Cells["id_producto"].Value)?.Trim();
            string producto = Convert.ToString(fila.Cells["producto"].Value)?.Trim();
            string strCantidad = Convert.ToString(fila.Cells["cantidad"].Value)?.Trim();
            string strPrecio = Convert.ToString(fila.Cells["precio_unit"].Value)?.Trim();

            // Validaciones
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
                MessageBox.Show("Precio unitario inválido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registrar línea en controlador
            var datos = _controlador.AgregarLinea(id, producto, cantidad, precioUnitario);

            // Reflejar subtotal
            fila.Cells["subtotal"].Value = datos.subtotal.ToString("0.00");

            // Recalcular total
            Txt_Total.Text = _controlador.CalcularTotal().ToString("0.00");

            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

        private void Btn_EliminarProduc_Click(object sender, EventArgs e)
        {
            if (Dgv_Detalle.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rowIndex = Dgv_Detalle.CurrentRow.Index;
            _controlador.QuitarLinea(rowIndex);
            Dgv_Detalle.Rows.RemoveAt(rowIndex);
            Txt_Total.Text = _controlador.CalcularTotal().ToString("0.00");
    }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            Cbo_Proveedor.SelectedIndex = -1;
            Dtp_Fecha.Value = DateTime.Today;
            Txt_Estado.Text = "Pendiente";
            Txt_Total.Text = "0.00";
            Dgv_Detalle.Rows.Clear();

            MessageBox.Show("Formulario listo para nueva orden.", "Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            CambiarModoEdicion(false);
            Txt_Estado.Text = "Guardada";
            // Validaciones básicas
            if (Cbo_Proveedor.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Dgv_Detalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la orden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación de registro (a futuro conexión BD)
            MessageBox.Show("Orden de compra guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Txt_Estado.Text = "Guardada";
        }

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
            MessageBox.Show("Orden aprobada y enviada a inventario.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var confirmar = MessageBox.Show("¿Desea cancelar la operación actual?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            CambiarModoEdicion(true);
            Txt_Estado.Text = "En Edición";
            // Si la orden está aprobada o anulada, no se puede editar
            if (Txt_Estado.Text == "Aprobada" || Txt_Estado.Text == "Anulada")
            {
                MessageBox.Show("No puede editar una orden aprobada o anulada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si la orden no está guardada, no hay nada que editar
            if (Txt_Estado.Text == "Pendiente")
            {
                MessageBox.Show("Debe guardar la orden antes de editarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmar
            var confirmar = MessageBox.Show("¿Desea habilitar la edición de esta orden?", "Editar Orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.No) return;

            // Habilitar edición
            Cbo_Proveedor.Enabled = true;
            Dtp_Fecha.Enabled = true;
            Dgv_Detalle.ReadOnly = false;
            Btn_AgregarProduc.Enabled = true;
            Btn_EliminarProduc.Enabled = true;
            Btn_Guardar.Enabled = true;

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
    }
}

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
    public partial class Frm_Proveedor : Form
    {
        private Cls_Controlador_Proveedor controlador = new Cls_Controlador_Proveedor();
        public Frm_Proveedor()
        {
            InitializeComponent();

            CargarProveedores();
        }

        private void CargarProveedores()
        {
            Dgv_Proveedores.Rows.Clear();
            var lista = controlador.ObtenerProveedores();

            foreach (var p in lista)
            {
                Dgv_Proveedores.Rows.Add(p[0], p[1], p[2], p[3], p[4], p[5]);
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_Nombre.Text) ||
                string.IsNullOrWhiteSpace(Txt_NIT.Text))
            {
                MessageBox.Show("Debe llenar al menos el nombre y NIT del proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controlador.GuardarProveedor(Txt_Nombre.Text, Txt_NIT.Text, Txt_Direccion.Text, Txt_Telefono.Text, Txt_Correo.Text);
            MessageBox.Show("Proveedor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarProveedores();
            LimpiarCampos();
        }

        private void Btn_Editar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_IdProveedor.Text)) return;

            controlador.ActualizarProveedor(
                int.Parse(Txt_IdProveedor.Text),
                Txt_Nombre.Text,
                Txt_NIT.Text,
                Txt_Direccion.Text,
                Txt_Telefono.Text,
                Txt_Correo.Text
            );

            MessageBox.Show("Proveedor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarProveedores();
            LimpiarCampos();
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_IdProveedor.Text)) return;

            controlador.EliminarProveedor(int.Parse(Txt_IdProveedor.Text));
            MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarProveedores();
            LimpiarCampos();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void Dgv_Proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Txt_IdProveedor.Text = Dgv_Proveedores.Rows[e.RowIndex].Cells["id"].Value.ToString();
                Txt_Nombre.Text = Dgv_Proveedores.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                Txt_NIT.Text = Dgv_Proveedores.Rows[e.RowIndex].Cells["nit"].Value.ToString();
                Txt_Direccion.Text = Dgv_Proveedores.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                Txt_Telefono.Text = Dgv_Proveedores.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                Txt_Correo.Text = Dgv_Proveedores.Rows[e.RowIndex].Cells["correo"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            Txt_IdProveedor.Clear();
            Txt_Nombre.Clear();
            Txt_NIT.Clear();
            Txt_Direccion.Clear();
            Txt_Telefono.Clear();
            Txt_Correo.Clear();
        }
    }
}

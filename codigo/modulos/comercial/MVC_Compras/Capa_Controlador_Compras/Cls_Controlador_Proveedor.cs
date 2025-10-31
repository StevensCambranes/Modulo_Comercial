using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo_Compras;

namespace Capa_Controlador_Compras
{
    public class Cls_Controlador_Proveedor
    {
        private Cls_Modelo_Proveedor modelo = new Cls_Modelo_Proveedor();

        public void GuardarProveedor(string nombre, string nit, string direccion, string telefono, string correo)
        {
            modelo.InsertarProveedor(nombre, nit, direccion, telefono, correo);
        }

        public List<string[]> ObtenerProveedores()
        {
            return modelo.ObtenerProveedores();
        }

        public void ActualizarProveedor(int id, string nombre, string nit, string direccion, string telefono, string correo)
        {
            modelo.ActualizarProveedor(id, nombre, nit, direccion, telefono, correo);
        }

        public void EliminarProveedor(int id)
        {
            modelo.EliminarProveedor(id);
        }
    }
}

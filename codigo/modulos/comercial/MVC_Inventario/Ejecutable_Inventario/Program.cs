using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Vista_Inventario;

namespace Ejecutable_Inventario
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD:codigo/modulos/comercial/Exe_Comercial/Program.cs
//      Application.Run(new Frm_Compras());
            Application.Run(new Frm_Factura());

=======
            Application.Run(new Frm_Inventario_Historico());
>>>>>>> 5bccbb2fc3729c72aca5f347638423b804a9a5eb:codigo/modulos/comercial/MVC_Inventario/Ejecutable_Inventario/Program.cs
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class FormulariosHelper
    {
        public static void AbrirFormulario<T>(Form mdiParent) where T : Form, new()
        {
            // Buscar si el formulario ya está abierto
            var formularioExistente = mdiParent.MdiChildren
                                               .OfType<T>()
                                               .FirstOrDefault();

            if (formularioExistente != null)
            {
                formularioExistente.BringToFront();
            }
            else
            {
                T nuevoFormulario = new T
                {
                    MdiParent = mdiParent,
                    WindowState = FormWindowState.Maximized
                };
                nuevoFormulario.Show();
            }
        }
    }
}

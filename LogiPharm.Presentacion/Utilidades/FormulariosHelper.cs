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
                // Restaurar y traer al frente si ya está abierto
                formularioExistente.WindowState = FormWindowState.Maximized;
                formularioExistente.BringToFront();
            }
            else
            {
                try
                {
                    // Minimizar los demás formularios hijos abiertos
                    foreach (Form child in mdiParent.MdiChildren)
                    {
                        child.WindowState = FormWindowState.Minimized;
                    }

                    // Crear y mostrar el nuevo formulario
                    T nuevoFormulario = new T
                    {
                        MdiParent = mdiParent,
                        WindowState = FormWindowState.Maximized
                    };
                    nuevoFormulario.Show();
                    nuevoFormulario.BringToFront();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el formulario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

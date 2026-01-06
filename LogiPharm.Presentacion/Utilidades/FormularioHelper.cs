using System;
using System.Windows.Forms;

namespace LogiPharm.Presentacion.Utilidades
{
    /// <summary>
    /// Clase helper con métodos útiles para configurar formularios
    /// </summary>
    public static class FormularioHelper
    {
        /// <summary>
        /// Habilita el cierre del formulario con la tecla ESC
        /// </summary>
        /// <param name="form">Formulario al que aplicar la funcionalidad</param>
        /// <param name="confirmarSiTieneDatos">Si es true, pide confirmación antes de cerrar</param>
        /// <param name="validarDatos">Función opcional para verificar si hay datos que perder</param>
        public static void HabilitarCierreConEsc(
            this Form form, 
            bool confirmarSiTieneDatos = false,
            Func<bool> validarDatos = null)
        {
            form.KeyPreview = true;
            form.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    bool tieneDatos = validarDatos?.Invoke() ?? false;
                    
                    if (confirmarSiTieneDatos && tieneDatos)
                    {
                        var result = MessageBox.Show(
                            "Hay datos sin guardar. ¿Seguro que deseas salir?",
                            "Confirmar Salida",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        
                        if (result == DialogResult.Yes)
                        {
                            if (form.Modal)
                            {
                                form.DialogResult = DialogResult.Cancel;
                            }
                            form.Close();
                        }
                    }
                    else
                    {
                        if (form.Modal)
                        {
                            form.DialogResult = DialogResult.Cancel;
                        }
                        form.Close();
                    }
                }
            };
        }

        /// <summary>
        /// Habilita un atajo de teclado personalizado en el formulario
        /// </summary>
        /// <param name="form">Formulario al que aplicar el atajo</param>
        /// <param name="tecla">Tecla del atajo (ej: Keys.F12)</param>
        /// <param name="accion">Acción a ejecutar cuando se presione la tecla</param>
        /// <param name="modificador">Modificador opcional (ej: Keys.Control)</param>
        public static void AgregarAtajoTeclado(
            this Form form,
            Keys tecla,
            Action accion,
            Keys modificador = Keys.None)
        {
            form.KeyPreview = true;
            form.KeyDown += (sender, e) =>
            {
                bool modificadorCorrecto = modificador == Keys.None || e.Modifiers == modificador;
                
                if (e.KeyCode == tecla && modificadorCorrecto)
                {
                    e.Handled = true;
                    accion?.Invoke();
                }
            };
        }

        /// <summary>
        /// Configura comportamiento estándar de formulario modal
        /// </summary>
        /// <param name="form">Formulario a configurar</param>
        public static void ConfigurarComoModal(this Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
        }

        /// <summary>
        /// Centra un formulario en la pantalla
        /// </summary>
        public static void CentrarEnPantalla(this Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.FromControl(form);
            form.Location = new System.Drawing.Point(
                screen.WorkingArea.Left + (screen.WorkingArea.Width - form.Width) / 2,
                screen.WorkingArea.Top + (screen.WorkingArea.Height - form.Height) / 2
            );
        }
    }
}

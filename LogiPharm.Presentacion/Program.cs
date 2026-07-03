using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Inicializar la base de datos de forma automática (crear catálogos faltantes si no existen)
            CapaDatos.Conexion.InicializarBaseDatos();

            Application.Run(new FrmLogin());
        }
    }
}

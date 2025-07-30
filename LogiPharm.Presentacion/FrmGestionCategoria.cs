using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmGestionCategoria : Form
    {
        public FrmGestionCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- 1. Validar la entrada ---
            if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
            {
                MessageBox.Show("El nombre de la categoría es un campo obligatorio.",
                                "Validación Fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtNombreCategoria.Focus(); // Pone el cursor en el campo que falta
                return; // Detiene la ejecución del método
            }

            // --- 2. Lógica para guardar en la Base de Datos (AQUÍ VA TU CÓDIGO) ---
            // Aquí es donde llamarías a tu capa de negocio o de datos para
            // insertar o actualizar la categoría.
            //
            // Ejemplo:
            // CategoriaNegocio negocio = new CategoriaNegocio();
            // bool exito = negocio.Guardar(txtNombreCategoria.Text, txtDescripcion.Text);
            //
            // if(exito) { ... }

            // --- 3. Mostrar mensaje de éxito ---
            MessageBox.Show("Categoría guardada correctamente.",
                            "Operación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // --- 4. Cerrar el formulario con un resultado positivo ---
            // Esto le indica al formulario principal (FrmProductos) que la operación fue exitosa
            // y que puede proceder a actualizar sus datos (como recargar la lista de categorías).
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Simplemente cierra el formulario sin hacer nada.
            // Opcionalmente, puedes preguntar al usuario si está seguro.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}

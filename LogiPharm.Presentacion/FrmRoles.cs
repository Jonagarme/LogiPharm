using LogiPharm.Datos;
using LogiPharm.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmRoles : Form
    {
        public FrmRoles()
        {
            InitializeComponent();
            this.Load += FrmRoles_Load;
        }

        private void FrmRoles_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarPermisos();
        }

        private void CargarPermisosDePrueba()
        {
            // Limpiar el árbol de permisos
            treePermisos.Nodes.Clear();

            // --- Módulo de Ventas ---
            TreeNode ventasNode = new TreeNode("Ventas y Recetas");
            ventasNode.Nodes.Add(new TreeNode("Punto de Venta (POS)"));
            ventasNode.Nodes.Add(new TreeNode("Facturación"));
            ventasNode.Nodes.Add(new TreeNode("Devoluciones"));
            ventasNode.Nodes.Add(new TreeNode("Cotizaciones"));
            treePermisos.Nodes.Add(ventasNode);

            // --- Módulo de Inventario ---
            TreeNode inventarioNode = new TreeNode("Inventario y Medicamentos");
            inventarioNode.Nodes.Add(new TreeNode("Productos"));
            inventarioNode.Nodes.Add(new TreeNode("Ajuste de Inventario"));
            inventarioNode.Nodes.Add(new TreeNode("Kardex por Producto"));
            treePermisos.Nodes.Add(inventarioNode);

            // --- Módulo de Compras ---
            TreeNode comprasNode = new TreeNode("Compras y Proveedores");
            comprasNode.Nodes.Add(new TreeNode("Recepción de Productos"));
            comprasNode.Nodes.Add(new TreeNode("Facturas de Compra"));
            comprasNode.Nodes.Add(new TreeNode("Proveedores"));
            treePermisos.Nodes.Add(comprasNode);

            // --- Módulo de Administración ---
            TreeNode adminNode = new TreeNode("Administración");
            adminNode.Nodes.Add(new TreeNode("Usuarios"));
            adminNode.Nodes.Add(new TreeNode("Roles y Permisos"));
            adminNode.Nodes.Add(new TreeNode("Cierre de Caja"));
            treePermisos.Nodes.Add(adminNode);

            // Expandir todos los nodos para ver los permisos
            treePermisos.ExpandAll();
        }

        private void CargarRoles()
        {
            try
            {
                DRoles d_Roles = new DRoles();
                DataTable dt = d_Roles.ListarRolesActivos();

                dgvRoles.DataSource = dt;
                if (dgvRoles.Columns.Count > 0)
                {
                    dgvRoles.Columns["id"].Visible = false;
                    dgvRoles.Columns["nombre"].HeaderText = "Rol";
                    dgvRoles.Columns["nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // En tu FrmRoles.cs, dentro del evento Click del botón Guardar

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRol.Text))
            {
                MessageBox.Show("El nombre del rol es obligatorio.");
                return;
            }

            try
            {
                // 1. Crea un nuevo objeto ERol con los datos del formulario
                ERol nuevoRol = new ERol
                {
                    Nombre = txtNombreRol.Text,
                    Descripcion = txtDescripcion.Text,
                    CreadoPor = 1 // TODO: Reemplazar con el ID del usuario actual de la sesión
                };

                // 2. Llama al método de la capa de datos para insertarlo
                DRoles d_Roles = new DRoles();
                if (d_Roles.InsertarRol(nuevoRol))
                {
                    MessageBox.Show("Rol guardado exitosamente.");
                    // 3. Actualiza la lista de roles en la pantalla
                    CargarRoles();
                    //LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPermisos()
        {
            try
            {
                treePermisos.Nodes.Clear();

                DRoles dPermisos = new DRoles();
                DataTable dtPermisos = dPermisos.ListarPermisosActivos();

                // Puedes agrupar por módulos si usas un campo "modulo" en la tabla permisos
                // De lo contrario, aquí se muestran todos al mismo nivel:
                foreach (DataRow row in dtPermisos.Rows)
                {
                    // Muestra nombre y opcionalmente descripción
                    TreeNode node = new TreeNode(row["nombre"].ToString());
                    node.Tag = row["id"]; // Guarda el ID para futuras operaciones
                    treePermisos.Nodes.Add(node);
                }

                treePermisos.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombreRol.Clear();
            txtDescripcion.Clear();
            // Desmarcar todos los permisos
            foreach (TreeNode node in treePermisos.Nodes)
            {
                node.Checked = false;
                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = false;
                }
            }
            txtNombreRol.Focus();
        }
    }
}

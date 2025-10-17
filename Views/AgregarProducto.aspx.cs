using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen.Views
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        ProductoDAO productoDAO = new ProductoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Producto producto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = float.Parse(txtPrecio.Text),

                    CantidadStock = int.Parse(txtCantidad.Text),
                    RegistradoPor = "Admin" // En un escenario real, esto debería ser el usuario autenticado
                };
                if (ddlCategorias.SelectedValue == "")
                {
                    producto.Categoria = null;
                }
                else
                {
                    producto.Categoria = ddlCategorias.SelectedValue;
                }
                int resultado = productoDAO.CrearProducto(producto);
                if (resultado > 0)
                {
                    MostrarMensaje("Producto agregado exitosamente.", false);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al agregar producto: " + ex.Message, true);
            }
        }
        private void DesactivarValidadores()
        {
            rfvCantidad.Enabled = false;
            cvCantidadTipo.Enabled = false;
            cvCantidadValor.Enabled = false;
            rfvNombre.Enabled = false;
            rfvPrecio.Enabled = false;
            cvPrecioValor.Enabled = false;
            cvPrecioTipo.Enabled = false;
            rfvCategoria.Enabled = false;
        }
        private void ActivarValidadores()
        {
            rfvCantidad.Enabled = true;
            cvCantidadTipo.Enabled = true;
            cvCantidadValor.Enabled = true;
            rfvNombre.Enabled = true;
            rfvPrecio.Enabled = true;
            cvPrecioValor.Enabled = true;
            cvPrecioTipo.Enabled = true;
            rfvCategoria.Enabled = true;
        }
        public void btnLimpiar_Click(object sender, EventArgs e)
        {
            DesactivarValidadores();
            txtCantidad.Text = "";
            ddlCategorias.SelectedIndex = 0;
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            lblMensaje.Text = "";
            ActivarValidadores();

        }
        private void MostrarMensaje(string mensaje, bool esError)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = esError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
        public void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
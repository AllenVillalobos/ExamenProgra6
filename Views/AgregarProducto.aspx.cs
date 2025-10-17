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
        /// <summary>
        /// Se crea una instancia de ProductoDAO para interactuar con la base de datos
        /// </summary>
        ProductoDAO productoDAO = new ProductoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ///<summary>
        ///Procedimiento que se ejecuta al hacer clic en el botón "Agregar"
        ///Agrega un nuevo producto a la base de datos utilizando los datos ingresados en el formulario
        /// </summary>
        /// <exception cref="Exception">Captura cualquier excepción que ocurra durante el proceso y muestra un mensaje de error</exception>"
        public void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                Producto producto = new Producto
                {
                    Nombre = string.IsNullOrEmpty(txtDescripcion.Text) ?  null : txtDescripcion.Text,
                    Descripcion = string.IsNullOrEmpty(txtDescripcion.Text) ? null : txtDescripcion.Text,
                    Precio = float.Parse(txtPrecio.Text),
                    CantidadStock = Convert.ToInt32(txtCantidad.Text),
                    RegistradoPor = "Admin" 
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

        /// <summary>
        /// Procedimiento para desactivar los validadores del formulario
        /// Esto es útil para limpiar el formulario sin que los validadores interfieran
        /// </summary>
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

        /// <summary>
        /// Procedimiento para activar los validadores del formulario
        /// Una vez que el formulario ha sido limpiado, los validadores se reactivan
        /// </summary>
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

        /// <summary>
        /// Procedimiento que se ejecuta al hacer clic en el botón "Limpiar"
        /// Se encarga de limpiar todos los campos del formulario
        /// </summary>
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

        /// <summary>
        /// Procedimiento para mostrar mensajes al usuario
        /// Dependiendo del tipo de mensaje (error o éxito), el color del texto cambia
        /// Y se muestra el mensaje 
        /// </summary>
        private void MostrarMensaje(string mensaje, bool esError)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = esError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        /// <summary>
        /// Procedimiento que se ejecuta al hacer clic en el botón "Volver"
        /// Sirve para redirigir al usuario de vuelta al Index.aspx
        /// </summary>
        public void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
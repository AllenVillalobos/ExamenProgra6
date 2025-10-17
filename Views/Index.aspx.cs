using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen.Views
{
    public partial class Index : System.Web.UI.Page
    {
        /// <summary>
        /// Se crea una instancia de ProductoDAO para interactuar con la base de datos
        /// </summary>
        ProductoDAO productoDAO = new ProductoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            /// <summary>
            /// Se carga la lista de productos al cargar la página por primera vez
            /// </summary>
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        ///<summary>
        ///Procedimiento que se ejecuta al hacer clic en el botón "Actualizar"
        ///Serve para actualizar un producto existente en la base de datos utilizando los datos del formulario
        ///</summary>
        ///<exception cref="Exception">Captura cualquier excepción que ocurra durante el proceso y muestra un mensaje de error</exception>"
        public void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {

                Producto producto = new Producto
                {
                    ProductoID = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = float.Parse(txtPrecio.Text),
                    CantidadStock = int.Parse(txtCantidad.Text),
                    ModificadoPor = "Admin" // En un escenario real, esto debería ser el usuario autenticado
                };
                if (ddlCategorias.SelectedValue == "")
                {
                    producto.Categoria = null;
                }
                else
                {
                    producto.Categoria = ddlCategorias.SelectedValue;
                }
                int resultado = productoDAO.ActualizarProducto(producto);
                if (resultado > 0)
                {
                    MostrarMensaje("Producto actualizado exitosamente.", false);
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al actualizar producto: " + ex.Message, true);
            }
        }

        ///<summary>
        ///Procedimiento que se ejecuta al hacer clic en el botón "Eliminar"
        ///Elimina un producto existente en la base de datos utilizando el ID del producto ingresado en el formulario o seleccionado en la tabla
        ///</summary>
        ///<exception cref="Exception">Captura cualquier excepción que ocurra durante el proceso y muestra un mensaje de error</exception>
        public void btnEliminar_Click(object sender, EventArgs e)
        {
            DesactivarValidadoresSinID();
            try
            {
                int productoID = int.Parse(txtID.Text);
                int resultado = productoDAO.EliminarProducto(productoID);
                if (resultado > 0)
                {
                    MostrarMensaje("Producto eliminado exitosamente.", false);
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al eliminar producto: " + ex.Message, true);
            }
            ActivarValidadoresSinID();
        }

        ///<summary>
        ///Procedimiento que se ejecuta al hacer clic en el botón "Consultar"
        ///Su función es buscar un producto en la base de datos utilizando el ID del producto ingresado en el formulario
        ///</summary>
        ///<exception cref="Exception">Captura cualquier excepción que ocurra durante el proceso y muestra un mensaje de error</exception>"
        public void btnConsultar_Click(object sender, EventArgs e)
        {
            DesactivarValidadoresSinID();
            try
            {
                int productoID = int.Parse(txtID.Text);
                var producto = productoDAO.ListarProducto(productoID);
                if (producto.Rows.Count > 0)
                {
                    gvProductos.DataSource = producto;
                    gvProductos.DataBind();
                    MostrarMensaje("Producto encontrado.", false);
                }
                else
                {
                    // Redirección simple (ruta virtual)
                    Response.Redirect("AgregarProducto.aspx");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al consultar producto: " + ex.Message, true);
            }
            ActivarValidadoresSinID();
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
        /// Procedimiento para activar los validadores del formulario excepto los del ID
        /// Esto se usa en los procedimientos de eliminar y consultar para evitar que los validadores interfieran
        /// </summary>
        private void DesactivarValidadoresSinID()
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
        /// Procedimiento para activar los validadores del formulario excepto los del ID
        /// Después de eliminar o consultar, los validadores se reactivan
        /// </summary>
        private void ActivarValidadoresSinID()
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
        /// Procedimiento para activar los validadores del formulario
        /// Se usan en los procedimientos de limpiar y consultar para evitar que los validadores interfieran
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
            rfvID.Enabled = false;
            cvIDTipo.Enabled = false;
            cvIDValor.Enabled = false;

        }

        /// <summary>
        /// Procedimiento para activar los validadores del formulario
        /// Una vez que el formulario ha sido limpiado o la consulta ha sido realizada, los validadores se reactivan
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
            rfvID.Enabled = true;
            cvIDTipo.Enabled = true;
            cvIDValor.Enabled = true;

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
            txtID.Text = "";
            CargarProductos();
            ActivarValidadores();

        }

        /// <summary>
        /// Procedimiento para cargar la lista de productos en el GridView
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                gvProductos.DataSource = productoDAO.ListarProductos();
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar productos: " + ex.Message, true);
            }
        }

        /// <summary>
        /// Procedimiento que se ejecuta al seleccionar una fila en el GridView
        /// Funciona para cargar los datos del producto seleccionado en el formulario para su edición o eliminación
        /// </summary>
        /// <exception cref="Exception">Captura cualquier excepción que ocurra durante el proceso y muestra un mensaje de error</exception>
        public void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var row = productoDAO.ListarProducto(Convert.ToInt32(gvProductos.SelectedDataKey.Value));
                if (row.Rows.Count > 0)
                {
                    txtID.Text = row.Rows[0]["ProductoID"].ToString();
                    txtNombre.Text = row.Rows[0]["Nombre"].ToString();
                    txtDescripcion.Text = row.Rows[0]["Descripcion"].ToString();
                    txtPrecio.Text = row.Rows[0]["Precio"].ToString();
                    txtCantidad.Text = row.Rows[0]["CantidadStock"].ToString();
                    ddlCategorias.SelectedValue = row.Rows[0]["Categoria"].ToString();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al seleccionar producto: " + ex.Message, true);
            }
        }
    }
}
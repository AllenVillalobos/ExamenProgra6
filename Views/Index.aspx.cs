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
        ProductoDAO productoDAO = new ProductoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }
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
        private void MostrarMensaje(string mensaje, bool esError)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = esError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
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
        public void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
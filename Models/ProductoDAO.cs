using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class ProductoDAO
    {
        private readonly string connectionString;
        public ProductoDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }
        public DataTable ListarProductos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spListarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable ListarProducto(int ID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spListarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pProductoID", ID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public int CrearProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spCrearProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pNombre", producto.Nombre);
                    command.Parameters.AddWithValue("@pDescripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@pPrecio", producto.Precio);
                    command.Parameters.AddWithValue("@pCantidadStock", producto.CantidadStock);
                    command.Parameters.AddWithValue("@pCategoria", producto.Categoria);
                    command.Parameters.AddWithValue("@pRegistradoPor", producto.RegistradoPor);
                    try
                    {
                        connection.Open();
                        var resultado = command.ExecuteScalar();
                        if (resultado == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(resultado);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al abrir la conexión a la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public int ActualizarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spActualizarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pProductoID", producto.ProductoID);
                    command.Parameters.AddWithValue("@pNombre", producto.Nombre);
                    command.Parameters.AddWithValue("@pDescripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@pPrecio", producto.Precio);
                    command.Parameters.AddWithValue("@pCantidadStock", producto.CantidadStock);
                    command.Parameters.AddWithValue("@pCategoria", producto.Categoria);
                    command.Parameters.AddWithValue("@pModificadoPor", producto.ModificadoPor);
                    try
                    {
                        connection.Open();
                        var resultado = command.ExecuteScalar();
                        if (resultado == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(resultado);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al abrir la conexión a la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        public int EliminarProducto(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("spEliminarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pProductoID", ID);
                    try
                    {
                        connection.Open();
                        var resultado = command.ExecuteScalar();
                        if (resultado == null)
                        {
                            return 0;
                        }
                        else
                        {
                            return Convert.ToInt32(resultado);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al abrir la conexión a la base de datos: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
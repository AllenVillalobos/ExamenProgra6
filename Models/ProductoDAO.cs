using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    /// <summary>
    ///  Clase para acceder a la base de datos y realizar operaciones CRUD sobre la tabla Producto
    /// </summary>
    public class ProductoDAO
    {
        /// <summary>
        /// Establece la cadena de conexión a la base de datos
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Constructor que inicializa la cadena de conexión desde el archivo de configuración
        /// </summary>
        public ProductoDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        }
        /// <summary>
        /// Método para listar todos los productos en la base de datos
        /// </summary>
        /// <returns>Retorna un DataTable con todos los productos</returns>
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
        /// <summary>
        /// Método para listar un producto específico por su ID
        /// </summary>
        /// <param name="ID">Representa el ID del producto a buscar</param>
        /// <returns>Retorna un DataTable con un producto específico</returns>
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
        /// <summary>
        /// Método para crear un nuevo producto en la base de datos
        /// </summary>
        /// <param name="producto">Representa el nuevo producto a crear</param>
        /// <returns>Retorna un numero mayor 0 cuando se crea un nuevo producto, en caso contrario retorna 0</returns>
        /// <exception cref="Exception">En caso que algun fallo succeda durante la ejecución</exception>
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
        /// <summary>
        /// Método para actualizar un producto existente en la base de datos
        /// </summary>
        /// <param name="producto">Representa el producto a actualizar</param>
        /// <returns>Retorna un numero mayor 0 cuando se actualiza un producto, en caso contrario retorna 0</returns>
        /// <exception cref="Exception">En caso que algun fallo succeda durante la ejecución</exception>"
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
        /// <summary>
        /// Método para eliminar un producto de la base de datos
        /// </summary>
        /// <param name="ID">Representa el ID del producto a eliminar</param>
        /// <returns>Retorna un numero mayor 0 cuando se elimina un producto, en caso contrario retorna 0</returns>
        /// <exception cref="Exception">En caso que algun fallo succeda durante la ejecución</exception>"
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
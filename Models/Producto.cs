using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    /// <summary>
    /// Representa la tabla Producto en la base de datos
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Representa la clave primaria del producto
        /// </summary>
        public int ProductoID { get; set; }
        /// <summary>
        /// Representa el nombre del producto
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Representa la descripción del producto
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Representa el precio del producto
        /// </summary>
        public float Precio { get; set; }
        /// <summary>
        /// Representa la cantidad en stock del producto
        /// </summary>
        public int CantidadStock { get; set; }
        /// <summary>
        /// Representa la categoría del producto
        /// </summary>
        public string Categoria { get; set; }
        /// <summary>
        /// Indica la fecha en que el producto fue registrado
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Indica el usuario que registró el producto
        /// </summary>
        public string RegistradoPor { get; set; }
        /// <summary>
        /// Indica la fecha de la última modificación del producto
        /// </summary>
        public DateTime FechaModificacion { get; set; }
        /// <summary>
        /// Indica el usuario que realizó la última modificación del producto
        /// </summary>
        public string ModificadoPor { get; set; }
    }
}
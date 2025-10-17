using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int CantidadStock { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string RegistradoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string ModificadoPor { get; set; }
    }
}
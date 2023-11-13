using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProyecto.Entities
{
    public class ProductoEnt
    {
        public long ConProducto { get; set; }
        public string Nombre { get; set; }
        public long ConModelo { get; set; }
        public string DescripcionModelo { get; set; }
        public long ConMarca { get; set; }
        public string DescripcionMarca { get; set; }
        public long ConCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public decimal Precio { get; set; }
        public long Stock { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProyecto.Entities
{
    public class CarritoEnt
    {
        public long ConCarrito { get; set; }
        public long ConUsuario { get; set; }
        public long ConProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCarrito { get; set; }

        public int Precio { get; set; }

    } 
}
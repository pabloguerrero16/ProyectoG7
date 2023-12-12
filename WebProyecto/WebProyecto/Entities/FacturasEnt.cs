using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProyecto.Entities
{
    public class FacturasEnt
    {
        public long ConMaestro {  get; set; }
        public long ConUsuario { get; set; }
        public decimal TotalFactura { get; set; }
        public DateTime FechaCompra {  get; set; }
        public decimal PrecioCompra { get; set; }
        public int CantidadCompra { get; set; }
        public decimal Impuesto { get; set; }
        public string Nombre { get; set; }
        public string Marca {  get; set; }
        public string Modelo { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ImpuestoTotal { get; set; }
        public decimal Total { get; set; }
    }
}
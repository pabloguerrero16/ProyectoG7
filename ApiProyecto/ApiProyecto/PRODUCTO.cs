//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiProyecto
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.CARRITO = new HashSet<CARRITO>();
            this.DETALLE = new HashSet<DETALLE>();
        }
    
        public long ConProducto { get; set; }
        public Nullable<long> ConModelo { get; set; }
        public Nullable<long> ConMarca { get; set; }
        public Nullable<long> ConCategoria { get; set; }
        public decimal Precio { get; set; }
        public long Stock { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITO> CARRITO { get; set; }
        public virtual CATEGORIA CATEGORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE> DETALLE { get; set; }
        public virtual MARCA MARCA { get; set; }
        public virtual MODELO MODELO { get; set; }
    }
}

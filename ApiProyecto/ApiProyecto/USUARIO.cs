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
    
    public partial class USUARIO
    {
        public long ConUsuario { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public Nullable<long> ConRol { get; set; }
        public Nullable<long> ConProvincia { get; set; }
        public Nullable<long> ConCanton { get; set; }
    
        public virtual CANTON CANTON { get; set; }
        public virtual PROVINCIA PROVINCIA { get; set; }
        public virtual Rol Rol { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ProyectoG7Entities : DbContext
    {
        public ProyectoG7Entities()
            : base("name=ProyectoG7Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CANTON> CANTON { get; set; }
        public virtual DbSet<CARRITO> CARRITO { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<DETALLE> DETALLE { get; set; }
        public virtual DbSet<MAESTRO> MAESTRO { get; set; }
        public virtual DbSet<MARCA> MARCA { get; set; }
        public virtual DbSet<MODELO> MODELO { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<PROVINCIA> PROVINCIA { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    
        public virtual ObjectResult<ConsultarProductos_Result> ConsultarProductos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarProductos_Result>("ConsultarProductos");
        }
    
        public virtual ObjectResult<IniciarSesion_Result> IniciarSesion(string correo, string contrasenna)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<IniciarSesion_Result>("IniciarSesion", correoParameter, contrasennaParameter);
        }
    
        public virtual int PagarCarrito_SP(Nullable<long> conUsuario)
        {
            var conUsuarioParameter = conUsuario.HasValue ?
                new ObjectParameter("ConUsuario", conUsuario) :
                new ObjectParameter("ConUsuario", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PagarCarrito_SP", conUsuarioParameter);
        }
    
        public virtual int RegistrarCuenta(string cedula, string nombre, string correo, string contrasenna)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasennaParameter = contrasenna != null ?
                new ObjectParameter("Contrasenna", contrasenna) :
                new ObjectParameter("Contrasenna", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegistrarCuenta", cedulaParameter, nombreParameter, correoParameter, contrasennaParameter);
        }
    }
}

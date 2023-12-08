﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProyecto.Entities
{
    public class UsuarioEnt
    {
        public long ConUsuario { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public string DescripcionRol { get; set; }
        public long ConProvincia { get; set; }
        public string DescripcionProvincia { get; set; }
        public long ConCanton { get; set; }
        public string DescripcionCanton { get; set; }
        public long ConRol { get; set; }
        public string Imagen { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivaMenteWebApp.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Avatar { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int PuntosTotales { get; set; }

        public Persona Persona{ get; set; }
        public Usuario() { 
        Persona = new Persona();
        }
    }

}
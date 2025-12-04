using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivaMenteWebApp.Entities
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Email { get; set; }
    }

}
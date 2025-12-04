using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivaMenteWebApp.Entities
{
    public class Nivel
    {
        public int IdNivel { get; set; }
        public int IdJuego { get; set; }
        public int NumeroNivel { get; set; }
        public string Dificultad { get; set; }

        public Juego Juego { get; set; }
    }

}
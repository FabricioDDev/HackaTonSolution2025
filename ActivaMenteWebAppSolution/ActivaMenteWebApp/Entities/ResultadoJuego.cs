using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivaMenteWebApp.Entities
{
    public class ResultadoJuego
    {
        public int IdResultado { get; set; }
        public int IdUsuario { get; set; }
        public int IdJuego { get; set; }
        public int IdNivel { get; set; }
        public int PuntajeObtenido { get; set; }
        public DateTime Fecha { get; set; }

        public Usuario Usuario { get; set; }
        public Juego Juego { get; set; }
        public Nivel Nivel { get; set; }
    }

}
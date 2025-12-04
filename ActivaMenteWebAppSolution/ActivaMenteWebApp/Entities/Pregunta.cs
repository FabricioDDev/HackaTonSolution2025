using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivaMenteWebApp.Entities
{
    public class Pregunta
    {
        public int IdPregunta { get; set; }
        public int IdJuego { get; set; }
        public int IdNivel { get; set; }
        public int IdCategoria { get; set; }
        public string Texto { get; set; }
        public string Opcion1 { get; set; }
        public string Opcion2 { get; set; }
        public string Opcion3 { get; set; }
        public string Opcion4 { get; set; }
        public int OpcionCorrecta { get; set; }

        public Juego Juego { get; set; }
        public Nivel Nivel { get; set; }
        public Categoria Categoria { get; set; }
    }

}
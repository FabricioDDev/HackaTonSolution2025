using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using Data;

namespace Business
{
    public class PreguntaBLL
    {
        private readonly PreguntaDAO dao = new PreguntaDAO();

        public List<Pregunta> ObtenerPreguntas(int idGame, int level)
        {
            return dao.ObtenerPreguntas(idGame, level);
        }
    }
}

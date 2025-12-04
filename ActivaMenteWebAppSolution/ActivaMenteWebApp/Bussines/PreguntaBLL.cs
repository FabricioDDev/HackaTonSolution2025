using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using Data;

namespace Business
{
    public class PreguntaBLL
    {
        private readonly PreguntaDAO dao = new PreguntaDAO();

        public List<Pregunta> GetByNivel(int idNivel)
        {
            if (idNivel <= 0)
                throw new Exception("Nivel inválido");

            return dao.GetByNivel(idNivel);
        }
    }
}

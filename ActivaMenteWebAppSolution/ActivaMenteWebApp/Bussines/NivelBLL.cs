using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using Data;

namespace Business
{
    public class NivelBLL
    {
        private readonly NivelDAO dao = new NivelDAO();

        public List<Nivel> GetByJuego(int idJuego)
        {
            if (idJuego <= 0)
                throw new Exception("Juego inválido");

            return dao.GetByJuego(idJuego);
        }
    }
}

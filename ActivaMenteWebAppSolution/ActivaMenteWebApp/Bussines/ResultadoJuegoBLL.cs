using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using Data;

namespace Business
{
    public class ResultadoJuegoBLL
    {
        private readonly ResultadoJuegoDAO dao = new ResultadoJuegoDAO();

       public void RegistrarResultado(ResultadoJuego r)
        {
            if (r.IdUsuario <= 0 || r.IdJuego <= 0 || r.IdNivel <= 0)
                throw new Exception("Datos inválidos");

            dao.Insert(r);
        }

        public List<ResultadoJuego> GetHistorial(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("Usuario inválido");

            return dao.GetByUser(idUsuario);
        }
    }
}

using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using Data;

namespace Business
{
    public class JuegoBLL
    {
        private readonly JuegoDAO dao = new JuegoDAO();

        public List<Juego> GetAll()
        {
            return dao.GetAll();
        }
    }
}

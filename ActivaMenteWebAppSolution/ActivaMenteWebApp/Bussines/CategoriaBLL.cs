using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using Data;

namespace Business
{
    public class CategoriaBLL
    {
        private readonly CategoriaDAO dao = new CategoriaDAO();

        public List<Categoria> GetAll()
        {
            return dao.GetAll();
        }
    }
}

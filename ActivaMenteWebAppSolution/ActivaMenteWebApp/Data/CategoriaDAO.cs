using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class CategoriaDAO
    {
        public List<Categoria> GetAll()
        {
            List<Categoria> list = new List<Categoria>();
            DataAccess db = new DataAccess();

            try
            {
                db.Query("SELECT id_categoria, nombre, descripcion FROM Categoria");
                db.Read();

                while (db.Reader.Read())
                {
                    Categoria c = new Categoria
                    {
                        IdCategoria = (int)db.Reader["id_categoria"],
                        Nombre = db.Reader["nombre"].ToString(),
                        Descripcion = db.Reader["descripcion"].ToString()
                    };
                    list.Add(c);
                }
                return list;
            }
            finally { db.Close(); }
        }
    }
}

using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class JuegoDAO
    {
        public List<Juego> GetAll()
        {
            List<Juego> list = new List<Juego>();
            DataAccess db = new DataAccess();

            try
            {
                db.Query("SELECT id_juego, nombre, descripcion FROM Juego");
                db.Read();

                while (db.Reader.Read())
                {
                    Juego j = new Juego
                    {
                        IdJuego = (int)db.Reader["id_juego"],
                        Nombre = db.Reader["nombre"].ToString(),
                        Descripcion = db.Reader["descripcion"].ToString()
                    };
                    list.Add(j);
                }
                return list;
            }
            finally { db.Close(); }
        }
    }
}

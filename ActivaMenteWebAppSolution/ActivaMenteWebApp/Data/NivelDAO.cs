using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class NivelDAO
    {
        public List<Nivel> GetByJuego(int idJuego)
        {
            List<Nivel> list = new List<Nivel>();
            DataAccess db = new DataAccess();
            try
            {
                db.Query("SELECT id_nivel, id_juego, numero_nivel, dificultad FROM Nivel WHERE id_juego=@j");
                db.Parameters("@j", idJuego);

                db.Read();

                while (db.Reader.Read())
                {
                    Nivel n = new Nivel
                    {
                        IdNivel = (int)db.Reader["id_nivel"],
                        IdJuego = (int)db.Reader["id_juego"],
                        NumeroNivel = (int)db.Reader["numero_nivel"],
                        Dificultad = db.Reader["dificultad"].ToString()
                    };
                    list.Add(n);
                }

                return list;
            }
            finally { db.Close(); }
        }
    }
}

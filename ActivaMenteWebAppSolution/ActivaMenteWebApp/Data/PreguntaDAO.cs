using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class PreguntaDAO
    {
        public List<Pregunta> ObtenerPreguntas(int idGame, int level)
        {
            List<Pregunta> list = new List<Pregunta>();
            DataAccess db = new DataAccess();

            try
            {
                db.Query("SELECT * FROM Pregunta WHERE id_juego=@idGame and id_nivel=@idLevel;");
                db.Parameters("@idGame", idGame);
                db.Parameters("@idLevel", level);
                db.Read();

                while (db.Reader.Read())
                {
                    Pregunta p = new Pregunta
                    {
                        IdPregunta = (int)db.Reader["id_pregunta"],
                        IdJuego = (int)db.Reader["id_juego"],
                        IdNivel = (int)db.Reader["id_nivel"],
                        IdCategoria = (int)db.Reader["id_categoria"],
                        Texto = db.Reader["pregunta"].ToString(),
                        Opcion1 = db.Reader["opcion1"].ToString(),
                        Opcion2 = db.Reader["opcion2"].ToString(),
                        Opcion3 = db.Reader["opcion3"].ToString(),
                        Opcion4 = db.Reader["opcion4"].ToString(),
                        OpcionCorrecta = (int)db.Reader["opcion_correcta"]
                    };
                    list.Add(p);
                }

                return list;
            }
            finally { db.Close(); }
        }
    }
}

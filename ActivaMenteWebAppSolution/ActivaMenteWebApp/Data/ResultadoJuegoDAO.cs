using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class ResultadoJuegoDAO
    {
       public void Insert(ResultadoJuego r)
        {
            DataAccess db = new DataAccess();

            try
            {
                db.Query("INSERT INTO ResultadoJuego (id_usuario, id_juego, id_nivel, puntaje_obtenido) " +
                         "VALUES (@u, @j, @n, @p)");

                db.Parameters("@u", r.IdUsuario);
                db.Parameters("@j", r.IdJuego);
                db.Parameters("@n", r.IdNivel);
                db.Parameters("@p", r.PuntajeObtenido);

                db.Execute();
            }
            finally { db.Close(); }
        }
      
        public List<ResultadoJuego> GetByUser(int idUsuario)
        {
            List<ResultadoJuego> list = new List<ResultadoJuego>();
            DataAccess db = new DataAccess();

            try
            {
                db.Query("SELECT * FROM ResultadoJuego WHERE id_usuario=@u");
                db.Parameters("@u", idUsuario);

                db.Read();

                while (db.Reader.Read())
                {
                    ResultadoJuego r = new ResultadoJuego
                    {
                        IdResultado = (int)db.Reader["id_resultado"],
                        IdUsuario = (int)db.Reader["id_usuario"],
                        IdJuego = (int)db.Reader["id_juego"],
                        IdNivel = (int)db.Reader["id_nivel"],
                        PuntajeObtenido = (int)db.Reader["puntaje_obtenido"],
                        Fecha = (DateTime)db.Reader["fecha"]
                    };
                    list.Add(r);
                }

                return list;
            }
            finally { db.Close(); }
        }
    }
}

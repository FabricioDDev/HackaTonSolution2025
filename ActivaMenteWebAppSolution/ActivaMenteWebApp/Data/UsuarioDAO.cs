using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class UsuarioDAO
    {
        public bool Login(string userName, string pass, ref Usuario userEncontrado)
        {
            var db = new DataAccess();

            try
            {
                db.Query(@"SELECT id_usuario, idPersona, nombre_usuario, contrasenia, avatar, fecha_registro, puntos_totales
                   FROM Usuario
                   WHERE nombre_usuario = @u AND contrasenia = @c");

                db.Parameters("@u", userName);
                db.Parameters("@c", pass);

                db.Read();

                if (!db.Reader.Read())
                {
                    userEncontrado = null;   // asignación explícita cuando no hay coincidencia
                    return false;
                }

                var u = new Usuario
                {
                    IdUsuario = (int)db.Reader["id_usuario"],
                    IdPersona = (int)db.Reader["idPersona"],
                    NombreUsuario = db.Reader["nombre_usuario"].ToString(),
                    Contrasenia = db.Reader["contrasenia"].ToString(),
                    Avatar = db.Reader["avatar"].ToString(),
                    FechaRegistro = Convert.ToDateTime(db.Reader["fecha_registro"]),
                    PuntosTotales = (int)db.Reader["puntos_totales"]
                };

                userEncontrado = u;  // ✔️ asigna por referencia

                return true;
            }
            finally
            {
                db.Close();
            }
        }
        public bool Update(Usuario usuario)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query("UPDATE Usuario SET nombre_usuario = @nombreUsuario, avatar = @avatar WHERE id_usuario = @id;");

                db.Parameters("@nombreUsuario", usuario.NombreUsuario);
                db.Parameters("@avatar", usuario.Avatar);
                db.Parameters("@id", usuario.IdUsuario);

                db.Execute();
                return true;
            }
            finally
            {
                db.Close();
            }
        }
        public bool UpdatePoints(int idUser, int points)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query("UPDATE Usuario SET puntos_totales=@ptj WHERE id_usuario = @id;");

                db.Parameters("@ptj", points);
                db.Parameters("@id", idUser);

                db.Execute();
                return true;
            }
            finally
            {
                db.Close();
            }
        }

         public List<Usuario> GetRanking()
            {
                DataAccess db = new DataAccess();
                List<Usuario> rank = new List<Usuario>();

                try
                {
                    db.Query(@"
                SELECT  
                    u.id_usuario,
                    u.idPersona,
                    u.nombre_usuario,
                    SUM(r.puntaje_obtenido) AS puntaje_total
                FROM ResultadoJuego r
                INNER JOIN Usuario u ON u.id_usuario = r.id_usuario
                GROUP BY u.id_usuario, u.idPersona, u.nombre_usuario
                ORDER BY puntaje_total DESC;
            ");
                db.Read();

                    while (db.Reader.Read())
                    {
                        var u = new Usuario
                        {
                            IdUsuario = (int)db.Reader["id_usuario"],
                            IdPersona = (int)db.Reader["idPersona"],
                            NombreUsuario = db.Reader["nombre_usuario"].ToString(),
                            PuntosTotales = (int)db.Reader["puntaje_total"]
                        };

                        rank.Add(u);
                    }

                    return rank;
                }
                finally
                {
                    db.Close();
                }
            }

    }
}

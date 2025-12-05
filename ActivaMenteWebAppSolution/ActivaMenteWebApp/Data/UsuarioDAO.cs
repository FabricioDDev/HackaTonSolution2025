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
                db.Query(@"SELECT id_usuario, idPersona, nombre_usuario, contrasenia, avatar, fecha_registro
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
                    FechaRegistro = Convert.ToDateTime(db.Reader["fecha_registro"])
                };

                userEncontrado = u;  // ✔️ asigna por referencia

                return true;
            }
            finally
            {
                db.Close();
            }
        }


        /*   public void Insert(Usuario u)
           {
               DataAccess db = new DataAccess();
               try
               {
                   db.Query("INSERT INTO Usuario (idPersona, nombre_usuario, contraseña, avatar, fecha_registro, activo) " +
                            "VALUES (@p, @u, @c, @a, @f, @ac)");

                   db.Parameters("@p", u.IdPersona);
                   db.Parameters("@u", u.NombreUsuario);
                   db.Parameters("@c", u.Contrasenia);
                   db.Parameters("@a", u.Avatar);
                   db.Parameters("@f", u.FechaRegistro);

                   db.Execute();
               }
               finally { db.Close(); }
           }*/
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

    }
}

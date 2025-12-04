using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class UsuarioDAO
    {
        public Usuario Login(string usuario, string contraseña)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query("SELECT * FROM Usuario WHERE nombre_usuario=@u AND contraseña=@c AND activo=1");
                db.Parameters("@u", usuario);
                db.Parameters("@c", contraseña);

                db.Read();

                if (db.Reader.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = (int)db.Reader["id_usuario"],
                        IdPersona = (int)db.Reader["idPersona"],
                        NombreUsuario = db.Reader["nombre_usuario"].ToString(),
                        Contrasenia = db.Reader["contraseña"].ToString(),
                        Avatar = db.Reader["avatar"].ToString(),
                        FechaRegistro = (DateTime)db.Reader["fecha_registro"],
                    };
                }
                return null;
            }
            finally { db.Close(); }
        }

        public void Insert(Usuario u)
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
        }
    }
}

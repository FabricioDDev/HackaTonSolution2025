using ActivaMenteWebApp.Entities;
using Data;
using System;

namespace Business
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAO dao = new UsuarioDAO();

        public bool Login(string username, string password, ref Usuario userEncontrado)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            return dao.Login(username, password, ref userEncontrado);
        }

      /*  public void Register(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.NombreUsuario))
                throw new Exception("Usuario requerido");

            if (string.IsNullOrWhiteSpace(u.Contrasenia))
                throw new Exception("Contraseña requerida");

            u.FechaRegistro = DateTime.Now;

            dao.Insert(u);
        }*/
    }
}

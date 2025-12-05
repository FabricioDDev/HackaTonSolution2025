using ActivaMenteWebApp.Entities;
using Data;
using System;
using System.Collections.Generic;

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
        public List<Usuario> getRanking()
        {
            return dao.GetRanking();
        }
      public bool UpdateUsuario(Usuario usuario)
        {
            return dao.Update(usuario);
        }
        public bool UpdatePoints(int idUser, int points)
        {
            return dao.UpdatePoints(idUser, points);
        }
    }
}

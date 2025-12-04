using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using ActivaMenteWebApp.Data;

namespace Negocio
{
    public class PersonaBLL
    {
        private readonly PersonaDAO personaDAO;

        public PersonaBLL()
        {
            personaDAO = new PersonaDAO();
        }

        public int CrearPersona(Persona p)
        {
            return personaDAO.Insertar(p);
        }

        public Persona ObtenerPorId(int id)
        {
            return personaDAO.ObtenerPorId(id);
        }

        public Persona ObtenerPorEmail(string email)
        {
            return personaDAO.ObtenerPorEmail(email);
        }

        public List<Persona> Listar()
        {
            return personaDAO.Listar();
        }
    }
}

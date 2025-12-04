using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using Data;

namespace Business
{
    public class PersonasBLL
    {
        private readonly PersonasDAO dao = new PersonasDAO();

        public List<Persona> GetAll()
        {
            return dao.GetAll();
        }

        public void Add(Persona p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre))
                throw new Exception("Nombre requerido");

            if (string.IsNullOrWhiteSpace(p.Apellido))
                throw new Exception("Apellido requerido");

            dao.Insert(p);
        }
    }
}

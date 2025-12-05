using System;
using System.Collections.Generic;
using ActivaMenteWebApp.Entities;
using DB;

namespace Data
{
    public class PersonasDAO
    {
        public List<Persona> GetAll()
        {
            List<Persona> list = new List<Persona>();
            DataAccess db = new DataAccess();

            try
            {
                db.Query("SELECT idPersona, nombre, apellido, sexo, nacionalidad FROM Personas");
                db.Read();

                while (db.Reader.Read())
                {
                    Persona p = new Persona
                    {
                        IdPersona = (int)db.Reader["idPersona"],
                        Nombre = db.Reader["nombre"].ToString(),
                        Apellido = db.Reader["apellido"].ToString(),
                        Sexo = db.Reader["sexo"].ToString(),
                        Nacionalidad = db.Reader["nacionalidad"].ToString()
                    };
                    list.Add(p);
                }
                return list;
            }
            finally { db.Close(); }
        }

        public void Insert(Persona p)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query("INSERT INTO Personas (nombre, apellido, sexo, nacionalidad) VALUES (@n, @a, @s, @c)");

                db.Parameters("@n", p.Nombre);
                db.Parameters("@a", p.Apellido);
                db.Parameters("@s", p.Sexo);
                db.Parameters("@c", p.Nacionalidad);

                db.Execute();
            }
            finally { db.Close(); }
        }
        public Persona GetPersonaById(int idPersona)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query("Select * From Personas where idPersona=@id;");
                db.Parameters("@id", idPersona);
                db.Read();
                Persona p = new Persona();
                while (db.Reader.Read())
                {
                    {
                        p.IdPersona = (int)db.Reader["idPersona"];
                        p.Nombre = db.Reader["nombre"].ToString();
                        p.Apellido = db.Reader["apellido"].ToString();
                        p.Sexo = db.Reader["sexo"].ToString();
                        p.Nacionalidad = db.Reader["nacionalidad"].ToString();
                        p.FechaNacimiento = Convert.ToDateTime(db.Reader["fecha_nacimiento"]);
                        p.Email = db.Reader["email"].ToString();
                        
                    };
                }
                return p;
            }
            finally { db.Close(); }
        }

        public bool Update(Persona persona)
        {
            DataAccess db = new DataAccess();
            try
            {
                db.Query(
                    "UPDATE Personas SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "sexo = @sexo, " +
                    "nacionalidad = @nacionalidad, " +
                    "fecha_nacimiento = @fecha_nacimiento, " +
                    "email = @email " +
                    "WHERE idPersona = @idPersona;"
                );

                db.Parameters("@nombre", persona.Nombre);
                db.Parameters("@apellido", persona.Apellido);
                db.Parameters("@sexo", persona.Sexo);
                db.Parameters("@nacionalidad", persona.Nacionalidad);
                db.Parameters("@fecha_nacimiento", persona.FechaNacimiento);
                db.Parameters("@email", persona.Email);
                db.Parameters("@idPersona", persona.IdPersona);

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

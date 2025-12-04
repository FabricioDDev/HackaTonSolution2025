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
    }
}

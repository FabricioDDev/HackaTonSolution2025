using System;
using System.Data.SqlClient;

namespace DB
{
    public class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public DataAccess()
        {
            connection = new SqlConnection("server=localhost\\SQLEXPRESS; database=ActivaMenteDB; integrated security = true");
            command = new SqlCommand();
        }

        // -----------------------------------------------------------
        // SETTERS DE CONSULTA
        // -----------------------------------------------------------
        public void Query(string query)
        {
            command.Parameters.Clear();          // evita contaminación entre consultas
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void SP(string sp)
        {
            command.Parameters.Clear();          // idem
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = sp;
        }

        // -----------------------------------------------------------
        // EJECUCIÓN
        // -----------------------------------------------------------
        public void Read()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        public void Execute()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }

        // -----------------------------------------------------------
        // PARÁMETROS
        // -----------------------------------------------------------
        public void Parameters(string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }

        // -----------------------------------------------------------
        // CLOSE
        // -----------------------------------------------------------
        public void Close()
        {
            if (reader != null && !reader.IsClosed)
                reader.Close();

            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}

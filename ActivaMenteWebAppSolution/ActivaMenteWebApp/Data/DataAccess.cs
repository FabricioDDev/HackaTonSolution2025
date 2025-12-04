using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ActivaMenteWebApp.Data
{
    public class DataAccess
    {
        private const string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=SistemaClinicaMedicaDB;Integrated Security=True;";

        public void DataAaccess()
        {
            SqlConnection Conexion = ObtenerConexion();
        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataReader GetData(string consultaSQL)
        {
            //establecer la conexion con la base de datos sql server
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            sqlConnection.Open();

            //Ejecutar consulta
            SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();


            return reader;
        }
        public int ejecutarTransaccion(string consultaSQL)
        {
            /// ESTABLECER UNA CONEXION A LA BASE DE DATOS SQL SERVER
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);
            /// EJECUTAR CONSULTA
            int filasAfectadas = sqlCommand.ExecuteNonQuery(); /// INSERT, UPDATE, DELETE

            sqlConnection.Close();

            return filasAfectadas;
        }

        private SqlDataAdapter ObtenerAdaptador(string consultaSQL, SqlConnection conexion)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSQL, conexion);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable obtenerTabla(string NombreTabla, string sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlDataAdapter adp = ObtenerAdaptador(sql, conexion);
            adp.Fill(ds, NombreTabla);
            conexion.Close();
            return ds.Tables[NombreTabla];
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand cmd, String NombreSP)
        {
            int FilasCambiadas = 0;

            SqlConnection Conexion = ObtenerConexion();
            SqlTransaction trans = Conexion.BeginTransaction();

            try // Agrego un trycatch para que no se cargue la sucursal si hay un error
            {
                cmd.Connection = Conexion;
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = NombreSP;

                FilasCambiadas = cmd.ExecuteNonQuery();

                trans.Commit(); // Confirma la transacción si todo sale bien

                Conexion.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();   // Deshace la transacción en caso de error
                throw; // mando el error hacia arriba para que lo reciba el nivel superior
            }


            return FilasCambiadas;
        }
        public int ObtenerMaximo(string consulta)
        {
            int max = 0;
            SqlConnection cn = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                max = Convert.ToInt32(dr[0].ToString());
            }
            return max;
        }
    }
}
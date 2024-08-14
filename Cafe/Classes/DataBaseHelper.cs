using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Classes
{
   
        public class DatabaseHelper
        {
            private static readonly string connectionString = Properties.Settings.Default.cafeConnectionString;
            
            

            private static SqlCommand CreateCommand(string query, SqlConnection connection, params SqlParameter[] parameters)
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command;
            }

            public static SqlDataReader ExecuteReader(string query, params SqlParameter[] parameters)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = CreateCommand(query, connection, parameters);
                connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }

        public static void ExecuteNoneQuery(string query, params SqlParameter[] parameters) {
        
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = CreateCommand(query , sqlConnection,parameters);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
        }


        public static object ExecuteScalar(string query, params SqlParameter[] parameters) {

            SqlConnection sqlconnection = new SqlConnection(connectionString);
            SqlCommand cmd = CreateCommand(query,sqlconnection,parameters);
            sqlconnection.Open();
            return cmd.ExecuteScalar();
        
        }
   }
}


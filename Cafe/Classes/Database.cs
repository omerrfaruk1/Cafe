using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe.Classes
{
    public class Database
    {
        private static string connectionString = "Data Source=DESKTOP-LCHCDI1;Initial Catalog=cafe;Integrated Security=True;Encrypt=False";

        public static SqlDataReader GetDatabase(string commandparm,string commandval)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandparm , conn);
                command.Parameters.AddWithValue("@k1", commandval);
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        
    }
}
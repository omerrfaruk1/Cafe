using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

        public static void SetDatabase(string ad,int price,int amount ,string tableName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string command = "insert into product_table (Ad,Fiyat,Miktar,masa,Eklenme_Tarihi) values (@ad,@price,@amount,@table,@date)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@table", tableName);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show (ex.Message);
                
            }


        }
        
    }
}
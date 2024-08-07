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

        public static void SetDatabase(string ad,int price ,string tableName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                string command = "insert into product_table (Ad,Fiyat,masa,Eklenme_Tarihi) values (@ad,@price,@table,@date)";
                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@table", tableName);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show (ex.Message);
                
            }
        }

        public static void CancelAddedItem(string tablaname) {
            
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            int idToDelete = 0;
            try {  
                sqlConnection.Open();
                string cmd = "Select top 1 * FROM product_table WHERE masa = '" + tablaname +"' ORDER BY id DESC ";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                SqlDataReader reader =  command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read()) {
                    idToDelete = reader.GetInt32(0);
                }
                reader.Close();


                SqlConnection Connection = new SqlConnection(connectionString);

                if (idToDelete > 0)
                {
                    Connection.Open(); 
                    string deleteQuery = "DELETE FROM product_table WHERE id = @id";

                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, Connection);
                    
                        deleteCommand.Parameters.AddWithValue("@id", idToDelete);
                        deleteCommand.ExecuteNonQuery();
                    
                }
                Connection.Close();

            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteAllProductInTable(string tablaname) {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string command = "Delete  from product_table where masa = @masano";
            SqlCommand deleteCommand = new SqlCommand(command, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@masano", tablaname);
            deleteCommand.ExecuteNonQuery();

        }

        public static void DeleteProductInTable(string tablaname,object productname)
        {

            productname = productname.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            int idToDelete = 0;
            try
            {
                sqlConnection.Open();
                string cmd = "Select top 1 * FROM product_table WHERE masa =@masano  and  ad =@productname ORDER BY id DESC ";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("@masano", tablaname);
                command.Parameters.AddWithValue("@productname", productname);
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    idToDelete = Convert.ToInt32(result);
                }
                sqlConnection.Close();

                SqlConnection Connection = new SqlConnection(connectionString);

                if (idToDelete > 0)
                {
                    Connection.Open();
                    string deleteQuery = "DELETE FROM product_table WHERE id = @id";

                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, Connection);

                    deleteCommand.Parameters.AddWithValue("@id", idToDelete);
                    deleteCommand.ExecuteNonQuery();


                }
                Connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
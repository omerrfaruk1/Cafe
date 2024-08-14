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
        private static string connectionString = Properties.Settings.Default.cafeConnectionString;



        public static SqlDataReader GetDatabase(string commandparm, string commandval)
        {
            try
            {
                string query = commandparm;
                SqlParameter param = new SqlParameter("@k1", commandval);

                return DatabaseHelper.ExecuteReader(query, param);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
           

        }

        public static void SetDatabase(string ad, double price, string tableName)
        {
            try
            {

                string query = "insert into product_table (Ad,Fiyat,masa,changed,Eklenme_Tarihi) values (@ad,@price,@table,@changed,@date)";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ad", ad),
                        new SqlParameter("@price", price),
                        new SqlParameter("@table", tableName),
                        new SqlParameter("@changed", "False"),
                        new SqlParameter("@date", DateTime.Now)
                };

                DatabaseHelper.ExecuteNoneQuery(query, parameters);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void CancelAddedItem(string tablaname)
        {
            try
            {

            
            int idToDelete = 0;
            string query = "Select top 1 * FROM product_table WHERE masa = '" + tablaname + "' ORDER BY id DESC ";
            SqlDataReader reader = DatabaseHelper.ExecuteReader(query);
                if (reader.Read())
                {
                    idToDelete = reader.GetInt32(0);
                }
                reader.Close();


                if (idToDelete > 0)
                {
                    string Deletequery = "DELETE FROM product_table WHERE id = @id";
                    SqlParameter param = new SqlParameter("@id", idToDelete);
                    DatabaseHelper.ExecuteNoneQuery(Deletequery, param);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void DeleteAllProductInTable(string tablaname)
        {
            try
            {
                string command = "Delete  from product_table where masa = @masano";
                SqlParameter param = new SqlParameter("@masano", tablaname);
                DatabaseHelper.ExecuteNoneQuery(command, param);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            

        }

        public static void DeleteProductInTable(string tablaname, object productname)
        {

            productname = productname.ToString();
            int idToDelete = 0;
            try
            {
                string cmd = "Select top 1 * FROM product_table WHERE masa =@masano  and  ad =@productname ORDER BY id DESC ";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter ("@masano", tablaname),
                    new SqlParameter("@productname", productname)
                };

                object result = DatabaseHelper.ExecuteScalar(cmd,param);

                if (result != null)
                {
                    idToDelete = Convert.ToInt32(result);
                }


                if (idToDelete > 0)
                {
                    string deleteQuery = "DELETE FROM product_table WHERE id = @id";
                    SqlParameter parameter = new SqlParameter("@id", idToDelete);
                    DatabaseHelper.ExecuteNoneQuery(deleteQuery, parameter);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void UpdateProductPriceAfterBill(string tablaname, double billAmount)
        {
            try
            {
                string cmd = "UPDATE product_table SET Fiyat = Fiyat * @b1 , changed = 'True' WHERE masa = @t1";

                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@b1", billAmount),
                new SqlParameter("@t1", tablaname)
            };
                DatabaseHelper.ExecuteNoneQuery(cmd, param);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Cafe.Classes
{
    internal class SettingsItem
    {
        string param = "";
        string komut;
        public SqlDataReader GetFullTables()
        {
            komut = "SELECT p.id, p.ad,p.fiyat, c.category_name,p.category FROM products p JOIN product_categories c ON p.category = c.category_id";

            SqlDataReader reader = Database.GetDatabase(komut, param);
            return reader;
        }
        public SqlDataReader GetCategoryName() {

            komut = "Select category from product_catgeories";

            SqlDataReader reader = Database.GetDatabase(komut, param);
            return reader;
        }

        public void UpdateDataBase(string name, int id, int price)
        {
            komut = "update products set ad =@a1, fiyat =@f1 where id =@id";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@a1", name),
                new SqlParameter("@f1", price),
                new SqlParameter("@id", id)
            };

            DatabaseHelper.ExecuteNoneQuery(komut,param);

        }
        public void SetDataBase(string name ,int price , int categoryId)
        {
            komut = "insert into products (ad,fiyat,category,commonly_used) values( @a1, @f1, @c1,@bool)";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@a1", name),
                new SqlParameter("@f1", price),
                new SqlParameter("@c1",categoryId ),
                new SqlParameter("@bool",false)
            };

            DatabaseHelper.ExecuteNoneQuery(komut, param);
        }
        public void DeleteDataBase(int id) {
            komut = "delete from products where id = @id";
            SqlParameter param = new SqlParameter("@id", id);

            DatabaseHelper.ExecuteNoneQuery(komut, param);
        }
    }
}

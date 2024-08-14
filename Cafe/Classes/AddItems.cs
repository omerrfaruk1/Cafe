using Cafe.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe.Classes
{
    public class AddItems : IDataAccessItem
    {
        private string param;
        private string komut;
        DataTable dt = new DataTable();
        public  DataTable GetItemInfos(string name, string tablename)
        {

            param = name.ToString();
            komut = "Select Ad,Fiyat from products where Ad = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);
            dt.Clear();
            dt.Load(reader);
            return dt;
        }
    }
}

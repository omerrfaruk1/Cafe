using Cafe.Classes;
using Cafe.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class Tables : IDataAccessTable
    {
        private string param;
        private string komut;

        public IDataReader GetDataTableByTableInfo(string name)
        {

            param = name.ToString();
            komut = "Select Ad,Fiyat from product_Table where masa = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            return reader;
        }
        public IDataReader GetDataTableByName(string name)
        {
            param = name.ToString();
            komut = "Select masa from product_Table where masa = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            return reader;

        }
        public IDataReader GetDataTableByChanged(string name)
        {
            param = name.ToString();
            komut = "Select * from product_Table where masa = @k1 and changed = 'True'";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            return reader;
        }
        public IDataReader GetAllFullTables()
        {

            param = "";
            komut = "select * from product_Table ";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            return reader;
        }
    }
   
}

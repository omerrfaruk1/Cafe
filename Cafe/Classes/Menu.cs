using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using Cafe.Classes;
using System.Data.SqlClient;
using System.Data;

namespace Cafe
{
    public class Menu
    {
        Buttons button = new Buttons();
        private DataTable  dt = new DataTable();

        public string komut;
        public string param;

        public List<Button> GetItemName(string parameter)
        {
            List<Button> buttons = new List<Button>();
            List<string[]> results = new List<string[]>();

            param = parameter.ToString();
            komut = "Select Ad from products where category = @k1";
            
            SqlDataReader dr = Database.GetDatabase(komut, param);
            int k = 0;
            while (dr.Read()) {
                
                 results.Add(new string[] { dr[0].ToString() });
                k++;
            }

            var btn = button.Create_Buttons(results.Count, 50, 50, 10, 4);
            int i = 0;


            foreach (var res in results) {

                btn[i].Text = res.FirstOrDefault()?.ToString()?? "Look the in res";
                i++;
            }
                    
                
            return btn;


        }
        public DataTable GetItemInfos(string name,string tablename) {

            param = name.ToString();
            komut = "Select Ad,Fiyat,Miktar from products where Ad = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);
            
            dt.Load(reader);
            //if (!dt.Columns.Contains("Eklenme_Tarihi") && !dt.Columns.Contains("masa"))
            //{
            //    dt.Columns.Add(new DataColumn("masa", typeof(string)));
            //    dt.Columns.Add(new DataColumn("Eklenme_Tarihi", typeof(DateTime)));

            //    foreach (DataRow item in dt.Rows)
            //    {
            //        item["masa"] = tablename;
            //        item["Eklenme_Tarihi"] = DateTime.Now;
            //    }
            //}
            //else
            //{
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        item["masa"] = tablename;
            //        item["Eklenme_Tarihi"] = DateTime.Now;

            //    }
            //}

            return dt;
        }
        

        public DataTable GetDataTableByTableInfo(string name)
        {

            param = name.ToString();
            komut = "Select Ad,Fiyat,Miktar,Eklenme_Tarihi from product_Table where masa = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);
            dt.Clear();
            dt.Load(reader);

            return dt;
        }
    }


    }

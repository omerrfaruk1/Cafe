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
            komut = "Select name from products where category = @k1";
            
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
        public DataTable GetItemInfos(string name) {

            param = name.ToString();
            komut = "Select name,price,main_category,amount,id from products where name = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            dt.Load(reader);

            return dt;
        }
    }


    }

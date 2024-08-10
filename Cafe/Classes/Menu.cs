using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using Cafe.Classes;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Cafe
{
    public class Menu
    {
        Buttons button = new Buttons();
        private DataTable dt = new DataTable();

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
            while (dr.Read())
            {

                results.Add(new string[] { dr[0].ToString() });
                k++;
            }
            dr.Close();

            var btn = button.Create_Buttons(results.Count, 100, 100, 10, 4);
            int i = 0;
            string imgPath = "C:\\Users\\omer2\\Downloads\\Venedik Coffee (1).png";
            Image image = Image.FromFile(imgPath);
            foreach (var res in results)
            {

                btn[i].Text = res.FirstOrDefault()?.ToString() ?? "Look the in res";
                btn[i].Font = new Font(btn[i].Font.FontFamily, 16);
                btn[i].BackgroundImage = image;
                btn[i].Padding = new Padding(0, 25, 0, 0);
                i++;
            }


            return btn;


        }
        public DataTable GetItemInfos(string name, string tablename)
        {

            param = name.ToString();
            komut = "Select Ad,Fiyat from products where Ad = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            dt.Clear();
            dt.Load(reader);


            return dt;
        }


        public DataTable GetDataTableByTableInfo(string name)
        {

            param = name.ToString();
            komut = "Select Ad,main_category,Fiyat from product_Table where masa = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);
            dt.Clear();
            dt.Load(reader);
            reader.Close();
            return dt;
        }
        public SqlDataReader GetDataTableByName(string name)
        {
            param = name.ToString();
            komut = "Select masa from product_Table where masa = @k1";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            return reader;

        }
        public SqlDataReader GetDataTableByChanged(string name)
        {
            param = name.ToString();
            komut = "Select * from product_Table where masa = @k1 and changed = 'True'";

            SqlDataReader reader = Database.GetDatabase(komut, param);

            return reader;
        }
    }

    }

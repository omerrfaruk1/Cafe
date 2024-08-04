using Cafe.Classes;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json.Serialization;

namespace Cafe
{
    public partial class FormTableInfo : Form
    {
        private Buttons buttons;
        private Menu menuItem;
        private AddItems addItem;
        private DataTable dt;
        public FormTableInfo()
        {
            InitializeComponent();

            buttons = new Buttons();
            menuItem = new Menu();
            addItem = new AddItems();


        }
        public void SetItemsInDataGridView()
        {
            dt = menuItem.GetDataTableByTableInfo(label2.Text);
            dataGridView1.DataSource = dt;
            
        }

        private void FormTableInfo_Load(object sender, EventArgs e)
        {
            
            

        }
    
        private void ButtonAddToPanel(string category)
        {
            
            panel1.Controls.Clear();
            var buttonitem = addItem.GetItemsNameByCategory(category);


            for (int i = 0; i < buttonitem.Count; i++)
            {
                buttonitem[i].Click += new EventHandler(ClickButton);
                panel1.Controls.Add(buttonitem[i]);
            }
        }
        public void ClickButton(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;

            setvalueindat(button);
            dt = menuItem.GetDataTableByTableInfo(label2.Text);
            dataGridView1.DataSource = dt;
            


        }


        private void setvalueindat(Button btn)
        {
            string tablenames = label2.Text;
            string ad, table;
            int price, amount;
            
            DataTable reader = menuItem.GetItemInfos(btn.Text, tablenames);

            foreach (DataRow row in reader.Rows) {
                ad = row[0].ToString();
                price = Convert.ToInt32(row[1].ToString());
                amount = Convert.ToInt32(row[2].ToString());
                table = tablenames;

                Database.SetDatabase(ad, price, amount,table);

            }

            reader.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ButtonAddToPanel("1");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ButtonAddToPanel("2");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonAddToPanel("3");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonAddToPanel("4");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonAddToPanel("5");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ButtonAddToPanel("6");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //SetDatabase

        }
    }
}

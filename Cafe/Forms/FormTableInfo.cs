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
using System.Data.SqlClient;
using static System.Net.WebRequestMethods;

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
            label1.Text = "";
            double summ = 0;
            dt = menuItem.GetDataTableByTableInfo(label2.Text);
            dataGridView1.DataSource = dt;
            summ = getSum(summ);
            
        }

        private void FormTableInfo_Load(object sender, EventArgs e)
        {
            panel2.BackColor = ColorTranslator.FromHtml("#23282D");
            panel3.BackColor = ColorTranslator.FromHtml("#23282D");
            button1.BackColor = ColorTranslator.FromHtml("#375168");

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

            dataGridView1.DataSource = null;
            FillDatagridview();

        }

        private void FillDatagridview()
        {
            double sum = 0;

            dt = menuItem.GetDataTableByTableInfo(label2.Text);
            dataGridView1.DataSource = dt;

            sum = getSum(sum);
        }

        private double getSum(double sum)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                object cell = row.Cells[2].Value;

                if (cell != null && double.TryParse(cell.ToString(), out double numericValue))
                {
                    sum += numericValue;
                }
                label1.Text = "₺" + sum.ToString();
            }

            return sum;
        }

        private void setvalueindat(Button btn)
        {
            string table = label2.Text;
            string ad;
            int price;
            
            DataTable reader = menuItem.GetItemInfos(btn.Text, table);

            foreach (DataRow row in reader.Rows) {
                ad = row[0].ToString();
                price = Convert.ToInt32(row[2].ToString());
                Database.SetDatabase(ad, price,table);

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
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Database.DeleteAllProductInTable(label2.Text);
            FillDatagridview();
            // İkram Ödeme Alınacak Ancak Cüroya Yansımayacak
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    dataGridView1.Rows[e.RowIndex].Selected = true;

            //    // Seçili satır üzerinde gezinin
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            foreach (DataGridViewCell cell in selectedRow.Cells)
            {
                
                if(cell.ValueType == typeof(string) && cell.Value != null)
                {

                 Database.DeleteProductInTable(label2.Text,cell.Value);

                }
            }
            //}
            // İade Seçili Olan ürün İade Olacak
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            // Böl Hesap Bölünecek
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // İskonto Verilen Yüzde Oranında İskonto Uygulanacak
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Database.CancelAddedItem(label2.Text);
             FillDatagridview();
            //İptal Eklenen Son Ürünü Sil
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0) {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                
            }
            //DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            //foreach (DataGridViewCell cell in selectedRow.Cells)
            //{
            //    Console.WriteLine(cell.Value);
            //}
        }
    }
}

using Cafe.Classes;
using Cafe.Interface;
using Cafe.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe.Forms
{
    public partial class FormBill : Form 
    {
        private Buttons btnBill;
        private DataTable dt;
        private Menu menu;
        private readonly IDataAccessTable _dataAccess;

        public FormBill()
        {
            InitializeComponent();
            btnBill = new Buttons();
            dt = new DataTable();
            menu = new Menu();
            _dataAccess = new Tables();
            
        }

        bool percent = false;
        bool percent2 = false;
        bool percent3 = false;
        bool percent4 = false;
        public void setPercentValue()
        {
            percent = false;
            percent2 = false;
            percent3 = false;
            percent4 = false;
        }

       private void getBillInfoInSettings()
       {
            label2.Text = "";
       }
        private void SaveLabelValue()
        {
            Settings.Default.SalonBtnNo = Convert.ToInt32(label2.Text);
            Settings.Default.Save(); 
        }
        private void FormBill_Load(object sender, EventArgs e)
        {
            getBillInfoInSettings();
            var buttons = btnBill.Create_Buttons(12, 70, 50, 10, 3);


            if (buttons != null) {
                if (buttons.Count > 9) {
                    buttons[9].Text = ",";
                }
                if (buttons.Count > 10)
                {
                    buttons[10].Text = "0";
                }
                if (buttons.Count > 11)
                {
                    buttons[11].Text = "C";
                    buttons[11].BackColor = Color.Black;
                    buttons[11].ForeColor = Color.White;
                }
            }
            FillPanel(buttons);
            FillDatagridview(this.Text);
        }
        private void FillPanel(List<Button> buttons)
        {
            for (int i = 0; i < buttons.Count; i++) {
                panel1.Controls.Add(buttons[i]);
                buttons[i].Click += new EventHandler(clickButton);
            }

        }
        private void clickButton(object sender, EventArgs e) {
            var button = (Button)sender;
            if(button.Text == "C")
            {
                button11.Text = "";
            }
            else
            {
                button11.Text += button.Text;
            }
        }

        private void FillDatagridview(string tablename)
        {
            double sum = 0;
            var reader = _dataAccess.GetDataTableByTableInfo(tablename);
            dt.Clear();
            dt.Load(reader);
            reader.Close();
            dataGridView1.DataSource = dt;
            sum = getSum(sum);


        }

        private double getSum(double sum)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                
                object cell = row.Cells[1].Value;

                if (cell != null && double.TryParse(cell.ToString(), out double numericValue))
                {
                    sum += numericValue;
                    sum = sum - Settings.Default.BalkonBtnNo; 
                }
                label1.Text = "₺" + sum.ToString();
            }

            return sum;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setPercentValue();
            button11.Text = label1.Text;
            percent = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            setPercentValue();

            var labelpercent2 = new Label();
            labelpercent2.Text = label1.Text.Replace("₺", "");
            labelpercent2.Text = Convert.ToDouble(Convert.ToDouble(labelpercent2.Text) / 2).ToString("F1");
            button11.Text = labelpercent2.Text + "₺";
            percent2 = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setPercentValue();

            var labelpercent3 = new Label();
            labelpercent3.Text = label1.Text.Replace("₺", "");
            labelpercent3.Text = Convert.ToDouble(Convert.ToDouble(labelpercent3.Text) / 3).ToString("F1");
            button11.Text = labelpercent3.Text + "₺";
            percent3 = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            setPercentValue();

            var labelpercent4 = new Label();
            labelpercent4.Text = label1.Text.Replace("₺", "");
            labelpercent4.Text = Convert.ToDouble(Convert.ToDouble(labelpercent4.Text) / 4).ToString("F1");
            button11.Text = labelpercent4.Text + "₺";
            percent4 = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (percent == true) {
                Database.DeleteAllProductInTable(this.Text);
                FillDatagridview(this.Text);
            }
            else if(percent2 == true){
                SetAndGetValueLbl();
                double param = 0.5;
                Database.UpdateProductPriceAfterBill(this.Text,param);
            }
            else if (percent3 == true)
            {
                SetAndGetValueLbl();
                double param = 0.7;
                Database.UpdateProductPriceAfterBill(this.Text, param);
            }
            else if (percent4 == true)
            {
                SetAndGetValueLbl();
                double param = 0.75;
                Database.UpdateProductPriceAfterBill(this.Text, param);
            }

            void SetAndGetValueLbl()
            {
                label1.Text = (Convert.ToDouble(label1.Text.Replace("₺", "")) - Convert.ToDouble(button11.Text.Replace("₺", ""))).ToString();
                label2.Text = "Bir Ödeme Oldu Yeni Tutar " + label1.Text;
                SaveLabelValue();
            }
        }
        public void button9_Click(object sender, EventArgs e)
        {
            double lb1 = Convert.ToDouble(label1.Text.Replace("₺", "")); // Toplam Fiyat
            double lb12 = Convert.ToDouble(button11.Text); // İskonto Oranı
            label1.Text = (lb1 - (lb1 * lb12 / 100)).ToString("F2"); // İskonto sonrası Ortaya Çıkan Sonuç
            label3.Text =  "% " + button11.Text+  " Oranında Bir İskonto Uygulandı";
            label2.Text = "Bir Ödeme Oldu Yeni Tutar " + label1.Text;
            double param = 1 - (Convert.ToDouble(button11.Text) * 0.01) ;
            button11.Text = "";
            Database.UpdateProductPriceAfterBill(this.Text, param);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}

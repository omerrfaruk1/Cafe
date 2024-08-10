using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Windows.Forms;
using Cafe.Classes;

namespace Cafe
{
    public partial class FormLoginPage : Form
    {
        private Buttons createbtn;
        private const int btnNumber = 12; 
        private const int PerRow = 3; // Her satırda 3 buton
        private const int Spacing = 10; // Butonlar arasındaki boşluk
        private const int width = 50;
        private const int height = 50;

        public FormLoginPage()
        {
            InitializeComponent();
            createbtn = new Buttons();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
           
            foreach(Control control in this.Controls)
            {
                if(control is Button bt)
                {
                    bt.FlatStyle = FlatStyle.Flat;
                    bt.FlatAppearance.BorderSize = 0;
                    bt.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold);
                    bt.BackColor = ColorTranslator.FromHtml("#375168");

                }
            }

           

            var buttons = createbtn.Create_Buttons(btnNumber,width,height,Spacing,PerRow);
            if (buttons.Count > 9)
            {
                buttons[9].Text = "#";
            }
            if (buttons.Count > 10)
            {
                buttons[10].Text = "0"; 
            }
            if(buttons.Count > 11)
            {
                buttons[11].Text = "x";
            }

            ArrangeButtons(buttons);
          
        }


        private void ArrangeButtons(List<Button> button)
        {
           
            for (int i = 0; i < button.Count; i++)
            {
                button[i].Click += new EventHandler(ClickButton);               
                panel1.Controls.Add(button[i]);

            }
        }
        public void ClickButton(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            label6.Text += b.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(label6.Text == "")
            {
                
                MessageBox.Show("Şifre Alanı Zaten Boş");
                 
            }
            else
            {
                string text = label6.Text;
                label6.Text = text.Substring(0, text.Length - 1);
                
            }   
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            string param = label6.Text;
            string komut = "Select password from login where password = @k1";

            SqlDataReader records = Database.GetDatabase(komut,param);

            while (records.Read()) {
                
                Formtables formtables = new Formtables();
                formtables.ShowDialog();
            }


        }


    }
}

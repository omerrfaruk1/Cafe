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

namespace Cafe
{
    public partial class FormLoginPage : Form
    {
        private Buttons createbtn;
        private const int btnNumber = 12; // Kaç Tane Buton Oluşturacağını yaz
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
            
            foreach(Control control in this.Controls)
            {
                if(control is Button bt)
                {
                    bt.FlatStyle = FlatStyle.Flat;
                    bt.FlatAppearance.BorderSize = 0;
                    bt.BackColor = Color.Teal;

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
               
                foreach (Button b in button)
                {
                   
                    panel1.Controls.Add(b);

                }
            }
        }
        public void ClickButton(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            textBox1.Text += b.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                return;
            }
            else
            {
                string text = textBox1.Text;
                textBox1.Text = text.Substring(0, text.Length - 1);
                
            }   
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();
            string connstring = "Data Source=DESKTOP-LCHCDI1;Initial Catalog=cafe;Integrated Security=True;Encrypt=False";
            conn.ConnectionString = connstring;
            conn.Open();
            SqlCommand command = new SqlCommand("Select password from login where password = " +textBox1.Text+"", conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read()) {
                Form form = new Formtables();
                form.ShowDialog();
            }
            else
            {
                label4.Text = "Lütfen Tekrar Deneyiniz";
            }


            conn.Close();
           

        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Formtables : Form
    {
        private Buttons crtBtn;
        private FormTableInfo tableInfo;
        private const int width = 80;
        private const int heigth = 80;
        private const int perRows = 6;
        private const int spacing = 20;
        int salonno = 10;
        int balkonno = 14;
        int bahceno = 17;
        public Formtables()
        {
            InitializeComponent();
            crtBtn = new Buttons();
            tableInfo = new FormTableInfo();
        }

       
       

        private void sbtn_Click(object sender, EventArgs e)
        {
            var salonbtn = crtBtn.Create_Buttons(salonno, width, heigth, spacing, perRows);
            string salon = "Salon ";
            addButtonsToPanel(salonbtn,salon);
        }

        private void bbtn_Click(object sender, EventArgs e)
        {
            
            var balkonbtn = crtBtn.Create_Buttons(balkonno, width, heigth, spacing, perRows);
            string balkon = "Balkon ";
            addButtonsToPanel(balkonbtn, balkon);
        }

        private void babtn_Click(object sender, EventArgs e)
        {
            
            var bahcebtn = crtBtn.Create_Buttons(bahceno, width, heigth, spacing, perRows);
            string bahce = "Bahçe ";

            addButtonsToPanel(bahcebtn , bahce);
        }
        private void addButtonsToPanel(List<Button> buttonList, string name)
        {
             panel1.Controls.Clear();

            foreach (Button button in buttonList)
            {
                button.Text = button.Text.Insert(0,name);
                button.Click += new EventHandler(Click_Button);
                panel1.Controls.Add(button);
            }

        }
        public void Click_Button(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            tableInfo.ShowDialog();
        }

    }
}

using Cafe.Classes;
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
    public partial class FormTableInfo : Form
    {
        private Buttons buttons;
        private Menu menuItem;
        private AddItems addItem;
        public FormTableInfo()
        {
            InitializeComponent();

            buttons = new Buttons();
            menuItem = new Menu();
            addItem = new AddItems();
            
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
        private void ClickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            
            DataTable reader =  menuItem.GetItemInfos(button.Text); 
            dataGridView1.DataSource = reader;

            
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
    }
}

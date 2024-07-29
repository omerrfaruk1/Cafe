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
        public FormTableInfo()
        {
            InitializeComponent();
            buttons = new Buttons();
            menuItem = new Menu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            
            menuItem.AddItem("Dibek", "Kahve", 35);
            var buttonitem =  menuItem.GetItem("Kahve");

            for (int i = 0;i < buttonitem.Count; i++)
            {
                panel1.Controls.Add(buttonitem[i]);
            }

            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //string[] yiyecekler = ıtem.yiyecekler;

            //var btn = buttons.Create_Buttons(yiyecekler.Length, 50, 50, 10, 4);
            //for (int i = 0; i < yiyecekler.Length; i++)
            //{
            //    btn[i].Text = yiyecekler[i];
            //    panel1.Controls.Add(btn[i]);
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //string[] nargileler = ıtem.nargileler;

            //var btn = buttons.Create_Buttons(nargileler.Length, 50, 50, 10, 4);
            //for (int i = 0; i < nargileler.Length; i++)
            //{
            //    btn[i].Text = nargileler[i];
            //    panel1.Controls.Add(btn[i]);
            //}

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //string[] kahveler = ıtem.kahveler;

            //var btn = buttons.Create_Buttons(kahveler.Length, 50, 50, 10, 4);
            //for (int i = 0; i < kahveler.Length; i++)
            //{
            //    btn[i].Text = kahveler[i];
            //    panel1.Controls.Add(btn[i]);
            //}
        }

        private void FormTableInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

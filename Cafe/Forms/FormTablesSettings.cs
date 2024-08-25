using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace Cafe.Forms
{
    public partial class FormTablesSettings : Form
    {
        public int max;
        Formtables formtables = new Formtables();
        Buttons btn;

        public FormTablesSettings()
        {
            InitializeComponent();
            btn = new Buttons();

        }

        private void FormTablesSettings_Load(object sender, EventArgs e)
        {

            var myTablesName = formtables.getBtnInfo();
            if (myTablesName != null)
            {
                foreach (var table in myTablesName)
                {
                    comboBox1.Items.Add(table.Text);
                    comboBox1.SelectedIndex = 0;
                    
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            int txtValue = Convert.ToInt32(textBox3.Text);
            if (txtValue > 0)
            {
                if (comboBox1.AccessibilityObject.Value == "Bahçe")
                {
                    Properties.Settings.Default.BahceBtnNo = txtValue;
                }
                if(comboBox1.AccessibilityObject.Value == "Balkon")
                {
                    Properties.Settings.Default.BalkonBtnNo = txtValue;
                }
                if (comboBox1.AccessibilityObject.Value == "Salon"){
                    Properties.Settings.Default.SalonBtnNo = txtValue;
                }
                Properties.Settings.Default.Save();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

     
    }
}

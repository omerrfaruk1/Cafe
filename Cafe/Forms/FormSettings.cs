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
    public partial class FormSettings : Form
    {

        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTablesSettings formTablesSettings = new FormTablesSettings();
            formTablesSettings.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ıtemSettings = new FormItemsSettings();
            ıtemSettings.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormSettingsReports formSettingsReports = new FormSettingsReports();
            formSettingsReports.ShowDialog();
        }
    }
}

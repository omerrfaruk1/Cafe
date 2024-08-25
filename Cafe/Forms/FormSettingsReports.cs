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
    public partial class FormSettingsReports : Form
    {
        public FormSettingsReports()
        {
            InitializeComponent();
        }

        private void FormSettingsReports_Load(object sender, EventArgs e)
        {
            label1.Size = new System.Drawing.Size(this.Size.Width, 2);
            label3.Size = new System.Drawing.Size(this.Size.Width, 2);



        }
    }
}

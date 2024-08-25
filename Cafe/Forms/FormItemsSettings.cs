using Cafe.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe.Forms
{
    public partial class FormItemsSettings : Form
    {
        DataTable dt;
        Tables _table;
        SettingsItem _settings;

        public FormItemsSettings()
        {
            InitializeComponent();
            dt = new DataTable();
            _table = new Tables();
            _settings = new SettingsItem();
        }
        string cmd;
        private void FormItemsSettings_Load(object sender, EventArgs e)
        {

            FillTheDataGridView();
                
        }
        private void FillTheDataGridView()
        {
            dataGridView1.DataSource = "";
            SqlDataReader result = _settings.GetFullTables();

            dt.Load(result);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                label6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = "update";
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = "insert";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = "delete";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int txt1 = Convert.ToInt32(textBox1.Text);
            string txt2 = textBox2.Text;
            int txt3 = Convert.ToInt32(textBox3.Text);
            int categoryId = Convert.ToInt32(label6.Text);  
            
            if (cmd == "update")
            {
                _settings.UpdateDataBase(txt2,txt1,txt3);
            }
           if(cmd == "insert")
            {
                _settings.SetDataBase(txt2, txt3, categoryId);                
            }
           if(cmd == "delete")
            {
                int id = Convert.ToInt32(textBox1.Text);

                _settings.DeleteDataBase(id);
            }


            FillTheDataGridView();
        }
    }
}

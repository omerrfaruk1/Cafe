using Cafe.Interface;
using Microsoft.SqlServer.Server;
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

namespace Cafe
{
    public partial class Formtables : Form
    {   private readonly IDataAccessTable _table;
        private Buttons crtBtn;
        private FormTableInfo tableInfo;
        private Menu menu;
        private const int width = 85;
        private const int heigth = 85;
        private const int perRows = 6;
        private const int spacing = 20;
        int salonno = 6;
        int balkonno = 9;
        int bahceno = 7;
        public Formtables()
        {
            InitializeComponent();
            _table = new Tables();
            crtBtn = new Buttons();
            tableInfo = new FormTableInfo();
            menu = new Menu();
        }

        public void sbtn_Click(object sender, EventArgs e)
        {
            string bahce = "Salon";
            CreateBtn(bahce);
        }

        public void bbtn_Click(object sender, EventArgs e)
        {

            string bahce = "Balkon ";
            CreateBtn(bahce);
        }

        public void babtn_Click(object sender, EventArgs e)
        {
            string bahce = "Bahçe ";
            CreateBtn(bahce);
            
        }
        private void CreateBtn(string place)
        {
            var buttons = crtBtn.Create_Buttons(bahceno, width, heigth, spacing, perRows);
            addButtonsToPanel(buttons, place);
        }
        private void addButtonsToPanel(List<Button> buttonList, string name)
        {
             panel1.Controls.Clear();

            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Text = buttonList[i].Text.Insert(0, name);

                var reader = (SqlDataReader)_table.GetDataTableByName(buttonList[i].Text);
                if (reader.HasRows)
                {
                    buttonList[i].BackColor = Color.Green;
                }

                var readerC = (SqlDataReader) _table.GetDataTableByChanged(buttonList[i].Text);
                if (readerC.HasRows)
                {
                    buttonList[i].BackColor = Color.Red;
                }

                buttonList[i].Click += new EventHandler(Click_Button2);
                panel1.Controls.Add(buttonList[i]);
            }

        }
        public void Click_Button2(object sender,EventArgs e)
        {
            Button button = (Button)sender;
            tableInfo.label2.Text = button.Text;
            tableInfo.SetItemsInDataGridView();
            tableInfo.ShowDialog();
        }

        public void Formtables_Load(object sender, EventArgs e)
        {
             button1_Click(sender, e);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            List<string> results = new List<string>();
            string res;
            SqlDataReader result = (SqlDataReader) _table.GetAllFullTables();

            while (result.Read())
            {
                res = result.GetString(5);
                if (!results.Contains(res))
                {
                    results.Add(res);
                }
                else
                {
                    Console.WriteLine(res + "zaten mevcut"); 
                }
            }
            panel1.Controls.Clear();



            var allTable = crtBtn.Create_Buttons(results.Count, width , heigth, spacing, perRows);

            int i = 0;
            foreach(var ress in results)
            {

                allTable[i].Text = ress.ToString();
                allTable[i].BackColor = Color.Green;
                allTable[i].Click += new EventHandler(Click_Button2);
                panel1.Controls.Add(allTable[i]);
                i++;
            }


        }
    }
}

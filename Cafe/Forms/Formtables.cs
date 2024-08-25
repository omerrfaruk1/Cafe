using Cafe.Forms;
using Cafe.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Formtables : Form
    {   private readonly IDataAccessTable _table;
        private Buttons crtBtn;
        private FormTableInfo tableInfo;
        private Menu menu;
        public List<Button> list;
        private const int width = 85;
        private const int heigth = 85;
        private const int perRows = 6;
        private const int spacing = 20;
        int salonno = Properties.Settings.Default.SalonBtnNo;
        int balkonno = Properties.Settings.Default.BalkonBtnNo;
        int bahceno = Properties.Settings.Default.BahceBtnNo;

        public Formtables()
        {
            InitializeComponent();
            _table = new Tables();
            crtBtn = new Buttons();
            tableInfo = new FormTableInfo();
            menu = new Menu();
            list = new List<Button>();
        }
        public List<Button> getBtnInfo()
        {
            foreach(Control ctrl  in this.Controls) {

                if (ctrl is Button) {

                    if (ctrl.Text != "Dolu Masalar") {
                        list.Add((Button)ctrl);
                    }

                }
            }
            return list;
        }
        public void sbtn_Click(object sender, EventArgs e)
        {
            string salon = "Salon";
            CreateBtn(salon,salonno);
        }

        public void bbtn_Click(object sender, EventArgs e)
        {

            string balkon = "Balkon ";
            CreateBtn(balkon,balkonno);
        }

        public void babtn_Click(object sender, EventArgs e)
        {
            string bahce = "Bahçe ";
            CreateBtn(bahce,bahceno);
            
        }
        public void CreateBtn(string place,int btnNumber)
        {
            var buttons = crtBtn.Create_Buttons(btnNumber, width, heigth, spacing, perRows);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }
    }
}

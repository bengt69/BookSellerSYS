﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using BookSeller;
using ConsoleApplication2.View;

namespace ConsoleApplication2
{
    public partial class MainWindow : Form
    {
        private DataGridView dataGridView = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private Controller ctrl = new Controller();

        public MainWindow()
        {
            InitializeComponent();
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainWindow());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            string cm = "Select * From BookAd";
            bookListDataGridView.DataSource = BookAdDb.Read(cm);*/
            //listBox1.Items.AddRange(ctrl.getAllBookAds().ToArray());
            /*
            List<BookAd> l = ctrl.getAllBookAds();
            for (int i = 0; i < l.Count; i++)
            {
                listBox1.Items.Add(l);
            }*/
            //listBox1.DataSource = l;
            //listBox1.ValueMember = "Isbn";
            DataTable dt = new DataTable();
            dt = ctrl.getDataTableBookAds();
            DataRow tempRow = null;
            foreach (DataRow tempRowVar in dt.Rows)
            {
                tempRow = tempRowVar;
                listBox1.Items.Add(tempRow["Title"] + "       |       " + tempRow["Author"] + "       |       " + tempRow["Price"] + "       |       " + tempRow["Date"]);
            }
        }


        private void userAcButtonLogin_Click(object sender, EventArgs e)
        {

            //Textrutor visas
            userAcTextBoxFname.Visible = true;
            userAcTextBoxLname.Visible = true; 
            userAcTextBoxPnbr.Visible = true;
            userAcTextBoxCity.Visible = true;
            //Labels visas
            userAcLabelFname.Visible = true;
            userAcLabelLname.Visible = true;
            userAcLabelPnbr.Visible = true;
            userAcLabelCity.Visible = true;
            //Knappar och annat visas
            userAcButtonUpdateInfo.Visible = true;
            userAcButtonRemoveAc.Visible = true;
            userAcLabelAds.Visible = true;
            userAcFlowLayoutPanel.Visible = true;
            userAcButtonCreateAd.Visible = true;
            userAcButtonRemoveAd.Visible = true;
            userAcButtonRefresh.Visible = true;
        }

        private void userAcButtonCreateUsr_Click(object sender, EventArgs e)
        {
            DialogRegister dialogRegister = new DialogRegister();
            dialogRegister.ShowDialog();
        }

        private void userAcButtonCreateAd_Click(object sender, EventArgs e)
        {
            DialogNewAd dialogNewAd = new DialogNewAd();
            dialogNewAd.ShowDialog();
        }
    }
}

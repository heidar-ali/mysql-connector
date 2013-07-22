using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data;
using Devart.Data.MySql;

namespace mysql_connector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConn = new MySqlConnection();
                myConn.Host = "192.168.69.8";
                myConn.Port = 3306;
                myConn.UserId = "cody";
                myConn.Password = "greenstreetelite";
                myConn.Open();

                MySqlCommand myCommand = new MySqlCommand(" SELECT * FROM registration.regUser ;", myConn);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = myCommand;
                DataTable dbDataSet = new DataTable();
                myDataAdapter.Fill(dbDataSet);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbDataSet;
                dataGridView1.DataSource = bSource;
                myDataAdapter.Update(dbDataSet);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data.OleDb;
using System.Drawing.Imaging;

namespace AutoHome
{
    public partial class Collection : Form
    {
        public Collection()
        {
            InitializeComponent();
        }

        public OleDbConnection con;
        string todaydate;
        public void connection()
        {
            try
            {
                String constr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbhome.accdb;Jet OLEDB:Database Password=limattamil;");
                con = new OleDbConnection(constr);

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        public void get(string sql)
        {
            try
            {
               
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd1 = new OleDbCommand(sql, con);
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt1;
                long sum=0;
                textBox1.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32 (dt1.Rows[i][2].ToString());
                }
                textBox1.Text = sum.ToString();
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        public void get1(string sql)
        {
            try
            {

                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd1 = new OleDbCommand(sql, con);
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt1;
                long sum = 0;
                textBox1.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dt1.Rows[i][1].ToString());
                }
                textBox1.Text = sum.ToString();
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void Collection_Load(object sender, EventArgs e)
        {
            try
            {
                todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
                panel1.Enabled = false;
                connection();
                rbtnToday.Checked = true;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                rbtsubchange();
             }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnToday_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rbtchange()
        {
            try
            {
                if (rbtnToday.Checked == true)
                {
                    panel1.Enabled = false;
                    rbtsubchange();
                }
                else
                {
                    panel1.Enabled = true;
                    rbtnDaywise.Checked = true;
                    rbtsubchange();
                }


            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        
        private void rbtsubchange()
        {
            try
            {
                string dtpf = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                string dtpt = dateTimePicker2.Value.Month.ToString() + "/" + dateTimePicker2.Value.Day.ToString() + "/" + dateTimePicker2.Value.Year.ToString();

                if (rbtnToday.Checked == true)
                {
                    get("select p_id as Patient_Id,diagnosis as Diagnosis,fee as Fees from trans where tdate=#" + todaydate + "# order by tdate");

                }
                else
                {

                    if (rbtnDaywise.Checked == true)
                    {
                        get1(Convert.ToString("select tdate as Transaction_Date,sum(fee) as Fees from trans where tdate>=#" + dtpf  + "# and tdate<=#" + dtpt  + "# group by tdate order by tdate"));

                    }
                    else if (rbtnMonthwise.Checked == true)
                    {
                        get(Convert.ToString("select month(tdate) as Transaction_Month,year(tdate) as Transaction_Year,sum(fee) as Fees from trans where tdate>=#" + dtpf + "# and tdate<=#" + dtpt + "# group by month(tdate),year(tdate) order by year(tdate),month(tdate)"));

                    }
                    else
                    {
                        get1(Convert.ToString("select year(tdate) as Transaction_Year,sum(fee) as Fees from trans where tdate>=#" + dtpf + "# and tdate<=#" + dtpt + "# group by year(tdate) order by year(tdate)"));

                    }
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rbtsubchange();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            rbtsubchange();
        }

        private void rbtnDaywise_Click(object sender, EventArgs e)
        {
            rbtsubchange();
        }

        private void rbtnMonthwise_Click(object sender, EventArgs e)
        {
            rbtsubchange();
        }

        private void rbtnYearwise_Click(object sender, EventArgs e)
        {
            rbtsubchange();
        }

        private void rbtnToday_Click(object sender, EventArgs e)
        {
            rbtchange();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            rbtchange();
        }

        private void rbtnMonthwise_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
    }
}

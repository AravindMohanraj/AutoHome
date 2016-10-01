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
    public partial class Patienthistory : Form
    {
        public Patienthistory()
        {
            InitializeComponent();
        }

        public OleDbConnection con;

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
        private void rbtchange()
        {
            try
            {
                if (rbtnToday.Checked == true)
                {
                    panel2.Enabled = false;
                    rbtsubchange();
                }
                else
                {
                    panel2.Enabled = true;
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
                string todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
               

                string dtpf = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                string dtpt = dateTimePicker2.Value.Month.ToString() + "/" + dateTimePicker2.Value.Day.ToString() + "/" + dateTimePicker2.Value.Year.ToString();

                if (rbtnToday.Checked == true)
                {
                    get("select trans.p_id as Patient_Id,p_name as Patient_Name,gender as Gender,diagnosis as Diagnosis from trans,patient where patient.p_id=trans.p_id and trans.tdate=#" + todaydate  + "# ");

                }
                else
                {

                    if (rbtnDaywise.Checked == true)
                    {

                        get("select tdate as Transaction_Date,count(*) as No_of_Patients from trans where tdate>=#" + dtpf  + "# and tdate<=#" + dtpt  + "# group by tdate ");

                    }
                    else if (rbtnMonthwise.Checked == true)
                    {
                        get("select month(tdate)as Transaction_Month,year(tdate) as Transaction_Year,count(*) as No_of_Patients from trans where tdate>=#" + dtpf  + "# and tdate<=#" + dtpt  + "# group by year(tdate),month(tdate) ");
                    }
                    else
                    {

                        get("select year(tdate) as Transaction_Year,count(*) as No_of_Patients from trans where tdate>=#" + dtpf  + "# and tdate<=#" + dtpt  + "# group by year(tdate) ");
                    
                    }
                }



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
                dataGridView1.DataSource =null;
                dataGridView1.DataSource = dt1;


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
        private void rbtnDaywise_CheckedChanged(object sender, EventArgs e)
        {

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

        private void rbtnFrom_Click(object sender, EventArgs e)
        {
            rbtchange();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rbtsubchange();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            rbtsubchange();
        }

        private void Patienthistory_Load(object sender, EventArgs e)
        {
            try
            {

                panel2.Enabled = false;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbtnFrom_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

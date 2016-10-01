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
    public partial class AppointmentView : Form
    {
        public AppointmentView()
        {
            InitializeComponent();
        }
        public Appoinment app;
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AppointmentView_Load(object sender, EventArgs e)
        {

            try
            {
                
                app = new Appoinment();
                connection();
                dateTimePicker1.Value = DateTime.Now;
                get();
                dbgridbind();

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            } 
    

        }
        public void dbgridbind()
        {
            
            try
            {
                string todaydate = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                             
                dataGridView1.DataSource = null;
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmdname = new OleDbCommand("select p_id as Patient_id,p_name as Patient_name,cell_number as Mobile_Number,a_time as Appointment_Time from appointment where a_date=#"+todaydate+"# order by a_no", con);
                OleDbDataAdapter daname = new OleDbDataAdapter(cmdname);
                DataTable dtname = new DataTable();
                daname.Fill(dtname);

                dataGridView1.Refresh();
                dataGridView1.DataSource = dtname;
                label5.Text = "No of Patients:: " + dataGridView1.Rows.Count.ToString();
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }

        }
        public void get()
        {
    
            try
            {
                changecolor1();
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                string dtp = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();

                OleDbCommand cmd = new OleDbCommand("select a_no from appointment where a_date=#"+dtp  +"# ", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count ; i++)
                    {
                        changecolor2(dt.Rows[i][0].ToString());
                    }
                }
                
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

        public void changecolor1()
        {
                this.button1.BackColor = Color.PaleGreen;      
                this.button2.BackColor = Color.PaleGreen;    
                this.button3.BackColor = Color.PaleGreen;
                this.button4.BackColor = Color.PaleGreen;
                this.button5.BackColor = Color.PaleGreen;
                this.button6.BackColor = Color.PaleGreen;
                this.button7.BackColor = Color.PaleGreen;
                this.button8.BackColor = Color.PaleGreen;
                this.button9.BackColor = Color.PaleGreen;
                this.button10.BackColor = Color.PaleGreen;
                this.button11.BackColor = Color.PaleGreen;
                this.button12.BackColor = Color.PaleGreen;
                this.button13.BackColor = Color.PaleGreen;
                this.button14.BackColor = Color.PaleGreen;
                this.button15.BackColor = Color.PaleGreen;
                this.button16.BackColor = Color.PaleGreen;
                this.button17.BackColor = Color.PaleGreen;
                this.button18.BackColor = Color.PaleGreen;
                this.button19.BackColor = Color.PaleGreen;
                this.button20.BackColor = Color.PaleGreen;
                this.button21.BackColor = Color.PaleGreen;
                this.button22.BackColor = Color.PaleGreen;
                this.button23.BackColor = Color.PaleGreen;
                this.button24.BackColor = Color.PaleGreen;
                this.button25.BackColor = Color.PaleGreen;
                this.button26.BackColor = Color.PaleGreen;
                this.button27.BackColor = Color.PaleGreen;
                this.button28.BackColor = Color.PaleGreen;
                this.button29.BackColor = Color.PaleGreen;
                this.button30.BackColor = Color.PaleGreen;
                this.button31.BackColor = Color.PaleGreen;
                this.button32.BackColor = Color.PaleGreen;
                this.button33.BackColor = Color.PaleGreen;
                this.button34.BackColor = Color.PaleGreen;
                this.button35.BackColor = Color.PaleGreen;
                this.button36.BackColor = Color.PaleGreen;
                this.button37.BackColor = Color.PaleGreen;
                this.button38.BackColor = Color.PaleGreen;
                this.button39.BackColor = Color.PaleGreen;
                this.button40.BackColor = Color.PaleGreen;
                this.button41.BackColor = Color.PaleGreen;
                this.button42.BackColor = Color.PaleGreen;
                this.button43.BackColor = Color.PaleGreen;
                this.button44.BackColor = Color.PaleGreen;
                this.button45.BackColor = Color.PaleGreen;
                this.button46.BackColor = Color.PaleGreen;
                this.button47.BackColor = Color.PaleGreen;
                this.button48.BackColor = Color.PaleGreen;
                this.button49.BackColor = Color.PaleGreen;
                this.button50.BackColor = Color.PaleGreen;
                this.button51.BackColor = Color.PaleGreen;
                this.button52.BackColor = Color.PaleGreen;
                this.button53.BackColor = Color.PaleGreen;
                this.button54.BackColor = Color.PaleGreen;
                this.button55.BackColor = Color.PaleGreen;
                this.button56.BackColor = Color.PaleGreen;
                this.button57.BackColor = Color.PaleGreen;
                this.button58.BackColor = Color.PaleGreen;
                this.button59.BackColor = Color.PaleGreen;
                this.button60.BackColor = Color.PaleGreen;
                this.button61.BackColor = Color.PaleGreen;
                this.button62.BackColor = Color.PaleGreen;
                this.button63.BackColor = Color.PaleGreen;
                this.button64.BackColor = Color.PaleGreen;
                this.button65.BackColor = Color.PaleGreen;
                this.button66.BackColor = Color.PaleGreen;
                this.button67.BackColor = Color.PaleGreen;
                this.button68.BackColor = Color.PaleGreen;
                this.button69.BackColor = Color.PaleGreen;
                this.button70.BackColor = Color.PaleGreen;
                this.button71.BackColor = Color.PaleGreen;
                this.button72.BackColor = Color.PaleGreen;
                this.button73.BackColor = Color.PaleGreen;
                this.button74.BackColor = Color.PaleGreen;
                this.button75.BackColor = Color.PaleGreen;
                this.button76.BackColor = Color.PaleGreen;
                this.button77.BackColor = Color.PaleGreen;
                this.button78.BackColor = Color.PaleGreen;
                this.button79.BackColor = Color.PaleGreen;
                this.button80.BackColor = Color.PaleGreen;
                this.button81.BackColor = Color.PaleGreen;
                this.button82.BackColor = Color.PaleGreen;
                this.button83.BackColor = Color.PaleGreen;
                this.button84.BackColor = Color.PaleGreen;
                this.button85.BackColor = Color.PaleGreen;
                this.button86.BackColor = Color.PaleGreen;
                this.button87.BackColor = Color.PaleGreen;
                this.button88.BackColor = Color.PaleGreen;
                this.button89.BackColor = Color.PaleGreen;
                this.button90.BackColor = Color.PaleGreen;
                this.button91.BackColor = Color.PaleGreen;
                this.button92.BackColor = Color.PaleGreen;
                this.button93.BackColor = Color.PaleGreen;
                this.button94.BackColor = Color.PaleGreen;
                this.button95.BackColor = Color.PaleGreen;
                this.button96.BackColor = Color.PaleGreen;
                this.button97.BackColor = Color.PaleGreen;
                this.button98.BackColor = Color.PaleGreen;
                this.button99.BackColor = Color.PaleGreen;
                this.button100.BackColor = Color.PaleGreen;
                this.button101.BackColor = Color.PaleGreen;
                this.button102.BackColor = Color.PaleGreen;
               
                
        }

        public void changecolor2(string  no)
        {
            if (no == "1")
                this.button1.BackColor = Color.Coral;
            else if (no == "2")
                this.button2.BackColor = Color.Coral;
            else if (no == "3")
                this.button3.BackColor = Color.Coral;
            else if (no == "4")
                this.button4.BackColor = Color.Coral;
            else if (no == "5")
                this.button5.BackColor = Color.Coral;
            else if (no == "6")
                this.button6.BackColor = Color.Coral;
            else if (no == "7")
                this.button7.BackColor = Color.Coral;
            else if (no == "8")
                this.button8.BackColor = Color.Coral;
            else if (no == "9")
                this.button9.BackColor = Color.Coral;
            else if (no == "10")
                this.button10.BackColor = Color.Coral;
            else if (no == "11")
                this.button11.BackColor = Color.Coral;
            else if (no == "12")
                this.button12.BackColor = Color.Coral;
            else if (no == "13")
                this.button13.BackColor = Color.Coral;
            else if (no == "14")
                this.button14.BackColor = Color.Coral;
            else if (no == "15")
                this.button15.BackColor = Color.Coral;
            else if (no == "16")
                this.button16.BackColor = Color.Coral;
            else if (no == "17")
                this.button17.BackColor = Color.Coral;
            else if (no == "18")
                this.button18.BackColor = Color.Coral;
            else if (no == "19")
                this.button19.BackColor = Color.Coral;
            else if (no == "20")
                this.button20.BackColor = Color.Coral;
            else if (no == "21")
                this.button21.BackColor = Color.Coral;
            else if (no == "22")
                this.button22.BackColor = Color.Coral;
            else if (no == "23")
                this.button23.BackColor = Color.Coral;
            else if (no == "24")
                this.button24.BackColor = Color.Coral;
            else if (no == "25")
                this.button25.BackColor = Color.Coral;
            else if (no == "26")
                this.button26.BackColor = Color.Coral;
            else if (no == "27")
                this.button27.BackColor = Color.Coral;
            else if (no == "28")
                this.button28.BackColor = Color.Coral;
            else if (no == "29")
                this.button29.BackColor = Color.Coral;
            else if (no == "30")
                this.button30.BackColor = Color.Coral;
            else if (no == "31")
                this.button31.BackColor = Color.Coral;
            else if (no == "32")
                this.button32.BackColor = Color.Coral;
            else if (no == "33")
                this.button33.BackColor = Color.Coral;
            else if (no == "34")
                this.button34.BackColor = Color.Coral;
            else if (no == "35")
                this.button35.BackColor = Color.Coral;
            else if (no == "36")
                this.button36.BackColor = Color.Coral;
            else if (no == "37")
                this.button37.BackColor = Color.Coral;
            else if (no == "38")
                this.button38.BackColor = Color.Coral;
            else if (no == "39")
                this.button39.BackColor = Color.Coral;
            else if (no == "40")
                this.button40.BackColor = Color.Coral;
            else if (no == "41")
                this.button41.BackColor = Color.Coral;
            else if (no == "42")
                this.button42.BackColor = Color.Coral;
            else if (no == "43")
                this.button43.BackColor = Color.Coral;
            else if (no == "44")
                this.button44.BackColor = Color.Coral;
            else if (no == "45")
                this.button45.BackColor = Color.Coral;
            else if (no == "46")
                this.button46.BackColor = Color.Coral;
            else if (no == "47")
                this.button47.BackColor = Color.Coral;
            else if (no == "48")
                this.button48.BackColor = Color.Coral;
            else if (no == "49")
                this.button49.BackColor = Color.Coral;
            else if (no == "50")
                this.button50.BackColor = Color.Coral;
            else if (no == "51")
                this.button51.BackColor = Color.Coral;
            else if (no == "52")
                this.button52.BackColor = Color.Coral;
            else if (no == "53")
                this.button53.BackColor = Color.Coral;
            else if (no == "54")
                this.button54.BackColor = Color.Coral;
            else if (no == "55")
                this.button55.BackColor = Color.Coral;
            else if (no == "56")
                this.button56.BackColor = Color.Coral;
            else if (no == "57")
                this.button57.BackColor = Color.Coral;
            else if (no == "58")
                this.button58.BackColor = Color.Coral;
            else if (no == "59")
                this.button59.BackColor = Color.Coral;
            else if (no == "60")
                this.button60.BackColor = Color.Coral;
            else if (no == "61")
                this.button61.BackColor = Color.Coral;
            else if (no == "62")
                this.button62.BackColor = Color.Coral;
            else if (no == "63")
                this.button63.BackColor = Color.Coral;
            else if (no == "64")
                this.button64.BackColor = Color.Coral;
            else if (no == "65")
                this.button65.BackColor = Color.Coral;
            else if (no == "66")
                this.button66.BackColor = Color.Coral;
            else if (no == "67")
                this.button67.BackColor = Color.Coral;
            else if (no == "68")
                this.button68.BackColor = Color.Coral;
            else if (no == "69")
                this.button69.BackColor = Color.Coral;
            else if (no == "70")
                this.button70.BackColor = Color.Coral;
            else if (no == "71")
                this.button71.BackColor = Color.Coral;
            else if (no == "72")
                this.button72.BackColor = Color.Coral;
            else if (no == "73")
                this.button73.BackColor = Color.Coral;
            else if (no == "74")
                this.button74.BackColor = Color.Coral;
            else if (no == "75")
                this.button75.BackColor = Color.Coral;
            else if (no == "76")
                this.button76.BackColor = Color.Coral;
            else if (no == "77")
                this.button77.BackColor = Color.Coral;
            else if (no == "78")
                this.button78.BackColor = Color.Coral;
            else if (no == "79")
                this.button79.BackColor = Color.Coral;
            else if (no == "80")
                this.button80.BackColor = Color.Coral;
            else if (no == "81")
                this.button81.BackColor = Color.Coral;
            else if (no == "82")
                this.button82.BackColor = Color.Coral;
            else if (no == "83")
                this.button83.BackColor = Color.Coral;
            else if (no == "84")
                this.button84.BackColor = Color.Coral;
            else if (no == "85")
                this.button85.BackColor = Color.Coral;
            else if (no == "86")
                this.button86.BackColor = Color.Coral;
            else if (no == "87")
                this.button87.BackColor = Color.Coral;
            else if (no == "88")
                this.button88.BackColor = Color.Coral;
            else if (no == "89")
                this.button89.BackColor = Color.Coral;
            else if (no == "90")
                this.button90.BackColor = Color.Coral;
            else if (no == "91")
                this.button91.BackColor = Color.Coral;
            else if (no == "92")
                this.button92.BackColor = Color.Coral;
            else if (no == "93")
                this.button93.BackColor = Color.Coral;
            else if (no == "94")
                this.button94.BackColor = Color.Coral;
            else if (no == "95")
                this.button95.BackColor = Color.Coral;
            else if (no == "96")
                this.button96.BackColor = Color.Coral;
            else if (no == "97")
                this.button97.BackColor = Color.Coral;
            else if (no == "98")
                this.button98.BackColor = Color.Coral;
            else if (no == "99")
                this.button99.BackColor = Color.Coral;
            else if (no == "100")
                this.button100.BackColor = Color.Coral;
            else if (no == "101")
                this.button101.BackColor = Color.Coral;
            else if (no == "102")
                this.button102.BackColor = Color.Coral;
        }

        private void btnClick(string no,string bname)
        {
            try
            {

                app.dat = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                app.tim =bname;
                app.no = no;
                app.appview = this;
                //this.Hide();
                this.Hide();
                
                app.Show();
                app.temp1();
                
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("1", button1.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button2.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("2", button2.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (button3.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("3", button3.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (button4.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("4", button4.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (button5.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("5", button5.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (button6.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("6", button6.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (button7.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("7", button7.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (button8.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("8", button8.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (button9.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("9", button9.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (button10.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true; btnClick("10", button10.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (button11.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("11", button11.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (button12.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("12", button12.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
        }

        private void button18_Click(object sender, EventArgs e)
        {
           
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
          
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (button22.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("22", button22.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
           
        }

        private void button24_Click(object sender, EventArgs e)
        {
           
        }

        private void button25_Click(object sender, EventArgs e)
        {
           
        }

        private void button26_Click(object sender, EventArgs e)
        {
           
        }

        private void button27_Click(object sender, EventArgs e)
        {
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
           
        }

        private void button29_Click(object sender, EventArgs e)
        {
           
        }

        private void button30_Click(object sender, EventArgs e)
        {
           
        }

        private void button31_Click(object sender, EventArgs e)
        {
            
        }

        private void button32_Click(object sender, EventArgs e)
        {
            
        }

        private void button33_Click(object sender, EventArgs e)
        {
          
        }

        private void button34_Click(object sender, EventArgs e)
        {
           
        }

        private void button35_Click(object sender, EventArgs e)
        {
            
        }

        private void button36_Click(object sender, EventArgs e)
        {
           
        }
       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            get();
            dbgridbind();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button27.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("27", button27.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button37_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (button37.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("37", button37.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {

            try
            {
                if (button38.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("38", button38.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {

            try
            {
                if (button39.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("39", button39.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {

            try
            {
                if (button40.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("40", button40.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            try
            {
                if (button41.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("41", button41.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                if (button42.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("42", button42.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            try
            {
                if (button43.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("43", button43.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            try
            {
                if (button44.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("44", button44.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            try
            {
                if (button45.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("45", button45.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            try
            {
                if (button46.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("46", button46.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            try
            {
                if (button47.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("47", button47.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            try
            {
                if (button48.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("48", button48.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            try
            {
                if (button49.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("49", button49.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            try
            {
                if (button50.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("50", button50.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            try
            {
                if (button51.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("51", button51.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button13.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("13", button13.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button14.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("14", button14.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button15.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("15", button15.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button16.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("16", button16.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button17_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (button17.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("17", button17.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button18.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("18", button18.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button19.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("19", button19.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button20.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("20", button20.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button21.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("21", button21.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button23.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("23", button23.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button24.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("24", button24.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button25.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("25", button25.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button26.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("26", button26.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button36_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button36.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("36", button36.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button35_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button35.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("35", button35.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button34.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("34", button34.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button33.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("33", button33.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button32_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button32.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("32", button32.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button31_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button31.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("31", button31.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button30.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("30", button30.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button29.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("29", button29.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (button28.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("28", button28.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            try
            {
                if (button52.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("52", button52.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            try
            {
                if (button53.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("53", button53.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            try
            {
                if (button54.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("54", button54.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            try
            {
                if (button55.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("55", button55.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            try
            {
                if (button56.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("56", button56.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            try
            {
                if (button57.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("57", button57.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button58_Click(object sender, EventArgs e)
        {
            try
            {
                if (button58.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("58", button58.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button59_Click(object sender, EventArgs e)
        {
            try
            {
                if (button59.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("59", button59.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button60_Click(object sender, EventArgs e)
        {
            try
            {
                if (button60.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("60", button60.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            try
            {
                if (button61.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("61", button61.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void button62_Click(object sender, EventArgs e)
        {
            try
            {
                if (button62.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("62", button62.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            try
            {
                if (button63.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("63", button63.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            try
            {
                if (button64.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("64", button64.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            try
            {
                if (button65.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("65", button65.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {
            try
            {
                if (button66.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("66", button66.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button67_Click(object sender, EventArgs e)
        {
            try
            {
                if (button67.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("67", button67.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            try
            {
                if (button68.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("68", button68.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button69_Click(object sender, EventArgs e)
        {
            try
            {
                if (button69.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("69", button69.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button70_Click(object sender, EventArgs e)
        {
            try
            {
                if (button70.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("70", button70.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button71_Click(object sender, EventArgs e)
        {
            try
            {
                if (button71.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("71", button71.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void button72_Click(object sender, EventArgs e)
        {
            try
            {
                if (button72.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("72", button72.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            try
            {
                if (button73.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("73", button73.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            try
            {
                if (button74.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("74", button74.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button75_Click(object sender, EventArgs e)
        {
            try
            {
                if (button75.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("75", button75.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button86_Click(object sender, EventArgs e)
        {
            try
            {
                if (button86.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("86", button86.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button87_Click(object sender, EventArgs e)
        {
            try
            {
                if (button87.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("87", button87.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button88_Click(object sender, EventArgs e)
        {
            try
            {
                if (button88.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("88", button88.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button89_Click(object sender, EventArgs e)
        {
            try
            {
                if (button89.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("89", button89.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button90_Click(object sender, EventArgs e)
        {
            try
            {
                if (button90.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("90", button90.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button91_Click(object sender, EventArgs e)
        {
            try
            {
                if (button91.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("91", button91.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void button92_Click(object sender, EventArgs e)
        {
            try
            {
                if (button92.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("92", button92.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button93_Click(object sender, EventArgs e)
        {
            try
            {
                if (button93.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("93", button93.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            try
            {
                if (button94.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("94", button94.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            try
            {
                if (button95.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("95", button95.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button96_Click(object sender, EventArgs e)
        {
            try
            {
                if (button96.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("96", button96.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button97_Click(object sender, EventArgs e)
        {
            try
            {
                if (button97.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("97", button97.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button98_Click(object sender, EventArgs e)
        {
            try
            {
                if (button98.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("98", button98.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button99_Click(object sender, EventArgs e)
        {
            try
            {
                if (button99.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("99", button99.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button100_Click(object sender, EventArgs e)
        {
            try
            {
                if (button100.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("100", button100.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }



        private void button83_Click(object sender, EventArgs e)
        {
            try
            {
                if (button83.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("83", button83.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button84_Click(object sender, EventArgs e)
        {
            try
            {
                if (button84.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("84", button84.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button85_Click(object sender, EventArgs e)
        {
            try
            {
                if (button85.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("85", button85.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            try
            {
                if (button76.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("76", button76.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            try
            {
                if (button77.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("77", button77.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button78_Click(object sender, EventArgs e)
        {
            try
            {
                if (button78.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("78", button78.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button79_Click(object sender, EventArgs e)
        {
            try
            {
                if (button79.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("79", button79.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button80_Click(object sender, EventArgs e)
        {
            try
            {
                if (button80.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("80", button80.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void button81_Click(object sender, EventArgs e)
        {
            try
            {
                if (button81.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("81", button81.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void button82_Click(object sender, EventArgs e)
        {
            try
            {
                if (button82.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("82", button82.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }


        private void button101_Click(object sender, EventArgs e)
        {
            try
            {
                if (button101.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("101", button101.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }


        private void button102_Click(object sender, EventArgs e)
        {
            try
            {
                if (button102.BackColor == Color.PaleGreen)
                    app.b = false;
                else
                    app.b = true;
                btnClick("102", button102.Text);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }


        public void delete()
        {

            try
            {

                string todaydate = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
              

                if(dataGridView1.SelectedRows.Count  != 0 )
                {
                    if (con.State.Equals(ConnectionState.Closed))
                    {
                        con.Open();
                    }
                    OleDbCommand cmd2 = new OleDbCommand("delete from appointment where a_date=#" + todaydate + "# and a_time='" + dataGridView1[3,dataGridView1.CurrentRow.Index].Value.ToString() + "'", con);
                    int flag = cmd2.ExecuteNonQuery();
                    dbgridbind();
                    get();
                   
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                else
                    MessageBox.Show("Select the patient Details");

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }
        private void button105_Click(object sender, EventArgs e)
        {
            delete();
        }
     

    }
}

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
    public partial class doctorview : Form
    {
        public doctorview()
        {
            InitializeComponent();
        }
        public OleDbConnection con;
        public int flag1 = 0;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
       
        public void sizing()
        {
            int w = this.Width;
            int h = this.Height-100;
            panelpatient.Location = new Point(5,50);
            panelpatient.Size = new Size(w / 4+20, h / 5+10);

            panellastvist.Location = new Point(5, h / 5  + 80);
            panellastvist.Size = new Size(w / 4+20, h / 5);

            paneldiagnosis.Location = new Point(5, h / 5*2+100);
            paneldiagnosis.Size = new Size(w / 4+5, h / 5*2+10);

            checkedListBox1.Location = new Point(5, 20);
            checkedListBox1.Size = new Size(paneldiagnosis.Width - 10, paneldiagnosis.Height - 15);
        }


        private void doctorview_Load(object sender, EventArgs e)
        {
           // sizing();
            connection();
           
            temp();
            txtid.Text = "";
            flag1 = 1;
            get_next_patient(); 
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_prescription();
        }
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
        public void get_prescription()
        {
            try
            {
                string str;
                int temp_var=0;
                str = "select presc,tdate from trans where p_id='" + txtid.Text + "' ";
                
                if (checkedListBox1.CheckedItems .Count>0)
                    str += "and ";
                for (int i = 0; i < checkedListBox1.Items.Count-1; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        str += " diagnosis='" + checkedListBox1.Items[i].ToString() + "' ";
                        temp_var = 1;
                    }
                    if (checkedListBox1.GetItemChecked(i + 1) && temp_var == 1)
                    {
                        str += " or ";
                        temp_var = 0;
                    }
                }
                if (checkedListBox1.CheckedItems.Count > 0 && checkedListBox1.GetItemChecked(checkedListBox1.Items.Count - 1))
                    str += " diagnosis='" + checkedListBox1.Items[checkedListBox1.Items.Count - 1].ToString() + "' ";
                str += " order by tdate desc";
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand(str, con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                panel1.Controls.Clear();

                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                       Bitmap img = new Bitmap(".\\prescriptions\\"+dt.Rows [i][0].ToString ()); //Load a png image
                        
                       PictureBox prev = new PictureBox();
                       Label l = new Label();
                       l.Text = dt.Rows[i][1].ToString();
                       l.BackColor = Color.White;
                       l.Parent = panel1;
                       l.Location = new Point(panel1.Width / 2 - l.Width / 2, i * panel1.Height+50);

                       prev.Parent = panel1;
                        prev.Image = img;
                     
                        prev.SizeMode = PictureBoxSizeMode.StretchImage;

                        prev.Location = new Point(50, i * panel1.Height +50);
                        prev.Size = new Size(panel1.Width - 100, panel1.Height );
                        
                      
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

        public void get_diagnosis_list()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                checkedListBox1.Items.Clear();
                OleDbCommand cmd = new OleDbCommand("select distinct diagnosis from trans where p_id='"+txtid.Text +"'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                checkedListBox1.Refresh();
                    for (int i=0;i<dt.Rows.Count;i++)
                    {
                        checkedListBox1 .Items .Add ( dt.Rows[i][0].ToString());
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
        public void temp()
        {
            // MessageBox.Show("dsd");
            txtid.DataSource = null;

            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select * from patient order by p_id", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtid.Refresh();

                txtid.DataSource = dt;
                txtid.DisplayMember = "p_id";
                //txtid.ValueMember = "diag";

                txtid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                txtid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtid.AutoCompleteSource = AutoCompleteSource.ListItems;

                // MessageBox.Show("dsd");
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        public void get_next_patient()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select p_id from tday where visiting='cur'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                OleDbCommand cmd1 = new OleDbCommand("select p_id from tday", con);
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (txtid.Text != dt.Rows[0][0].ToString())
                        {

                            txtid.Text = dt.Rows[0][0].ToString();
                            get_patient_details();
                            lastvisit();

                            get_diagnosis_list();

                            get_prescription();
                        }
                        else
                        {
                            label9.ForeColor = Color.Red;
                            label9.Text = "Current Patient not yet SAVED!!!";
                            OleDbCommand cmd2 = new OleDbCommand("update flag set doctor='1'", con);
                            cmd2.ExecuteNonQuery();
                            timer1.Start();
                        }
                            
                       
                    }
                    else
                    {
                        label9.ForeColor = Color.Red;
                        label9.Text ="Next Patient not yet ASSIGNED!!!";

                    }
                }
                else
                {
                    label9.ForeColor = Color.Red;
                     label9.Text ="Waiting list is empty!!!";

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
        public void get_patient_details()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select p_name,date_of_birth from patient where p_id='"+txtid.Text +"'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    textBox1 .Text = dt.Rows[0][0].ToString();
                    DateTime d = new DateTime();
                    d = Convert.ToDateTime(dt.Rows[0][1]);
                    textBox3 .Text = (DateTime .Now.Year - d.Year ).ToString ();
                    
                }
                else
                {
                    MessageBox.Show("Invalid ID");
                   
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
        public void lastvisit()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select tdate,diagnosis from trans where p_id='" + txtid.Text + "'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DateTime d = new DateTime();
                    d = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1][0]);
                    textBox4.Text = d.ToShortDateString();
                    textBox5.Text = dt.Rows[dt.Rows.Count - 1][1].ToString();
                    
                }
                else
                {
                    textBox4.Clear();
                    textBox5.Clear();
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
     
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
       
                    e.Handled = true;
                
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                e.Handled = true;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                e.Handled = true;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                e.Handled = true;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                e.Handled = true;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

     

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            //temp();
            
        }

        private void pictureprevious_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           // OleDbCommand cmd1 = new OleDbCommand("insert tdate,diagnosis from trans where p_id='" + txtid.Text + "'", con);
            
  

            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                
                OleDbCommand cmd = new OleDbCommand("select doctor from flag", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0][0].ToString() == "0")
                {
                    OleDbCommand cmd4 = new OleDbCommand("update flag set pharmacy='1'", con);
                    cmd4.ExecuteNonQuery();
                    label9.ForeColor = Color.Red;
                    label9.Text = "Current Patient Not Yet Saved.";

                }
                else
                {
                    get_next_patient();
                    OleDbCommand cmd5 = new OleDbCommand("update flag set doctor='0',pharmacy='0'", con);
                    cmd5.ExecuteNonQuery();
                    label9.ForeColor = Color.Red;
                    label9.Text = "Current Patient Not Yet Saved.";

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

        private void txtid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flag1==1)
            {
            get_patient_details();
            lastvisit();
            get_diagnosis_list();
            get_prescription();
            }
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else if ((int)e.KeyChar == 13)
                {
                    get_patient_details();
                    lastvisit();
                    get_diagnosis_list();
                    get_prescription();

                }
                else
                {
                   
                    e.Handled = true;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }

                OleDbCommand cmd = new OleDbCommand("select doctor from flag", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    OleDbCommand cmd4 = new OleDbCommand("update flag set pharmacy='0'", con);
                    cmd4.ExecuteNonQuery();
                    label9.ForeColor = Color.Green ;
                    label9.Text = "You Can Visit Next Patient.";

                }
                else
                {
                    label9.ForeColor = Color.Red;
                    label9.Text = "Current Patient Not Yet Saved.";

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

       

       
    }
}

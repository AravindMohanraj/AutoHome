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
    public partial class pharmacy : Form
    {
        public pharmacy()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        [DllImport("user32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        [DllImport("user32.dll")]
        static extern IntPtr SetActiveWindow(IntPtr hWnd);
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WS_MAXIMIZE = 0x01000000;        
        Process notepad = new Process();
        public OleDbConnection con;
        public long newtid;
        public int checknext;
        String tday = DateTime.Now.ToShortDateString(),str=null;

        public void temp()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select * from diagnosis order by diag", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbDiagnosis.Refresh();

                cmbDiagnosis.DataSource = dt;
                cmbDiagnosis.DisplayMember = "diag";
                //cmbDiagnosis.ValueMember = "diag";
                cmbDiagnosis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cmbDiagnosis.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbDiagnosis.AutoCompleteSource = AutoCompleteSource.ListItems;


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
        public void get_prescription()
        {
            try
            {
               
                string todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
                string str;
                str = "select patient.p_id,p_name,gender,presc from trans,patient where patient.p_id=trans.p_id and tdate=#" +todaydate+ "# ";
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand(str, con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                panel6.Controls.Clear();
                int j = 0;
                for (int i = dt.Rows.Count-1; i >=0 ; i--,j++)
                {
                    Bitmap img = new Bitmap(".\\prescriptions\\" + dt.Rows[i][3].ToString() + ".*"); //Load a png image
                  PictureBox prev = new PictureBox();
                  Label l = new Label();
                    string lblstr= dt.Rows[i][0].ToString()+"    |   "+ dt.Rows[i][1].ToString() +"    |    "+ dt.Rows[i][2].ToString();
                    l.Text = lblstr;
                   
                    l.BackColor = Color.White;
                    l.Parent = panel6;
                    l.Location = new Point(100, j * panel6.Height + 50);
                    l.Size = new Size(panel6.Width - 100, 20);
                   
                    prev.Parent = panel6;
                    prev.Image = img;
                    prev.SizeMode = PictureBoxSizeMode.StretchImage;
                    prev.Location = new Point(50, j * panel6.Height + 50);
                    prev.Size = new Size(panel6.Width - 100, panel6.Height-20);
                }
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show("hh"+excep.Message);
            }
        }
        int tim1 = 0;
        private void pharmacy_Load(object sender, EventArgs e)
        {
            txtid.DropDownStyle = ComboBoxStyle.Simple;
          
            try
            {
                this.WindowState = FormWindowState.Maximized;
                int w = this.Size.Width;
                int h = this.Size.Height;


                panel2.Location = new Point(0, 0 );
                panel2.Size = new Size(300 , h - 50);

                panel10.Location = new Point((this.Size.Width -panel10.Size.Width )/2+30, this.Size.Height/2-30);

                panel1.Location = new Point(0, (h - 50) / 15);
                panel1.Size = new Size(300,( h - 50)/15*7); 

                pnlProcess.Location = new Point(320, 5);
                pnlProcess.Size = new Size(w -350, h - 50);

                panel6.Location = new Point(320, 5);
                panel6.Size = new Size(w - 350, h - 50);

               

                panel4.Location = new Point(5, 0);
                panel4.Size = new Size(300, (h - 50) / 15);

               // btnNow .Location = new Point(5, (h - 50)/15*13);

               // button4.Location = new Point(150, (h - 50) / 15 * 13);

                panel8.Location = new Point(5, (h - 50) / 15 * 8);
                panel9 .Location = new Point(0, h - 50);
                panel9.Size = new Size(w, 25);

                btnNow.Enabled = false;
                panel6.Hide();

                newprocess();
                connection();
                set_default();
                temp();
                cmbDiagnosis.Text = "";
                txtid.Text = "";
                checknext = 0;
                get_next_patient ();
                cmbDiagnosis.Focus();
                timer2.Start();
                

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
               
            }
        }
        public void get_next_patient()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select p_id from tday where visiting='cur' or visiting='next'", con);
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
                        //try
                        //{

                        //    if (str != null)
                        //    {
                        //        Bitmap img = new Bitmap(".\\prescriptions\\" + str.ToString() + ".bmp"); //Load a png image

                        //        picPrescription.Image = img;
                        //        btnPrevious.BackgroundImage = img;
                        //    }
                        //}
                        //catch (System.Exception excep)
                        //{
                        //    MessageBox.Show(excep.Message);
                        //}

                            txtid.Text = dt.Rows[0][0].ToString();
                            get_patient_details();
                            if (con.State.Equals(ConnectionState.Closed))
                            {
                                con.Open();
                            }
                            OleDbCommand cmd2 = new OleDbCommand("update tday set visiting='cur' where p_id='"+txtid .Text +"'", con);
                            cmd2.ExecuteNonQuery();
                            if (con.State.Equals(ConnectionState.Open))
                            {
                                con.Close();
                            }
                            str = txtid.Text.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString()+".jpg";
                            Clipboard.SetText(str.ToString());

                            

                    }
                    else
                    {
                        MessageBox.Show("Next Patient not yet ASSIGNED!!!");

                    }
                }
                else
                {
                    MessageBox.Show("Waiting list is empty!!!");

                }
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show("get next patient"+excep.Message);
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
        }
        public void get_patient_details()
        {
            try
            {
                if (con.State.Equals(ConnectionState .Closed ))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select p_name,gender from patient where p_id='" + txtid.Text + "'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0][0].ToString();
                    txtGender.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("Invalid ID");
                    clear();
                    txtid.Focus();

                }
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show("get pat detail" + excep.Message);
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
        }


        public void set_trans_details()
        {
            try
            {
                if (txtid.Text != "")
                {
                    if (cmbDiagnosis.Text != "")
                    {
                        if (txtAmount.Text != "")
                        {

                            if (con.State.Equals(ConnectionState.Closed))
                            {
                                con.Open();
                            }
                            OleDbCommand cmd1 = new OleDbCommand("select * from diagnosis where diag='" + cmbDiagnosis.Text + "'", con);
                            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);

                            if (dt1.Rows.Count == 0)
                            {
                                if (con.State.Equals(ConnectionState.Closed))
                                {
                                    con.Open();
                                }
                                OleDbCommand cmd2 = new OleDbCommand("insert into diagnosis values('" + cmbDiagnosis.Text + "')", con);
                                int flag2 = cmd2.ExecuteNonQuery();
                                temp();
                                if (con.State.Equals(ConnectionState.Closed))
                                {
                                    con.Open();
                                }
                            }
                            if (con.State.Equals(ConnectionState.Closed))
                            {
                                con.Open();
                            }
                            OleDbCommand cmd = new OleDbCommand("insert into trans(p_id,tdate,diagnosis,presc,fee) values('" + txtid.Text + "','" + tday + "','" + cmbDiagnosis.Text + "','" + str + "','" + txtAmount.Text + "')", con);
                            
                            int flag = cmd.ExecuteNonQuery();
                            if (flag == 1)
                            {
                               
                                string todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
                                MessageBox.Show("Saved Successfully");
                                str = Clipboard.GetText();
                                if (con.State.Equals(ConnectionState.Closed))
                                {
                                    con.Open();
                                }
                                OleDbCommand cmd2 = new OleDbCommand("delete from tday  where p_id='" + txtid.Text + "'", con);
                                cmd2.ExecuteNonQuery();
                                if (con.State.Equals(ConnectionState.Closed))
                                {
                                    con.Open();
                                }
                                OleDbCommand cmd3 = new OleDbCommand("delete from appointment  where p_id='" + txtid.Text + "' and a_date=#" + todaydate + "#", con);
                                cmd3.ExecuteNonQuery();
                                if (con.State.Equals(ConnectionState.Closed))
                                {
                                    con.Open();
                                }
                                OleDbCommand cmd4 = new OleDbCommand("update flag set doctor='1',pharmacy='0'", con);
                                cmd4.ExecuteNonQuery();
                         
                                clear();
                                get_next_patient();
                                cmbDiagnosis.Focus();
                                
                            }
                            else
                            {
                                MessageBox.Show("Not saved");
                            }
                            if (con.State.Equals(ConnectionState.Open))
                            {
                                con.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Amount");
                            txtAmount.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Diagnosis");
                        cmbDiagnosis.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Enter Patient ID");
                    txtid.Focus();
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show("set trans" + excep.Message);
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
            }
        }

        public void set_default()
        {
            try
            {
                            if (con.State.Equals(ConnectionState.Closed))
                            {
                                con.Open();
                            }
                                OleDbCommand cmd2 = new OleDbCommand("update flag set doctor='0',pharmacy='0'", con);
                                cmd2.ExecuteNonQuery();

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

        public void clear()
        {
            try
            {
                txtid.Text="";
                txtName.Clear();
                txtGender.Clear();
                txtAmount.Clear();
                cmbDiagnosis.Text = "";
                txtid.Focus();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }

        public void newprocess()
        {
             try
            {
                ProcessStartInfo psi = new ProcessStartInfo("C:\\Program Files\\ACECAD\\ACECAD DigiMemo Manager\\DigiMemoManager.exe");
                psi.WindowStyle = ProcessWindowStyle.Normal;
                notepad.StartInfo = psi;


                notepad.Start();
                Thread.Sleep(2000);
                // notepad.WaitForInputIdle(500);
                
                IntPtr old = SetParent(notepad.MainWindowHandle, this.pnlProcess.Handle);

                SetWindowLong(notepad.MainWindowHandle, GWL_STYLE, WS_VISIBLE + WS_MAXIMIZE);
                MoveWindow(notepad.MainWindowHandle, 0, 0, pnlProcess.Size.Width, pnlProcess.Size.Height, true);

                SetActiveWindow(notepad.MainWindowHandle);
                SwitchToThisWindow(notepad.MainWindowHandle, true);
            }
             catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                
            }

        }


     
       
        private void btnPrevious_Click(object sender, EventArgs e)
        {
             try
            {
               
               
                pnlProcess.Hide();
               // picPrescription.SizeMode = PictureBoxSizeMode.StretchImage;
                
              //  picPrescription.Show();
                get_prescription();
                panel6.Show();
                btnNow.Enabled = true;
                btnPrevious.Enabled = false;
                btnSave.Enabled = false;
                btnClear.Enabled = false;

            }
             catch (System.Exception excep)
             {
                 MessageBox.Show(excep.Message);
                 
             }
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
             try
            {
                btnClear.Enabled = true;
                btnSave.Enabled = true ;
               // picPrescription.Hide();
                panel6.Hide();
                pnlProcess.Show();
               
                btnPrevious.Enabled = true;
                btnNow.Enabled = false;
               
            }
             catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                
            }
        }

       
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGender_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else if ((int)e.KeyChar == 13)
                {
                    btnSave.Focus();
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    Bitmap img = new Bitmap(".\\prescriptions\\" + Clipboard .GetText ()); //Load a png image

                    set_trans_details();
                    checknext = 0;
                    if (con.State.Equals(ConnectionState.Closed))
                    {
                        con.Open();
                    }
                    OleDbCommand cmd1 = new OleDbCommand("update flag set doctor='0'", con);
                    cmd1.ExecuteNonQuery();
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();
                    }
                          
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("You need to save the prescription first !!!");
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show("savebtn"+excep.Message);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           
                try
                {
                    if (txtid.Text != "")
                    {
                        OleDbCommand cmd2, cmd3, cmd4;
                        
                                if (con.State.Equals(ConnectionState.Closed))
                                {
                                    con.Open();
                                }
                                DialogResult ret;
                                ret = MessageBox.Show("Are you skip this patient.!", "Remove".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        
                                if (ret == DialogResult.Yes)
                                {
                                    string todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
                                     cmd2 = new OleDbCommand("delete from tday  where p_id='" + txtid.Text + "'", con);
                                     if (con.State.Equals(ConnectionState.Closed))
                                     {
                                         con.Open();
                                     }
                                    cmd2.ExecuteNonQuery();
                        
                                    cmd3 = new OleDbCommand("delete from appointment  where p_id='" + txtid.Text + "' and a_date=#" + todaydate + "#", con);
                                    if (con.State.Equals(ConnectionState.Closed))
                                    {
                                        con.Open();
                                    }
                                    cmd3.ExecuteNonQuery();
                        
                                     cmd4 = new OleDbCommand("update flag set doctor='1',pharmacy='0'", con);
                                     if (con.State.Equals(ConnectionState.Closed))
                                     {
                                         con.Open();
                                     }
                                    cmd4.ExecuteNonQuery();
                        
                                    clear();
                                    get_next_patient();
                                    cmbDiagnosis.Focus();
                        
                                }

                                if (con.State.Equals(ConnectionState.Open))
                                {
                                    con.Close();
                                }
                          
                    }
                    else
                    {
                        MessageBox.Show("Enter Patient ID");
                        txtid.Focus();
                    }
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show("aaa="+excep.Message);
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                
            
            
        }

        

        private void cmbDiagnosis_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAmount.Focus();
        }

        private void cmbDiagnosis_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8 || (int)e.KeyChar == 32)
                {
                    if (((int)e.KeyChar > 96 && (int)e.KeyChar < 123))
                        e.KeyChar = Convert.ToChar(Convert.ToInt32(e.KeyChar) - 32);
                      e.Handled = false;
                }
                else if ((int)e.KeyChar == 13)
                {
                    txtAmount .Focus();
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



        private void pnlProcess_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtid_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                   string str1 = txtid.Text.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString()+".jpg";
                    Clipboard.SetText(str1.ToString());
                    get_patient_details();
                    cmbDiagnosis.Focus();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" && checknext == 0)
            {
                get_next_patient();
                cmbDiagnosis.Focus();
                checknext = 1;
            }
            else
            {
                MessageBox.Show("You must Save current Patient !!!");
            }
        }

        private void picPrescription_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           
            try
            {

              
                    panel10.Visible  = false;

                    timer1.Stop();
                }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select pharmacy from flag", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    panel10.Visible = true;
                    btnClear.Enabled = true;
                    btnSave.Enabled = true;
                    picPrescription.Hide();
                    panel6.Hide();
                    pnlProcess.Show();
                    btnPrevious.Enabled = true;
                    btnNow.Enabled = false;
                    timer1.Start();
                    
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


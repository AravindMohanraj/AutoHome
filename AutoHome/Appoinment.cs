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
    public partial class Appoinment : Form
    {
        public Appoinment()
        {
            InitializeComponent();
        }
        OleDbConnection con;
             public  string dat, fdat,tdat,tim,no;
             public bool b;
             public AppointmentView appview;
        public void changecolor1()
             {
                 if (no == "1")
                     appview.button1.BackColor = Color.Coral;
                 else if (no == "2")
                     appview.button2.BackColor = Color.Coral;
                 else if (no == "3")
                     appview.button3.BackColor = Color.Coral;
                 else if (no == "4")
                     appview.button4.BackColor = Color.Coral;
                 else if (no == "5")
                     appview.button5.BackColor = Color.Coral;
                 else if (no == "6")
                     appview.button6.BackColor = Color.Coral;
                 else if (no == "7")
                     appview.button7.BackColor = Color.Coral;
                 else if (no == "8")
                     appview.button8.BackColor = Color.Coral;
                 else if (no == "9")
                     appview.button9.BackColor = Color.Coral;
                 else if (no == "10")
                     appview.button10.BackColor = Color.Coral;
                 else if (no == "11")
                     appview.button11.BackColor = Color.Coral;
                 else if (no == "12")
                     appview.button12.BackColor = Color.Coral;
                 else if (no == "13")
                     appview.button13.BackColor = Color.Coral;
                 else if (no == "14")
                     appview.button14.BackColor = Color.Coral;
                 else if (no == "15")
                     appview.button15.BackColor = Color.Coral;
                 else if (no == "16")
                     appview.button16.BackColor = Color.Coral;
                 else if (no == "17")
                     appview.button17.BackColor = Color.Coral;
                 else if (no == "18")
                     appview.button18.BackColor = Color.Coral;
                 else if (no == "19")
                     appview.button19.BackColor = Color.Coral;
                 else if (no == "20")
                     appview.button20.BackColor = Color.Coral;
                 else if (no == "21")
                     appview.button21.BackColor = Color.Coral;
                 else if (no == "22")
                     appview.button22.BackColor = Color.Coral;
                 else if (no == "23")
                     appview.button23.BackColor = Color.Coral;
                 else if (no == "24")
                     appview.button24.BackColor = Color.Coral;
                 else if (no == "25")
                     appview.button25.BackColor = Color.Coral;
                 else if (no == "26")
                     appview.button26.BackColor = Color.Coral;
                 else if (no == "27")
                     appview.button27.BackColor = Color.Coral;
                 else if (no == "28")
                     appview.button28.BackColor = Color.Coral;
                 else if (no == "29")
                     appview.button29.BackColor = Color.Coral;
                 else if (no == "30")
                     appview.button30.BackColor = Color.Coral;
                 else if (no == "31")
                     appview.button31.BackColor = Color.Coral;
                 else if (no == "32")
                     appview.button32.BackColor = Color.Coral;
                 else if (no == "33")
                     appview.button33.BackColor = Color.Coral;
                 else if (no == "34")
                     appview.button34.BackColor = Color.Coral;
                 else if (no == "35")
                     appview.button35.BackColor = Color.Coral;
                 else if (no == "36")
                     appview.button36.BackColor = Color.Coral;
                 else if (no == "37")
                     appview.button37.BackColor = Color.Coral;
                 else if (no == "38")
                     appview.button38.BackColor = Color.Coral;
                 else if (no == "39")
                     appview.button39.BackColor = Color.Coral;
                 else if (no == "40")
                     appview.button40.BackColor = Color.Coral;
                 else if (no == "41")
                     appview.button41.BackColor = Color.Coral;
                 else if (no == "42")
                     appview.button42.BackColor = Color.Coral;
                 else if (no == "43")
                     appview.button43.BackColor = Color.Coral;
                 else if (no == "44")
                     appview.button44.BackColor = Color.Coral;
                 else if (no == "45")
                     appview.button45.BackColor = Color.Coral;
                 else if (no == "46")
                     appview.button46.BackColor = Color.Coral;
                 else if (no == "47")
                     appview.button47.BackColor = Color.Coral;
                 else if (no == "48")
                     appview.button48.BackColor = Color.Coral;
                 else if (no == "49")
                     appview.button49.BackColor = Color.Coral;
                 else if (no == "50")
                     appview.button50.BackColor = Color.Coral;
                 else if (no == "51")
                     appview.button51.BackColor = Color.Coral;
                 else if (no == "52")
                     appview.button52.BackColor = Color.Coral;
                 else if (no == "53")
                     appview.button53.BackColor = Color.Coral;
                 else if (no == "54")
                     appview.button54.BackColor = Color.Coral;
                 else if (no == "55")
                     appview.button55.BackColor = Color.Coral;
                 else if (no == "56")
                     appview.button56.BackColor = Color.Coral;
                 else if (no == "57")
                     appview.button57.BackColor = Color.Coral;
                 else if (no == "58")
                     appview.button58.BackColor = Color.Coral;
                 else if (no == "59")
                     appview.button59.BackColor = Color.Coral;
                 else if (no == "60")
                     appview.button60.BackColor = Color.Coral;
                 else if (no == "61")
                     appview.button61.BackColor = Color.Coral;
                 else if (no == "62")
                     appview.button62.BackColor = Color.Coral;
                 else if (no == "63")
                     appview.button63.BackColor = Color.Coral;
                 else if (no == "64")
                     appview.button64.BackColor = Color.Coral;
                 else if (no == "65")
                     appview.button65.BackColor = Color.Coral;
                 else if (no == "66")
                     appview.button66.BackColor = Color.Coral;
                 else if (no == "67")
                     appview.button67.BackColor = Color.Coral;
                 else if (no == "68")
                     appview.button68.BackColor = Color.Coral;
                 else if (no == "69")
                     appview.button69.BackColor = Color.Coral;
                 else if (no == "70")
                     appview.button70.BackColor = Color.Coral;
                 else if (no == "71")
                     appview.button71.BackColor = Color.Coral;
                 else if (no == "72")
                     appview.button72.BackColor = Color.Coral;
                 else if (no == "73")
                     appview.button73.BackColor = Color.Coral;
                 else if (no == "74")
                     appview.button74.BackColor = Color.Coral;
                 else if (no == "75")
                     appview.button75.BackColor = Color.Coral;
                 else if (no == "76")
                     appview.button76.BackColor = Color.Coral;
                 else if (no == "77")
                     appview.button77.BackColor = Color.Coral;
                 else if (no == "78")
                     appview.button78.BackColor = Color.Coral;
                 else if (no == "79")
                     appview.button79.BackColor = Color.Coral;
                 else if (no == "80")
                     appview.button80.BackColor = Color.Coral;
                 else if (no == "81")
                     appview.button81.BackColor = Color.Coral;
                 else if (no == "82")
                     appview.button82.BackColor = Color.Coral;
                 else if (no == "83")
                     appview.button83.BackColor = Color.Coral;
                 else if (no == "84")
                     appview.button84.BackColor = Color.Coral;
                 else if (no == "85")
                     appview.button85.BackColor = Color.Coral;
                 else if (no == "86")
                     appview.button86.BackColor = Color.Coral;
                 else if (no == "87")
                     appview.button87.BackColor = Color.Coral;
                 else if (no == "88")
                     appview.button88.BackColor = Color.Coral;
                 else if (no == "89")
                     appview.button89.BackColor = Color.Coral;
                 else if (no == "90")
                     appview.button90.BackColor = Color.Coral;
                 else if (no == "91")
                     appview.button91.BackColor = Color.Coral;
                 else if (no == "92")
                     appview.button92.BackColor = Color.Coral;
                 else if (no == "93")
                     appview.button93.BackColor = Color.Coral;
                 else if (no == "94")
                     appview.button94.BackColor = Color.Coral;
                 else if (no == "95")
                     appview.button95.BackColor = Color.Coral;
                 else if (no == "96")
                     appview.button96.BackColor = Color.Coral;
                 else if (no == "97")
                     appview.button97.BackColor = Color.Coral;
                 else if (no == "98")
                     appview.button98.BackColor = Color.Coral;
                 else if (no == "99")
                     appview.button99.BackColor = Color.Coral;
                 else if (no == "100")
                     appview.button100.BackColor = Color.Coral;
                 else if (no == "101")
                     appview.button101.BackColor = Color.Coral;
                 else if (no == "102")
                     appview.button102.BackColor = Color.Coral;
                

            }
        public void changecolor2()
        {
            if (no == "1")
                appview.button1.BackColor = Color.PaleGreen;
            else if (no == "2")
                appview.button2.BackColor = Color.PaleGreen;
            else if (no == "3")
                appview.button3.BackColor = Color.PaleGreen;
            else if (no == "4")
                appview.button4.BackColor = Color.PaleGreen;
            else if (no == "5")
                appview.button5.BackColor = Color.PaleGreen;
            else if (no == "6")
                appview.button6.BackColor = Color.PaleGreen;
            else if (no == "7")
                appview.button7.BackColor = Color.PaleGreen;
            else if (no == "8")
                appview.button8.BackColor = Color.PaleGreen;
            else if (no == "9")
                appview.button9.BackColor = Color.PaleGreen;
            else if (no == "10")
                appview.button10.BackColor = Color.PaleGreen;
            else if (no == "11")
                appview.button11.BackColor = Color.PaleGreen;
            else if (no == "12")
                appview.button12.BackColor = Color.PaleGreen;
            else if (no == "13")
                appview.button13.BackColor = Color.PaleGreen;
            else if (no == "14")
                appview.button14.BackColor = Color.PaleGreen;
            else if (no == "15")
                appview.button15.BackColor = Color.PaleGreen;
            else if (no == "16")
                appview.button16.BackColor = Color.PaleGreen;
            else if (no == "17")
                appview.button17.BackColor = Color.PaleGreen;
            else if (no == "18")
                appview.button18.BackColor = Color.PaleGreen;
            else if (no == "19")
                appview.button19.BackColor = Color.PaleGreen;
            else if (no == "20")
                appview.button20.BackColor = Color.PaleGreen;
            else if (no == "21")
                appview.button21.BackColor = Color.PaleGreen;
            else if (no == "22")
                appview.button22.BackColor = Color.PaleGreen;
            else if (no == "23")
                appview.button23.BackColor = Color.PaleGreen;
            else if (no == "24")
                appview.button24.BackColor = Color.PaleGreen;
            else if (no == "25")
                appview.button25.BackColor = Color.PaleGreen;
            else if (no == "26")
                appview.button26.BackColor = Color.PaleGreen;
            else if (no == "27")
                appview.button27.BackColor = Color.PaleGreen;
            else if (no == "28")
                appview.button28.BackColor = Color.PaleGreen;
            else if (no == "29")
                appview.button29.BackColor = Color.PaleGreen;
            else if (no == "30")
                appview.button30.BackColor = Color.PaleGreen;
            else if (no == "31")
                appview.button31.BackColor = Color.PaleGreen;
            else if (no == "32")
                appview.button32.BackColor = Color.PaleGreen;
            else if (no == "33")
                appview.button33.BackColor = Color.PaleGreen;
            else if (no == "34")
                appview.button34.BackColor = Color.PaleGreen;
            else if (no == "35")
                appview.button35.BackColor = Color.PaleGreen;
            else if (no == "36")
                appview.button36.BackColor = Color.PaleGreen;
            else if (no == "37")
                appview.button37.BackColor = Color.PaleGreen;
            else if (no == "38")
                appview.button38.BackColor = Color.PaleGreen;
            else if (no == "39")
                appview.button39.BackColor = Color.PaleGreen;
            else if (no == "40")
                appview.button40.BackColor = Color.PaleGreen;
            else if (no == "41")
                appview.button41.BackColor = Color.PaleGreen;
            else if (no == "42")
                appview.button42.BackColor = Color.PaleGreen;
            else if (no == "43")
                appview.button43.BackColor = Color.PaleGreen;
            else if (no == "44")
                appview.button44.BackColor = Color.PaleGreen;
            else if (no == "45")
                appview.button45.BackColor = Color.PaleGreen;
            else if (no == "46")
                appview.button46.BackColor = Color.PaleGreen;
            else if (no == "47")
                appview.button47.BackColor = Color.PaleGreen;
            else if (no == "48")
                appview.button48.BackColor = Color.PaleGreen;
            else if (no == "49")
                appview.button49.BackColor = Color.PaleGreen;
            else if (no == "50")
                appview.button50.BackColor = Color.PaleGreen;
            else if (no == "51")
                appview.button51.BackColor = Color.PaleGreen;
            else if (no == "52")
                appview.button52.BackColor = Color.PaleGreen;
            else if (no == "53")
                appview.button53.BackColor = Color.PaleGreen;
            else if (no == "54")
                appview.button54.BackColor = Color.PaleGreen;
            else if (no == "55")
                appview.button55.BackColor = Color.PaleGreen;
            else if (no == "56")
                appview.button56.BackColor = Color.PaleGreen;
            else if (no == "57")
                appview.button57.BackColor = Color.PaleGreen;
            else if (no == "58")
                appview.button58.BackColor = Color.PaleGreen;
            else if (no == "59")
                appview.button59.BackColor = Color.PaleGreen;
            else if (no == "60")
                appview.button60.BackColor = Color.PaleGreen;
            else if (no == "61")
                appview.button61.BackColor = Color.PaleGreen;
            else if (no == "62")
                appview.button62.BackColor = Color.PaleGreen;
            else if (no == "63")
                appview.button63.BackColor = Color.PaleGreen;
            else if (no == "64")
                appview.button64.BackColor = Color.PaleGreen;
            else if (no == "65")
                appview.button65.BackColor = Color.PaleGreen;
            else if (no == "66")
                appview.button66.BackColor = Color.PaleGreen;
            else if (no == "67")
                appview.button67.BackColor = Color.PaleGreen;
            else if (no == "68")
                appview.button68.BackColor = Color.PaleGreen;
            else if (no == "69")
                appview.button69.BackColor = Color.PaleGreen;
            else if (no == "70")
                appview.button70.BackColor = Color.PaleGreen;
            else if (no == "71")
                appview.button71.BackColor = Color.PaleGreen;
            else if (no == "72")
                appview.button72.BackColor = Color.PaleGreen;
            else if (no == "73")
                appview.button73.BackColor = Color.PaleGreen;
            else if (no == "74")
                appview.button74.BackColor = Color.PaleGreen;
            else if (no == "75")
                appview.button75.BackColor = Color.PaleGreen;
            else if (no == "76")
                appview.button76.BackColor = Color.PaleGreen;
            else if (no == "77")
                appview.button77.BackColor = Color.PaleGreen;
            else if (no == "78")
                appview.button78.BackColor = Color.PaleGreen;
            else if (no == "79")
                appview.button79.BackColor = Color.PaleGreen;
            else if (no == "80")
                appview.button80.BackColor = Color.PaleGreen;
            else if (no == "81")
                appview.button81.BackColor = Color.PaleGreen;
            else if (no == "82")
                appview.button82.BackColor = Color.PaleGreen;
            else if (no == "83")
                appview.button83.BackColor = Color.PaleGreen;
            else if (no == "84")
                appview.button84.BackColor = Color.PaleGreen;
            else if (no == "85")
                appview.button85.BackColor = Color.PaleGreen;
            else if (no == "86")
                appview.button86.BackColor = Color.PaleGreen;
            else if (no == "87")
                appview.button87.BackColor = Color.PaleGreen;
            else if (no == "88")
                appview.button88.BackColor = Color.PaleGreen;
            else if (no == "89")
                appview.button89.BackColor = Color.PaleGreen;
            else if (no == "90")
                appview.button90.BackColor = Color.PaleGreen;
            else if (no == "91")
                appview.button91.BackColor = Color.PaleGreen;
            else if (no == "92")
                appview.button92.BackColor = Color.PaleGreen;
            else if (no == "93")
                appview.button93.BackColor = Color.PaleGreen;
            else if (no == "94")
                appview.button94.BackColor = Color.PaleGreen;
            else if (no == "95")
                appview.button95.BackColor = Color.PaleGreen;
            else if (no == "96")
                appview.button96.BackColor = Color.PaleGreen;
            else if (no == "97")
                appview.button97.BackColor = Color.PaleGreen;
            else if (no == "98")
                appview.button98.BackColor = Color.PaleGreen;
            else if (no == "99")
                appview.button99.BackColor = Color.PaleGreen;
            else if (no == "100")
                appview.button100.BackColor = Color.PaleGreen;
            else if (no == "101")
                appview.button101.BackColor = Color.PaleGreen;
            else if (no == "102")
                appview.button102.BackColor = Color.PaleGreen;
           

        }
        public void save()
        {

            try
            {

               // string todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
              
                if(cmbPId.Text != "" || cmbPTNAME.Text !="" || cmbPTMobileNum.Text!="")
                {
                           if (con.State.Equals(ConnectionState.Closed))
                            {
                                con.Open();

                            }

                           OleDbCommand cmd2 = new OleDbCommand("insert into appointment values('" + cmbPId.Text + "','" + cmbPTNAME.Text + "','" + cmbPTMobileNum.Text + "','" + dat + "','" + tim + "','" + no + "')", con);
                                int flag = cmd2.ExecuteNonQuery();
                                                      
                            if (flag == 1)
                            {
                               
                                changecolor1();
                              //  MessageBox.Show("Saved Successfully");
                                
                                
                                this.Hide();
                               appview.Show();
                               appview.Refresh();
                               appview.dbgridbind();
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
                    MessageBox.Show("Enter the values");
                       
              
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        
        }

        public void update()
        {

            try
            {
         


                if (cmbPId.Text != "" || cmbPTNAME.Text != "" || cmbPTMobileNum.Text != "")
                {
                    if (con.State.Equals(ConnectionState.Closed))
                    {
                        con.Open();
                    }

                    OleDbCommand cmd2 = new OleDbCommand("update appointment set p_id='" + cmbPId.Text + "',p_name='" + cmbPTNAME.Text + "',cell_number='" + cmbPTMobileNum.Text + "' where a_date=#" + dat + "# and a_no='" + no + "'", con);
                    int flag = cmd2.ExecuteNonQuery();

                    if (flag == 1)
                    {
                        MessageBox.Show("Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Not Updated");
                    }
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                else
                    MessageBox.Show("Enter the values");

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



                if (cmbPId.Text != "" || cmbPTNAME.Text != "" || cmbPTMobileNum.Text != "")
                {
                    if (con.State.Equals(ConnectionState.Closed))
                    {
                        con.Open();
                    }

                    OleDbCommand cmd2 = new OleDbCommand("delete from appointment where a_date=#" + dat + "# and a_no='" + no + "'", con);
                    int flag = cmd2.ExecuteNonQuery();

                    if (flag == 1)
                    {
                        changecolor2();
                        cmbPId.Text = "" ;
                        cmbPTNAME.Text = "" ;
                        cmbPTMobileNum.Text = "";
                        new TodayDetails().dgv1();
                      //  MessageBox.Show("Delete Successfully");
                        this.Hide();
                        appview.Show();
                    }
                    else
                    {
                        MessageBox.Show("Not Deleted");
                    }
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();
                    }
                }
                else
                    MessageBox.Show("Enter the values");

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

        }

  

        public void get()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select p_id,p_name,cell_number from appointment where a_date=#" + dat + "# and a_no='" + no + "'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cmbPId .Text = dt.Rows[0][0].ToString();
                    cmbPTNAME .Text = dt.Rows[0][1].ToString();
                    cmbPTMobileNum .Text = dt.Rows[0][2].ToString();
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


        private void btnSave_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(dat);
            save();
        }

        private void txtPatientid_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            try
            {

                if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                else if ((int)e.KeyChar == 13)
                {
                    cmbPTNAME.Focus();
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

        private void Appoinment_Load(object sender, EventArgs e)
        {
            try
            {
                
                connection();
                if (b == true)
                {
                    get();
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                   // btnDelete.Enabled = true;
                    cmbPId.Enabled = false;
                    cmbPTMobileNum.Enabled = false;
                    cmbPTNAME.Enabled = false;
                   
                }
                else
                {
                    cmbPId.Text="";
                    cmbPTNAME.Text = "";
                    cmbPTMobileNum.Text = "";
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    //btnDelete.Enabled = false;
                    cmbPId.Enabled = true ;
                    cmbPTMobileNum.Enabled = true ;
                    cmbPTNAME.Enabled = true ;
                        
                }
                cmbPId.Focus();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
            cmbPId.Focus();
        }

        public  void temp1()
        {
            try
            {
               
                if (this.b == true)
                {
                    get();
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    //btnDelete.Enabled = true;
                
                    cmbPId.Enabled = false;
                    cmbPTMobileNum.Enabled = false;
                    cmbPTNAME.Enabled = false;
                  

                }
                else
                {
                    cmbPId.Text = "";
                    cmbPTNAME.Text = "";
                    cmbPTMobileNum.Text = "";
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    //btnDelete.Enabled = false;
                    cmbPId.Enabled = true;
                    cmbPTMobileNum.Enabled = true;
                    cmbPTNAME.Enabled = true;

                }
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        private void txtPatientid_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void txtPatientname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPatientname_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122) || ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8||(int)e.KeyChar == 32)
                {
                    e.Handled = false;
                }
                else if ((int)e.KeyChar == 13)
                {
                    cmbPTMobileNum.Focus();
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

        private void txtMobileno_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMobileno_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {

                if (( (int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide ();
            
           new AppointmentView ().Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete();

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

        private void cmbPId_TextChanged(object sender, EventArgs e)
        {

        }

     
        
    }
}

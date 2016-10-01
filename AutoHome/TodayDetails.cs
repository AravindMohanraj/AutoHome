using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Imaging;

namespace AutoHome
{
    public partial class TodayDetails : Form
    {
        public TodayDetails()
        {
            InitializeComponent();
        }
        public  OleDbConnection con;
        public string todaydate;
       
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

        public void gridbind()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd1 = new OleDbCommand("select tdaypatient.p_id as Patient_ID,tdaypatient.p_name as Patient_Name,gender as Gender from tdaypatient,patient where patient.p_id=tdaypatient.p_id ", con);
                OleDbDataAdapter da2 = new OleDbDataAdapter(cmd1);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView2.Refresh();
                dataGridView2.DataSource = dt2;

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

        public void gridbind2()
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select tday.p_id as Patient_ID,p_name as Patient_Name,gender as Gender from tday,patient where tday.p_id=patient.p_id and  tday.visiting<>'cur'", con);
                OleDbDataAdapter da1 = new OleDbDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView3.Refresh();
                
                dataGridView3.DataSource = dt1;
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

        private void TodayDetails_Load(object sender, EventArgs e)
        {

            panel1.Size = new Size(panel1.Size.Width, this.Size.Height - panel1.Location.Y-100);
            panel4.Size = new Size(panel4.Size.Width, this.Size.Height - panel4.Location.Y-100);
            panel5.Size = new Size(panel5.Size.Width, this.Size.Height - panel5.Location.Y-100);

            dataGridView2.AllowUserToAddRows = false;           
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
           // dataGridView2.ColumnHeadersVisible    = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
           // dataGridView1.ColumnHeadersVisible = false;
            todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            connection();
            cmbPId.Text = "";
            cmbPTMobileNum.Text = "";
            cmbPTNAME.Text = "";
            gridbind();
            gridbind2();
            panel11.Hide();
        dataGridView1.ClearSelection();
        dataGridView2.ClearSelection();
        dgv1();
        }
        public void dgv1()
        {
            todaydate = DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString();
            OleDbCommand cmd = new OleDbCommand("select p_id as Patient_ID,p_name as Patient_Name,cell_number as Phone,a_time as _Time from appointment where a_date like #" + todaydate + "# order by a_no", con);
            
            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.Refresh();
            dataGridView1.DataSource = dt1;
        }


        //public void idbind()
        //{
        //    cmbPId.DataSource = null;
        //    try
        //    {
        //        if (con.State.Equals(ConnectionState.Closed))
        //        {
        //            con.Open();
        //        }
        //        OleDbCommand cmd = new OleDbCommand("select * from patient order by p_id", con);
        //        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        cmbPId.Refresh();
        //        cmbPId.DataSource = dt;
        //        cmbPId.DisplayMember = "p_id";
        //        cmbPId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        //        cmbPId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbPId.AutoCompleteSource = AutoCompleteSource.ListItems;
        //        // MessageBox.Show("dsd");
        //        if (con.State.Equals(ConnectionState.Open))
        //        {
        //            con.Close();
        //        }
        //    }
        //    catch (System.Exception excep)
        //    {
        //        MessageBox.Show(excep.Message);
        //    }
        //}

      /*  public void idbindnext()
        {
            cmbnextpid.DataSource = null;
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

                cmbnextpid.Refresh();
                cmbnextpid.DataSource = dt;
                cmbnextpid.DisplayMember = "p_id";
                cmbnextpid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cmbnextpid.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbnextpid.AutoCompleteSource = AutoCompleteSource.ListItems;
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
        }*/
        public void dbgridbind(string sql)
        {
            
            try
            {
                dataGridView4.DataSource = null;
                panel11 .Show();
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
               OleDbCommand cmdname = new OleDbCommand(sql, con);
                OleDbDataAdapter daname = new OleDbDataAdapter(cmdname);
                DataTable dtname = new DataTable();
                daname.Fill(dtname);

                dataGridView4.Refresh();
                dataGridView4.DataSource = dtname;
                
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
        //public void namebind()
        //{
           
        //    cmbPTNAME.DataSource = null;
        //    try
        //    {
        //        if (con.State.Equals(ConnectionState.Closed))
        //        {
        //            con.Open();
        //        }

        //        OleDbCommand cmdname = new OleDbCommand("select * from patient order by p_name", con);
        //        OleDbDataAdapter daname = new OleDbDataAdapter(cmdname);
        //        DataTable dtname = new DataTable();
        //        daname.Fill(dtname);

        //        cmbPTNAME.Refresh();
        //        cmbPTNAME.DataSource = dtname;
        //        cmbPTNAME.DisplayMember = "p_name";
        //        cmbPTNAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        //        cmbPTNAME.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbPTNAME.AutoCompleteSource = AutoCompleteSource.ListItems;


        //        // MessageBox.Show("dsd");
        //        if (con.State.Equals(ConnectionState.Open))
        //        {
        //            con.Close();
        //        }
        //    }
        //    catch (System.Exception excep)
        //    {
        //        MessageBox.Show(excep.Message);
        //    }


        //}

        //public void mobbind()
        //{

        //    cmbPTMobileNum.DataSource = null;
        //    try
        //    {
        //        if (con.State.Equals(ConnectionState.Closed))
        //        {
        //            con.Open();
        //        }

        //        OleDbCommand cmdmobile = new OleDbCommand("select * from patient order by mobile_no", con);
        //        OleDbDataAdapter damobile = new OleDbDataAdapter(cmdmobile);
        //        DataTable dtmobile = new DataTable();
        //        damobile.Fill(dtmobile);

        //        cmbPTMobileNum.Refresh();
        //        cmbPTMobileNum.DataSource = dtmobile;
        //        cmbPTMobileNum.DisplayMember = "mobile_no";
        //        cmbPTMobileNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        //        cmbPTMobileNum.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //        cmbPTMobileNum.AutoCompleteSource = AutoCompleteSource.ListItems;


        //        // MessageBox.Show("dsd");
        //        if (con.State.Equals(ConnectionState.Open))
        //        {
        //            con.Close();
        //        }
        //    }
        //    catch (System.Exception excep)
        //    {
        //        MessageBox.Show(excep.Message);
        //    }

        //}



        //private void cmbPId_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    cmbPTMobileNum.DataSource = null;
        //    cmbPTMobileNum.Refresh();
        //    cmbPTNAME.DataSource = null;
        //   // cmbPTNAME.Refresh();
        //    cmbPTNAME.Refresh();
        //    // MessageBox.Show("id");
        //    try
        //    {
        //        if (con.State.Equals(ConnectionState.Closed))
        //        {
        //            con.Open();
        //        }
        //        OleDbCommand cmd = new OleDbCommand("select p_name,mobile_no from patient where p_id='" + cmbPId.Text + "'", con);
        //        OleDbDataReader dr;

        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {

        //            cmbPTNAME.Text = dr[0].ToString();
        //            cmbPTMobileNum.Text = dr[1].ToString();
        //        }

        //        if (con.State.Equals(ConnectionState.Open))
        //        {
        //            con.Close();
        //        }
        //    }

        //    catch (System.Exception excep)
        //    {
        //        MessageBox.Show(excep.Message);
        //    }



        //}

        //private void cmbPTNAME_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //  MessageBox.Show("name");
        //    cmbPTMobileNum.DataSource = null;
        //    cmbPTMobileNum.Refresh();
        //    cmbPId.DataSource = null;
        //    cmbPId.Refresh();

        //    try
        //    {
        //        if (con.State.Equals(ConnectionState.Closed))
        //        {
        //            con.Open();
        //        }

        //        OleDbCommand cmd = new OleDbCommand("select p_id,mobile_no from patient where p_name='" + cmbPTNAME.Text + "'", con);
        //        OleDbDataReader dr;
        //        //  MessageBox.Show(cmbPTNAME.Text);
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {

        //            cmbPId.Text = dr[0].ToString();
        //            cmbPTMobileNum.Text = dr[1].ToString();
        //        }


        //        if (con.State.Equals(ConnectionState.Open))
        //        {
        //            con.Close();
        //        }
        //    }

        //    catch (System.Exception excep)
        //    {
        //        MessageBox.Show(excep.Message);
        //    }


        //}

        //private void cmbPTMobileNum_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    cmbPTNAME.DataSource = null;
        //    cmbPTNAME.Refresh();
        //    cmbPId.DataSource = null;
        //    cmbPId.Refresh();
        //    try
        //    {
        //        if (con.State.Equals(ConnectionState.Closed))
        //        {
        //            con.Open();
        //        }
        //        OleDbCommand cmd = new OleDbCommand("select p_id,p_name from patient where mobile_no='" + cmbPTMobileNum.Text + "'", con);
        //        OleDbDataReader dr;

        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {

        //            cmbPTNAME.Text = dr[1].ToString();
        //            cmbPId.Text = dr[0].ToString();
        //        }


        //        if (con.State.Equals(ConnectionState.Open))
        //        {
        //            con.Close();
        //        }
        //    }

        //    catch (System.Exception excep)
        //    {
        //        MessageBox.Show(excep.Message);
        //    }

        //}

        //private void cmbPId_Enter(object sender, EventArgs e)
        //{
        //    cmbPId.Text = "";
        //    cmbPTMobileNum.Text = "";
        //    cmbPTNAME.Text = "";
        //    cmbPId.DataSource = null;
        //    idbind();
        //  //  cmbPId.DropDownStyle = ComboBoxStyle.Simple;
        //    cmbPTMobileNum.DropDownStyle = ComboBoxStyle.Simple;
        //    cmbPTNAME.DropDownStyle = ComboBoxStyle.Simple;

        //}









        //private void cmbPTNAME_Enter(object sender, EventArgs e)
        //{
        //    cmbPId.Text = "";
        //    cmbPTMobileNum.Text = "";
        //    cmbPTNAME.Text = "";
        //    cmbPTNAME.DataSource = null;
        //    namebind();
        //    cmbPId.DropDownStyle = ComboBoxStyle.Simple;
        //    cmbPTMobileNum.DropDownStyle = ComboBoxStyle.Simple;
        ////    cmbPTNAME.DropDownStyle = ComboBoxStyle.Simple;
        //}

        //private void cmbPTMobileNum_Enter(object sender, EventArgs e)
        //{
        //    cmbPId.Text = "";
        //    cmbPTMobileNum.Text = "";
        //    cmbPTNAME.Text = "";
        //    cmbPTMobileNum.DataSource = null;
        //    mobbind();
        //    cmbPId.DropDownStyle = ComboBoxStyle.Simple;
        //  //  cmbPTMobileNum.DropDownStyle = ComboBoxStyle.Simple;
        //    cmbPTNAME.DropDownStyle = ComboBoxStyle.Simple;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbPId.Text == "")
                MessageBox.Show("Please Choose the Patient Id:");
            else
            {

                try
                {
                    if (con.State.Equals(ConnectionState.Closed))
                    {
                        con.Open();
                    }
                    OleDbCommand selcmd = new OleDbCommand(" select p_id from tdaypatient where p_id='" + cmbPId.Text + "'  ", con);
                    OleDbDataReader dr;
                    dr = selcmd.ExecuteReader();
                    if (dr.Read())
                    {

                        MessageBox.Show("Patient already added to the list");
                        cmbPId.Text = "";
                        cmbPTNAME.Text = "";
                        cmbPTMobileNum.Text = "";

                    }
                    else
                    {
                        OleDbCommand cmd = new OleDbCommand("insert into tdaypatient values ('" + cmbPId.Text + "','" + cmbPTNAME.Text + "')", con);
                        cmd.ExecuteNonQuery();
                        
                        cmbPId.Text = "";
                        cmbPTNAME.Text = "";
                        cmbPTMobileNum.Text = "";
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
                gridbind();

            }
        }

     

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count ==0)
                MessageBox.Show("select the patient details");
            else
            {

                try
                {
                    if (con.State.Equals(ConnectionState.Closed))
                    {
                        con.Open();
                    }
                  

                        OleDbCommand cmd1 = new OleDbCommand("delete from tdaypatient where p_id='" + dataGridView2[0,dataGridView2.CurrentRow.Index].Value.ToString () + "'", con);
                        OleDbCommand cmd = new OleDbCommand("insert into tday values ('" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "','next')", con);
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        gridbind2();
                        if (con.State.Equals(ConnectionState.Open))
                        {
                            con.Close();
                        }
                   
                }
                catch (System.Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
                gridbind();
                
            }
        }

      
      




        private void button3_Click(object sender, EventArgs e)
        {
            new Registration().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gridbind2();
        }

        private void button4_Click(object sender, EventArgs e)
        { 
            try
                {
                    if (con.State.Equals(ConnectionState.Closed))
                    {
                        con.Open();
                    }

                    if (dataGridView2.SelectedRows.Count != 0 && dataGridView3.SelectedRows.Count != 0)
            {
                
                string selid = Convert.ToString(dataGridView3.CurrentRow.Cells[0].Value);
               
                
                OleDbCommand selcmd = new OleDbCommand("select * from tday", con);
                OleDbDataReader dr;
                OleDbCommand ins = new OleDbCommand();
                ins.Connection = con;
                dr = selcmd.ExecuteReader();

                int flag = 0;
                while (dr.Read())
                {
                    if (flag == 0)
                    {
                        if ((dr[0].ToString()) == selid)
                        {
                            ins.CommandText = "delete from temp";
                            ins.ExecuteNonQuery();
                            ins.CommandText = "insert  into temp  values('" + dr[0].ToString() + "','" + dr[1].ToString() + "')";
                            ins.ExecuteNonQuery();
                            ins.CommandText = "delete from tday where p_id='" + dr[0].ToString() + "'";
                            ins.ExecuteNonQuery();
                            flag = 1;

                           
                        }
                    }
                    else
                    {
                        ins.CommandText = "insert  into temp  values('" + dr[0].ToString() + "','" + dr[1].ToString() + "')";
                        ins.ExecuteNonQuery();
                        ins.CommandText = "delete from tday where p_id='" + dr[0].ToString() + "'";
                        ins.ExecuteNonQuery();
                  
                    }


                }
                ins.CommandText = "insert  into tday  values('" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "','next')";
                ins.ExecuteNonQuery();


                OleDbCommand selcmd1 = new OleDbCommand("select * from temp", con);
                OleDbDataReader dr1;
                OleDbCommand ins1 = new OleDbCommand();
                ins1.Connection = con;
                dr1 = selcmd1.ExecuteReader();

                while (dr1.Read())
                {
                           ins1.CommandText = "insert  into tday  values('" + dr1[0].ToString() + "','" + dr1[1].ToString() + "')";
                            ins1.ExecuteNonQuery();
                    }
                OleDbCommand cmd1 = new OleDbCommand("delete from tdaypatient where p_id='" + dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString() + "' ", con);
                cmd1.ExecuteNonQuery();
                
                gridbind2();
                gridbind();
               
                
            }
            else
                MessageBox.Show("Select Patient ID");

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


        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
               if(dataGridView3.SelectedRows.Count!=0)
               {
                string selid = Convert.ToString(dataGridView3.CurrentRow.Cells[0].Value);
                if (selid != "")
                {
                    OleDbCommand selcmd = new OleDbCommand("delete from tday where p_id='" + selid + "'", con);
                    selcmd.ExecuteNonQuery();
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
            gridbind2();
        }



        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Rowind = dataGridView4.CurrentRow.Index;
            cmbPId.Text = dataGridView4[0, Rowind].Value.ToString();
            cmbPTNAME.Text = dataGridView4[1, Rowind].Value.ToString();
            cmbPTMobileNum.Text = dataGridView4[3, Rowind].Value.ToString();
            panel11.Hide();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int Rowind = dataGridView4.CurrentRow.Index;
            cmbPId.Text = dataGridView4[0, Rowind].Value.ToString();
            cmbPTNAME.Text = dataGridView4[1, Rowind].Value.ToString();
            cmbPTMobileNum.Text = dataGridView4[3, Rowind].Value.ToString();
            panel11.Hide();
        }

        private void cmbPId_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cmbPTNAME_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cmbPTMobileNum_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cmbPId_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbPId.Text != "")
            {
                string sql;
                sql = "select p_id,p_name,date_of_birth,mobile_no from patient where p_id  like '" + cmbPId.Text + "%' order by p_id";
                dbgridbind(sql);
                panel11.Show();
            }
            else
                panel11.Hide();
        }

        private void cmbPTNAME_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbPTNAME.Text != "")
            {
                string sql;
                sql = "select p_id,p_name,date_of_birth,mobile_no from patient where p_name  like '" + cmbPTNAME.Text + "%' order by p_name";
                dbgridbind(sql);
                panel11.Show();
            }
            else
                panel11.Hide();
        }

        private void cmbPTMobileNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbPTMobileNum.Text != "")
            {
                string sql;
                sql = "select p_id,p_name,date_of_birth,mobile_no from patient where mobile_no  like '" + cmbPTMobileNum.Text + "%' order by mobile_no";
                dbgridbind(sql);
                panel11.Show();
            }
            else
                panel11.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                if (dataGridView2.SelectedRows.Count != 0)
                {
                    string selid = Convert.ToString(dataGridView2.CurrentRow.Cells[0].Value);
                    if (selid != "")
                    {
                        OleDbCommand selcmd = new OleDbCommand("delete from tdaypatient where p_id='" + selid + "'", con);
                        selcmd.ExecuteNonQuery();
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
            gridbind();
        }



       
       
    }
}
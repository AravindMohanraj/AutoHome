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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        public string todaydate;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            

        }
        public void temp()
        {
           // MessageBox.Show("dsd");
            cmbPId.DataSource = null;

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
                cmbPId.Refresh();
               
                cmbPId.DataSource = dt;
                cmbPId.DisplayMember = "p_id";
                //cmbDiagnosis.ValueMember = "diag";
               
                cmbPId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                cmbPId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPId.AutoCompleteSource = AutoCompleteSource.ListItems;
             
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
        private void btnSave_Click(object sender, EventArgs e)
        {
          
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            //cmbPId.Text = "";
            txtPname.Text = "";
            dateTimePicker1 .Text = "";
            txtAge.Text = "";
            txtMobileno.Text = "";
            txtAddress.Text = "";
            txtPincode.Text = "";
            //txtDob.Text = "DD/MM/YYYY";
        }

        private void txtDob_Leave(object sender, EventArgs e)
        {
           
        }

        private void cmbPId_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

          

        }
        public void maxid()
        {
            string pid, num = "", pchar = "";
            try
            {

                if (con.State.Equals(ConnectionState.Closed))
                    con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT MAX(p_id) from patient  ", con);

                cmd.CommandType = CommandType.Text;
                OleDbDataReader rs = cmd.ExecuteReader();
                if (rs.Read())
                {
                    pid = rs[0].ToString();
                    for (int i = 0; i < pid.Length; i++)
                    {
                        if ((Convert.ToInt32(pid[i]) > 47) && (Convert.ToInt32(pid[i]) < 58))
                        {
                            num = num + pid[i].ToString();
                        }
                        else if ((Convert.ToInt32(pid[i]) > 64) && (Convert.ToInt32(pid[i]) < 91))
                        {

                            pchar = pchar + pid[i].ToString();
                        }
                    }
                    cmbPId.Text = pchar + ((Convert.ToInt32(num) + 1));
                }
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

        private void txtDob_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtPname_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtPname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbPId_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void txtMobileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            

        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
           
        }

        private void Registration_Load_1(object sender, EventArgs e)
        {

            connection();
           // MessageBox.Show("dd");
            rbtnMale.Checked = true;
           // MessageBox.Show("dd");
            temp();
          //  MessageBox.Show("dd");
            maxid();
          //  MessageBox.Show("dd"); 
            clear();
            
           // MessageBox.Show("dd");
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            //txtDob.Text = dateTimePicker1.Value.ToShortDateString();
            int myAge = DateTime.Today.Year - dateTimePicker1.Value.Year; // CurrentYear - YourBirthDate

            txtAge.Text = myAge.ToString();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (con.State.Equals(ConnectionState.Closed))
                    con.Open();

                OleDbCommand cmd = new OleDbCommand("select * from patient where p_id='" + cmbPId.Text + "'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count == 0)
                {
                    string gender;
                    if (rbtnMale.Checked == true)
                        gender = "Male";
                    else
                        gender = "Female";
                    todaydate = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                    OleDbCommand cmd1 = new OleDbCommand("insert into patient values ('" + cmbPId.Text + "','" + txtPname.Text + "','" + gender + "','" + txtAge.Text + "','" +todaydate  + "','" + txtMobileno.Text + "','" + txtAddress.Text + "','" + txtPincode.Text + "')", con);
                    int flage = cmd1.ExecuteNonQuery();
                    if (flage == 1)
                    {
                        MessageBox.Show("Record Saved Successfully.");

                    }
                    else
                    {
                        MessageBox.Show("Record NOT Saved.");

                    }
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();

                    }
                    temp();

                    maxid(); clear();
                }
                else
                {
                    MessageBox.Show("Duplicate Values not allowed !");
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();
                    }

                }
                cmbPId.Focus();

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

        private void Registration_Leave(object sender, EventArgs e)
        {
            int myAge = DateTime.Today.Year - dateTimePicker1.Value.Year; // CurrentYear - YourBirthDate

            txtAge.Text = myAge.ToString();
        }

        private void cmbPId_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int i=fun1();

        }
        public int fun1()
        {
            try
            {
                int ck = 0;
                if (con.State.Equals(ConnectionState.Closed))
                    con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from patient where p_id='" + cmbPId.Text + "'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int rcnt = dt.Rows.Count;


                    for (int i = 0; i < rcnt; i++)
                    {

                        txtPname.Text = dt.Rows[i][1].ToString();
                        string str = dt.Rows[i][2].ToString();
                        if (str == "Male")
                            rbtnMale.Checked = true;
                        else
                            rbtnFemale.Checked = true;
                        //string dobtext = "";

                        //dobtext = dt.Rows[i][4].ToString();
                        DateTime d = new DateTime();
                        d = Convert.ToDateTime(dt.Rows[i][4]);


                        dateTimePicker1.Text = d.ToShortDateString();
                        // int j = 0;
                        //while(dobtext[j]!=' ')
                        //   txtDob.Text = txtDob.Text + dobtext[j];


                        txtAge.Text = dt.Rows[i][3].ToString();
                        txtMobileno.Text = dt.Rows[i][5].ToString();
                        txtAddress.Text = dt.Rows[i][6].ToString();
                        txtPincode.Text = dt.Rows[i][7].ToString();

                    }
                    ck = 1;
                }
                


                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
                return ck;
            }
            catch (System.Exception excep)
            {
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }

                MessageBox.Show(excep.Message);
                return 0;
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            connection();

            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand();
                string gender;
                if (rbtnMale.Checked == true)
                    gender = "Male";
                else
                    gender = "Female";
                todaydate = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                  
                cmd.CommandText = ("update patient set [p_id]='" + cmbPId.Text + "',[p_name]='" + txtPname.Text + "',[gender]='" + gender + "',[age]='" + txtAge.Text + "',[date_of_birth]='" + todaydate  + "',[mobile_no]='" + txtMobileno.Text + "',[address]='" + txtAddress.Text + "',[addr_pin]='" + txtPincode.Text + "' where p_id='" + cmbPId.Text + "'");

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                int flag = cmd.ExecuteNonQuery();
                if (flag == 1)
                    MessageBox.Show("Record Updated Successfully!");
                else
                    MessageBox.Show("Record NOT Updated.");

                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();

                }
                temp();
                clear();
                maxid();
            }
            catch (System.Exception excep)
            {
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }

                MessageBox.Show(excep.Message);
            }

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            connection();

            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = ("delete from patient where p_id='" + cmbPId.Text + "'");

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                int flag = cmd.ExecuteNonQuery();
                if (flag == 1)
                {
                    MessageBox.Show("Record Deleted Successfully!");
                    clear();
                }
                else
                    MessageBox.Show("Record NOT Deleted!");

                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();

                }
                temp();

                maxid();
                clear();
            }
            catch (System.Exception excep)
            {
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }

                MessageBox.Show(excep.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDob_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 46 && (int)e.KeyChar < 58) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtPname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 47 && (int)e.KeyChar < 58) || ((int)e.KeyChar > 64 && (int)e.KeyChar < 91) || ((int)e.KeyChar > 96 && (int)e.KeyChar < 123) || ((int)e.KeyChar == 46) || ((int)e.KeyChar == 32) || ((int)e.KeyChar == 8))
            {
                if (((int)e.KeyChar > 96 && (int)e.KeyChar < 123))
                    e.KeyChar = Convert.ToChar(Convert.ToInt32(e.KeyChar) - 32);
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 13)
            {
                rbtnMale .Focus();
            }
            else
                e.Handled = true;
        }

        private void cmbPId_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((((int)e.KeyChar > 47 && (int)e.KeyChar < 58) || ((int)e.KeyChar > 64 && (int)e.KeyChar < 91) || ((int)e.KeyChar > 96 && (int)e.KeyChar < 123) || ((int)e.KeyChar == 8)))
            {
                if (((int)e.KeyChar > 96 && (int)e.KeyChar < 123))
                    e.KeyChar = Convert.ToChar(Convert.ToInt32(e.KeyChar) - 32);
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 13)
            {
                if (fun1() == 1)
                    cmbPId.Focus();
                else 
                txtPname.Focus();
            }
            else
                e.Handled = true;
        }

        private void txtAge_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 47 && (int)e.KeyChar < 58) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 13)
            {
                txtMobileno .Focus();
            }
            else
                e.Handled = true;

        }

        private void txtMobileno_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 47 && (int)e.KeyChar < 58) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 13)
            {
                txtAddress.Focus();
            }
            else
                e.Handled = true;
        }

        private void txtPincode_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar > 47 && (int)e.KeyChar < 58) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 13)
            {
                btnSave .Focus();
            }
            else
                e.Handled = true;
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            temp();
            clear();
            maxid();
        }

        private void txtDob_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPincode_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnMale_KeyPress(object sender, KeyPressEventArgs e)
        {
             if ((int)e.KeyChar == 13)
            {
                dateTimePicker1 .Focus();
            }
        }

        private void rbtnFemale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtAge .Focus();
            }
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtPincode .Focus();
            }
        }

    }
}

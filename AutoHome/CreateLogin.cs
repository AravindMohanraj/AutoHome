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
    public partial class CreateLogin : Form
    {
        OleDbConnection con;
        public CreateLogin()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void Createlogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           

        }

        private void cmbPrivilege_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
            cmbPrivilege.Text = "";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (con.State.Equals(ConnectionState.Closed))
                    con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from login where username='" + txtUserName.Text + "' and password='" + txtPassword + "' ", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count == 0)
                {
                    OleDbCommand cmd1 = new OleDbCommand("insert into login values ('" + txtUserName.Text + "','" + txtPassword.Text + "','" + cmbPrivilege.Text + "')", con);
                    int flage = cmd1.ExecuteNonQuery();
                    if (flage == 1)
                    {
                        MessageBox.Show("Login Created Successfully.");

                    }
                    else
                    {
                        MessageBox.Show("login NOT Created Successfully.");

                    }
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Duplicate UserName not allowed !");
                    if (con.State.Equals(ConnectionState.Open))
                    {
                        con.Close();
                    }

                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void CreateLogin_Load_1(object sender, EventArgs e)
        {
            connection();
        }

    }
}

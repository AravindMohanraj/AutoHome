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
    public partial class Login : Form
    {
        public string username, password, privilege;
        OleDbCommand cmd = new OleDbCommand();
        OleDbConnection con;
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            
            fun();

            
        }

        public void fun()
        {
            if (txtUserName.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    try
                    {
                        connection();
                        cmd.Connection = con;
                        cmd.CommandText = "select password,username,privilege from login where username='" + txtUserName.Text + "' and password='" + txtPassword.Text + "'";
                        OleDbDataReader dr;
                        con.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Globals.common.username = txtUserName.Text;
                            Globals.common.password = txtPassword.Text;
                            Globals.common.privilege = privilege = dr[2].ToString();
                            //MessageBox.Show(privilege);
                            Master mf = new Master();

                            txtPassword.Clear();
                            txtUserName.Clear();
                           
                            mf.Show();
                            this.Hide();
                            //Updamfte up = new Update();
                            //this.Hide();
                            //up.Show();

                        }
                        else
                        {
                            MessageBox.Show("Verify Your Password.");
                            txtPassword.Focus();
                        }
                    }
                    catch (System.Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
                else
                    MessageBox.Show("Enter Password.");
            }
            else
            {
                MessageBox.Show("Enter user Name.");
                txtUserName.Focus();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar ==13)
            {
                fun();
            }
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

    }
}

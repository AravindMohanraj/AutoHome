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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }
        int priv = 0;
        OleDbConnection con;

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

        private void Updateform_Load(object sender, EventArgs e)
        {

        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbPrivilege_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void brnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbUserName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbUserName_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Update_Load(object sender, EventArgs e)
        {

            if (Globals.common.privilege == "Staff")
            {
                // MessageBox.Show("dd");
                lblDesig.Visible = false;
                cmbPrivilege.Visible = false;
                btnDelete.Visible = false;
                this.Size = new Size(480, 250);

                lblUser.Size = new Size(128, 25);
                lblUser.Location = new Point(20, 20);

                cmbUserName.Size = new Size(205, 35);
                cmbUserName.Location = new Point(153, 16);

                lblPassword.Size = new Size(118, 25);
                lblPassword.Location = new Point(20, 62);

                txtPassword.Size = new Size(205, 31);
                txtPassword.Location = new Point(154, 62);

                panel1.Location = new Point(12, 12);
                panel1.Size = new Size(442, 189);

                brnUpdate.Size = new Size(103, 36);
                brnUpdate.Location = new Point(86, 120);

                btnCancel.Size = new Size(97, 36);
                btnCancel.Location = new Point(218, 120);

                priv = 1;
            }


            connection();
            try
            {

                if (con.State.Equals(ConnectionState.Closed))
                    con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from login", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int rcnt = dt.Rows.Count;
                    for (int i = 0; i < rcnt; i++)
                    {
                        cmbUserName.Items.Add(dt.Rows[i][0].ToString());
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

        private void cmbUserName_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            try
            {

                if (con.State.Equals(ConnectionState.Closed))
                    con.Open();
                OleDbCommand cmd = new OleDbCommand("select * from login where username='" + cmbUserName.Text + "'", con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int rcnt = dt.Rows.Count;


                    for (int i = 0; i < rcnt; i++)
                    {

                        txtPassword.Text = dt.Rows[i][1].ToString();
                        cmbPrivilege.Text = dt.Rows[i][2].ToString();
                    }
                }

                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();
                }
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

        private void cmbUserName_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void brnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                OleDbCommand cmd = new OleDbCommand();
                if (priv == 1)
                    cmd.CommandText = ("update login set [password]='" + txtPassword.Text + "' where username='" + cmbUserName.Text + "'");
                else
                    cmd.CommandText = ("update login set [password]='" + txtPassword.Text + "',[privilege]='" + cmbPrivilege.Text + "' where username='" + cmbUserName.Text + "'");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                int flag = cmd.ExecuteNonQuery();
                if (flag == 1)
                    MessageBox.Show("Record Updated Successfully!");
                else
                    MessageBox.Show("Record NOT Updated Successfully.");

                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();

                }
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

        private void cmbUserName_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (con.State.Equals(ConnectionState.Closed))
                {
                    con.Open();
                }
                DialogResult result;
                result = MessageBox.Show("Do you want to Delete the this Record?!", "Record Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = ("delete from login  where username='" + cmbUserName.Text + "'");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    int flag = cmd.ExecuteNonQuery();
                    //MessageBox.Show(flag.ToString());
                    if (flag == 1)
                    {
                        result = MessageBox.Show("Record Deleted Successfully!", "Record Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        con.Close();
                        if (con.State.Equals(ConnectionState.Closed))
                            con.Open();
                        cmd = new OleDbCommand("select * from login", con);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbUserName.Refresh();
                        if (dt.Rows.Count > 0)
                        {
                            int rcnt = dt.Rows.Count;
                            for (int i = 0; i < rcnt; i++)
                            {
                                cmbUserName.Items.Add(dt.Rows[i][0].ToString());
                            }
                        }
                        cmbUserName.Text = "Select->";
                        txtPassword.Text = "";
                        cmbPrivilege.Text = "Select->";
                        if (con.State.Equals(ConnectionState.Open))
                        {
                            con.Close();
                        }

                    }
                    else
                        MessageBox.Show("Record NOT Deleted Successfully.");
                }
                if (con.State.Equals(ConnectionState.Open))
                {
                    con.Close();

                }
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
       
    }
}

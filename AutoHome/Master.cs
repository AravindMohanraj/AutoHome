using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoHome
{
    public partial class Master : Form
    {
        private int childFormNumber = 0;

        public Master()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
      }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

       

        private void Master_Load(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size (this.Size.Width,pictureBox2.Size .Height );

            if (Globals.common.privilege == "Admin-I")
            {
                clsImageList.SetListView(listView1, "Admin", 0, imageList1);
                clsImageList.SetListView(listView1, "Reception", 1, imageList1);
                clsImageList.SetListView(listView1, "Pharmacy", 2, imageList1);
                clsImageList.SetListView(listView1, "DoctorView", 3, imageList1);
                clsImageList.SetListView(listView1, "AmountView", 4, imageList1);
                clsImageList.SetListView(listView1, "View for Diagnosis", 5, imageList1);
                clsImageList.SetListView(listView1, "PatientHistory", 6, imageList1);
                
            }

            else if (Globals.common.privilege == "Admin-II")
            {
                clsImageList.SetListView(listView1, "Admin", 0, imageList1);
                clsImageList.SetListView(listView1, "Reception", 1, imageList1);

                clsImageList.SetListView(listView1, "View for Diagnosis", 5, imageList1);
                clsImageList.SetListView(listView1, "PatientHistory", 6, imageList1);
            }
            else
            {

                clsImageList.SetListView(listView1, "Reception", 1, imageList1);
                clsImageList.SetListView(listView1, "Pharmacy", 2, imageList1);
                clsImageList.SetListView(listView1, "PatientHistory", 6, imageList1);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

              private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

              public void exit()
              {
                  DialogResult ret;
                  ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                  if (ret == DialogResult.Yes)
                  {
                      Application.Exit();
                  }
                  else
                  {
                      return;
                  }


              }
             private void button8_Click(object sender, EventArgs e)
              {

                  exit();
              }

              private void button1_Click(object sender, EventArgs e)
              {
                  new Login().Show();
                  this.Hide();
              }

              private void toolTip_Popup(object sender, PopupEventArgs e)
              {
                  
              }

              private void listView1_MouseClick(object sender, MouseEventArgs e)
              {
                  switch (listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text)
                  {
                      case "Reception":
                          registernteract ri = new registernteract();
                         
                          ri.Show();
                          break;
                      case "Admin":
                          admininteractcs ai = new admininteractcs();
                      
                          ai.Show();
                          break;

                      case "Pharmacy":
                          new pharmacy().Show();
                     
                     
                          break;

                      case "DoctorView":
                          new doctorview().Show();
                          break;
                      case "AmountView":
                          new Collection().Show();

                          break;
                      case "View for Diagnosis":
                          new Diagnosis().Show();
                          break;

                      case "PatientHistory":
                          new Patienthistory().Show();
                          break;
                      case "Exit":
                          DialogResult ret;
                          ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                          if (ret == DialogResult.Yes)
                          {
                              Application.Exit();
                          }
                          else
                          {
                              return;
                          }
                          break;

                  }
              }

              private void button5_Click(object sender, EventArgs e)
              {
                  exit();
              }

              private void button6_Click(object sender, EventArgs e)
              {
                  this.WindowState = FormWindowState.Minimized;
              }

              private void button4_Click(object sender, EventArgs e)
              {
                  new Aboutus().Show();
              }

              private void panel2_Paint(object sender, PaintEventArgs e)
              {

              }

              private void panel1_Paint(object sender, PaintEventArgs e)
              {

              }

              private void Master_FormClosing(object sender, FormClosingEventArgs e)
              {
                  Application.Exit();
              }
    }
}

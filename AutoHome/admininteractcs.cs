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
    public partial class admininteractcs : Form
    {
        public admininteractcs()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            new CreateLogin().Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Update().Show();
            this.Close();
        }
    }
}

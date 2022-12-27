using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHockey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            new Shedule().Show();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            new Commands().Show();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            new Result().Show();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            new Sostavs().Show();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            new Check().Show();
        }
    }
}

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
    public partial class Check : Form
    {
        public Check()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (bunifuTextBox1.Text == "1234")
            {
                new Edit().Show();
                this.Close();
            }

            else
            {
                bunifuTextBox1.Text = "";
                bunifuTextBox1.UseSystemPasswordChar = false;
                bunifuTextBox1.PlaceholderText = "Введите пароль";
                MessageBox.Show("Неверный пароль");
            }

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            bunifuTextBox1.UseSystemPasswordChar = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.UseSystemPasswordChar = false;
        }
    }
}

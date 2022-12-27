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
    public partial class InsertPart : Form
    {
        private static HockeyEntities hock;
        private static Edit edit;
        public InsertPart()
        {
            hock = new HockeyEntities();
            edit = new Edit();
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (edit != null)
                {
                    int id = edit.commandsgrid.RowCount + 1;
                    DataRow nRow = edit.hockeyDataSet.Tables[1].NewRow();
                    nRow[0] = id;
                    nRow[1] = bunifuTextBox1.Text;
                    nRow[2] = bunifuTextBox2.Text;
                    nRow[3] = bunifuTextBox3.Text;
                    nRow[4] = bunifuTextBox4.Text;
                    nRow[5] = bunifuTextBox5.Text;
                    nRow[6] = bunifuTextBox6.Text;
                    nRow[7] = bunifuTextBox7.Text;
                    nRow[8] = bunifuTextBox8.Text;
                    edit.hockeyDataSet.Tables[1].Rows.Add(nRow);
                    edit.participantsTableAdapter.Update(edit.hockeyDataSet.Participants);
                    edit.hockeyDataSet.Tables[1].AcceptChanges();
                    bunifuTextBox1.Text = "";
                    bunifuTextBox2.Text = "";
                    bunifuTextBox3.Text = "";
                    bunifuTextBox4.Text = "";
                    bunifuTextBox5.Text = "";
                    bunifuTextBox6.Text = "";
                    bunifuTextBox7.Text = "";
                    bunifuTextBox8.Text = "";
                }
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show("Что-то пошло не так");
            //}
        }

        private void insertbut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

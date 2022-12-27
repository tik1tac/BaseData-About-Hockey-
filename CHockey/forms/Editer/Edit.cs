using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CHockey.forms;

namespace CHockey
{
    public partial class Edit : Form
    {
        HockeyEntities hockey;
        public Edit()
        {
            InitializeComponent();
            hockey = new HockeyEntities();
            insertbut.Visible = false;
            commandsgrid.Visible = false;
            sostavgrid.Visible = false;
            hockeydatagrid.Visible = false;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            insertbut.Visible = true;
            commandsgrid.Visible = false;
            sostavgrid.Visible = true;
            hockeydatagrid.Visible = false;
            bunifuLabel2.Text = "Составы";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            insertbut.Visible = true;
            commandsgrid.Visible = true;
            sostavgrid.Visible = false;
            hockeydatagrid.Visible = false;
            bunifuLabel2.Text = "Комманды";
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            insertbut.Visible = true;
            commandsgrid.Visible = true;
            sostavgrid.Visible = false;
            hockeydatagrid.Visible = true;
            bunifuLabel2.Text = "Матчи";

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void insertbut_Click(object sender, EventArgs e)
        {
            switch (bunifuLabel2.Text)
            {
                case "Матчи":
                    {
                        new Insert().Show();
                        break;
                    }
                case "Комманды":
                {
                    new InsertPart().Show();
                    break;
                }
                case "Составы":
                {
                    new InsertSostavs().Show();
                    break;
                }
            }

        }

        private void updatebut_Click(object sender, EventArgs e)
        {
            matchesTableAdapter.Update(hockeyDataSet.Matches);
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            try
            {
                matchesTableAdapter.Update(hockeyDataSet.Matches);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неправильные данные");
            }
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hockeyDataSet.Sostav". При необходимости она может быть перемещена или удалена.
            this.sostavTableAdapter.Fill(this.hockeyDataSet.Sostav);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hockeyDataSet.Participants". При необходимости она может быть перемещена или удалена.
            this.participantsTableAdapter.Fill(this.hockeyDataSet.Participants);
            this.matchesTableAdapter.Fill(this.hockeyDataSet.Matches);

        }

        private void hockeydatagrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            this.matchesTableAdapter.Fill(this.hockeyDataSet.Matches);
            this.participantsTableAdapter.Fill(this.hockeyDataSet.Participants);
            this.sostavTableAdapter.Fill(this.hockeyDataSet.Sostav);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

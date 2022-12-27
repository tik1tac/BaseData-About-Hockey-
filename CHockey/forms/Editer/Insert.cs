using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CHockey.forms
{
    public partial class Insert : Form
    {
        private static HockeyEntities hock;
        private static  Edit edit;
        public Insert()
        {
            InitializeComponent();
            hock = new HockeyEntities();
            edit = new Edit();
        }

        private void insertbut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (edit != null)
                {
                    int id = edit.hockeydatagrid.RowCount + 1;
                    var query1 = hock.Participants.Where(p => p.Name == bunifuTextBox3.Text).Select(k => k.IDcommand).ToArray();
                    var query2 = hock.Participants.Where(p => p.Name == bunifuTextBox4.Text).Select(k => k.IDcommand).ToArray();
                    DataRow nRow = edit.hockeyDataSet.Tables[0].NewRow();
                    nRow[3] = bunifuTextBox1.Text;
                    nRow[7] = bunifuTextBox2.Text;
                    nRow[6] = bunifuTextBox3.Text;
                    nRow[5] = bunifuTextBox4.Text;
                    nRow[4] = bunifuTextBox5.Text;
                    nRow[0] = id;
                    nRow[1] = query1[0];
                    nRow[2] = query2[0];
                    edit.hockeyDataSet.Tables[0].Rows.Add(nRow);
                    edit.matchesTableAdapter.Update(edit.hockeyDataSet.Matches);
                    edit.hockeyDataSet.Tables[0].AcceptChanges();
                    bunifuTextBox1.Text = "";
                    bunifuTextBox2.Text = "";
                    bunifuTextBox3.Text = "";
                    bunifuTextBox4.Text = "";
                    bunifuTextBox5.Text = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Что-то пошло не так");
            }

        }
    }
}

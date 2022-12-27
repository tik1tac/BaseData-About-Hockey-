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
    public partial class Shedule : Form
    {
        HockeyEntities hockey;

        public Shedule()
        {
            InitializeComponent();
            hockey = new HockeyEntities();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        async private void Shedule_Load(object sender, EventArgs e)
        {
            await AsyncLoad();

        }

        async private Task AsyncLoad()
        {
            DateTime now = DateTime.Now.Date;
            bunifuDropdown1.Items.Clear();
            SheduleGrid.Rows.Clear();
            int iter = 0;
            try
            {

                var shedule = hockey.Matches.Where(p => p.DateMatch >= now).Select(x => new { x.DateMatch, x.Command1, x.Command2, x.TypeCompetition });
                foreach (var item in shedule)
                {
                    SheduleGrid.Rows.Add(1);
                    SheduleGrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                    SheduleGrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                    SheduleGrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                    iter++;
                }
                foreach (var item in hockey.Participants.Select(p => p.Achievement).Distinct())
                {
                    bunifuDropdown1.Items.Add(item.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            await Task.Delay(0);
        }

        async  private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            hockey.SaveChanges();
            bunifuDropdown1.Items.Clear();
            SheduleGrid.Rows.Clear();
            int iter = 0;
            try
            {
                var shedule = hockey.Matches.Where(p => p.DateMatch > bunifuDatePicker1.Value.Date).ToArray();
                foreach (var item in shedule)
                {
                    SheduleGrid.Rows.Add(1);
                    SheduleGrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                    SheduleGrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                    SheduleGrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                    iter++;
                }
                foreach (var item in hockey.Participants.Select(p => p.Achievement).Distinct())
                {
                    bunifuDropdown1.Items.Add(item.ToString());
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ой ошибочка");
            }
            await Task.Delay(0);
        }

        async private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            SheduleGrid.Rows.Clear();
            int iter = 0;
            try
            {
                if (bunifuDropdown1.SelectedItem == null)
                {
                    var shedule1 = hockey.Matches.Where(p => p.DateMatch > bunifuDatePicker1.Value.Date).ToArray();
                    foreach (var item in shedule1)
                    {
                        SheduleGrid.Rows.Add(1);
                        SheduleGrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        SheduleGrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        SheduleGrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        iter++;
                    }
                }
                else
                {
                    var shedule = hockey.Matches.Where(p => p.DateMatch > bunifuDatePicker1.Value.Date && p.TypeCompetition == (string)bunifuDropdown1.SelectedItem).ToArray();
                    foreach (var item in shedule)
                    {
                        SheduleGrid.Rows.Add(1);
                        SheduleGrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        SheduleGrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        SheduleGrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        iter++;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ой ошибочка");
            }
            await Task.Delay(0);
        }
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        async private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SheduleGrid.Rows.Clear();
            int iter = 0;
            try
            {
                if (bunifuDatePicker1.Value == null)
                {
                    var shedule = hockey.Matches.Where(p => p.TypeCompetition == (string)bunifuDropdown1.SelectedItem).ToArray();
                    foreach (var item in shedule)
                    {
                        SheduleGrid.Rows.Add(1);
                        SheduleGrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        SheduleGrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        SheduleGrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        iter++;
                    }
                }
                else
                {
                    var shedule = hockey.Matches.Where(p => p.DateMatch >= bunifuDatePicker1.Value.Date && p.TypeCompetition == (string)bunifuDropdown1.SelectedItem);
                    foreach (var item in shedule)
                    {
                        SheduleGrid.Rows.Add(1);
                        SheduleGrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        SheduleGrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        SheduleGrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        iter++;
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ой ошибочка");
            }
            await Task.Delay(0);
        }
    }
}

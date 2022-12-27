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
    public partial class Result : Form
    {
        HockeyEntities hockey;
        public Result()
        {
            InitializeComponent();
            hockey = new HockeyEntities();
        }

        async private void Result_Load(object sender, EventArgs e)
        {
            await AsyncLoad();

        }

        async private Task AsyncLoad()
        {
            bunifuDropdown1.Items.Clear();
            DateTime now = DateTime.Now.Date;
            int iter = 0;
            try
            {
                var result = hockey.Matches.Where(p => p.DateMatch <= now);
                foreach (var item in result)
                {
                    Resultgrid.Rows.Add(1);
                    Resultgrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                    Resultgrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                    Resultgrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                    Resultgrid.Rows[iter].Cells[3].Value = item.Result.ToString();
                    iter++;
                }
                foreach (var item in hockey.Participants.Select(p => p.Achievement).Distinct())
                {
                    bunifuDropdown1.Items.Add(item.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ой ошибочка вышла");
            }
            await Task.Delay(0);
        }

        async private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            hockey.SaveChanges();
            Resultgrid.Rows.Clear();
            int iter = 0;
            try
            {
                if (bunifuDropdown1.SelectedItem==null)
                {
                    var result = hockey.Matches.Where(p => p.DateMatch <= bunifuDatePicker1.Value.Date).ToArray();
                    foreach (var item in result)
                    {
                        Resultgrid.Rows.Add(1);
                        Resultgrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        Resultgrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        Resultgrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        Resultgrid.Rows[iter].Cells[3].Value = item.Result.ToString();
                        iter++;
                    }
                }
                else
                {
                    foreach (var item in hockey.Matches.Where(p => p.TypeCompetition == (string)bunifuDropdown1.SelectedItem && p.DateMatch <= bunifuDatePicker1.Value.Date))
                    {
                        Resultgrid.Rows.Add(1);
                        Resultgrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        Resultgrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        Resultgrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        Resultgrid.Rows[iter].Cells[3].Value = item.Result.ToString();
                        iter++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ой ошибочка вышла");
            }
            await Task.Delay(0);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        async private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuDropdown1.Items.Clear();
            hockey.SaveChanges();
            Resultgrid.Rows.Clear();
            int iter = 0;
            try
            {
                var result = hockey.Matches.Where(p => p.DateMatch <= bunifuDatePicker1.Value.Date);
                foreach (var item in result)
                {
                    Resultgrid.Rows.Add(1);
                    Resultgrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                    Resultgrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                    Resultgrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                    Resultgrid.Rows[iter].Cells[3].Value = item.Result.ToString();
                    iter++;
                }
                foreach (var item in hockey.Participants.Select(p => p.Achievement).Distinct())
                {
                    bunifuDropdown1.Items.Add(item.ToString());
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ой ошибочка вышла");
            }
            await Task.Delay(0);
        }
        async private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resultgrid.Rows.Clear();
            int iter = 0;
            try
            {
                if(bunifuDatePicker1.Value==null)
                {
                    foreach (var item in hockey.Matches.Where(p => p.TypeCompetition==(string)bunifuDropdown1.SelectedItem))
                    {
                        Resultgrid.Rows.Add(1);
                        Resultgrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        Resultgrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        Resultgrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        Resultgrid.Rows[iter].Cells[3].Value = item.Result.ToString();
                        iter++;
                    }
                }
                else
                {
                    foreach (var item in hockey.Matches.Where(p => p.TypeCompetition == (string)bunifuDropdown1.SelectedItem && p.DateMatch<= bunifuDatePicker1.Value.Date))
                    {
                        Resultgrid.Rows.Add(1);
                        Resultgrid.Rows[iter].Cells[0].Value = item.DateMatch.Value.ToShortDateString().ToString();
                        Resultgrid.Rows[iter].Cells[1].Value = (item.Command1 + " vs " + item.Command2).ToString();
                        Resultgrid.Rows[iter].Cells[2].Value = item.TypeCompetition.ToString();
                        Resultgrid.Rows[iter].Cells[3].Value = item.Result.ToString();
                        iter++;
                    }
                }
                await Task.Delay(0);
            }
            catch (Exception)
            {

                MessageBox.Show("Ой ошибочка вышла");
            }
        }
    }
}

using System;
using System.Collections;
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
    public partial class Commands : Form
    {
        HockeyEntities hockey;
        public Commands()
        {
            InitializeComponent();
            hockey = new HockeyEntities();
            bunifuDropdown2.Items.Add("Матчи");
            bunifuDropdown2.Items.Add("Выигрыши");
            bunifuDropdown2.Items.Add("Проигрыши");
            bunifuDropdown2.Items.Add("Ничьи");
            bunifuDropdown2.Items.Add("Очки");
        }

        async private void dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                commandgrid.Rows.Clear();
                bunifuLabel1.Text = (string)dropdown.SelectedItem;
                if (bunifuDropdown1.SelectedItem == null)
                {
                    foreach (var item in hockey.Participants.Where(p => p.Name == (string)dropdown.SelectedItem))
                    {
                        commandgrid.Rows.Add(1);
                        commandgrid.Rows[i].Cells[0].Value = item.Name.ToString();
                        commandgrid.Rows[i].Cells[1].Value = item.City.ToString();
                        commandgrid.Rows[i].Cells[2].Value = item.Countmatches.ToString();
                        commandgrid.Rows[i].Cells[3].Value = item.Win.ToString();
                        commandgrid.Rows[i].Cells[4].Value = item.Lose.ToString();
                        commandgrid.Rows[i].Cells[5].Value = item.Draw.ToString();
                        commandgrid.Rows[i].Cells[6].Value = item.Glasses.ToString();
                        commandgrid.Rows[i].Cells[7].Value = item.Achievement.ToString();
                        i++;
                    }
                }
                else
                {
                    foreach (var item in hockey.Participants.Where(p => p.Name == (string)dropdown.SelectedItem && p.Achievement == (string)bunifuDropdown1.SelectedItem))
                    {
                        commandgrid.Rows.Add(1);
                        commandgrid.Rows[i].Cells[0].Value = item.Name.ToString();
                        commandgrid.Rows[i].Cells[1].Value = item.City.ToString();
                        commandgrid.Rows[i].Cells[2].Value = item.Countmatches.ToString();
                        commandgrid.Rows[i].Cells[3].Value = item.Win.ToString();
                        commandgrid.Rows[i].Cells[4].Value = item.Lose.ToString();
                        commandgrid.Rows[i].Cells[5].Value = item.Draw.ToString();
                        commandgrid.Rows[i].Cells[6].Value = item.Glasses.ToString();
                        commandgrid.Rows[i].Cells[7].Value = item.Achievement.ToString();
                        i++;
                    }
                }
                await Task.Delay(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Вышла ошибочка");
            }

        }

        async private void Commands_Load(object sender, EventArgs e)
        {
            await Async_Load();
        }

        async private Task Async_Load()
        {
            try
            {
                int i = 0;
                commandgrid.Rows.Clear();
                foreach (var item in hockey.Participants)
                {
                    commandgrid.Rows.Add(1);
                    commandgrid.Rows[i].Cells[0].Value = item.Name.ToString();
                    commandgrid.Rows[i].Cells[1].Value = item.City.ToString();
                    commandgrid.Rows[i].Cells[2].Value = Convert.ToInt32(item.Countmatches);
                    commandgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.Win);
                    commandgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.Lose);
                    commandgrid.Rows[i].Cells[5].Value = Convert.ToInt32(item.Draw);
                    commandgrid.Rows[i].Cells[6].Value = Convert.ToInt32(item.Glasses);
                    commandgrid.Rows[i].Cells[7].Value = item.Achievement.ToString();
                    i++;
                }
                dropdown.Items.Clear();
                bunifuDropdown1.Items.Clear();
                foreach (var item in hockey.Participants.Select(p => p.Name).Distinct())
                {
                    dropdown.Items.Add(item);

                }
                foreach (var item in hockey.Participants.Select(p => p.Achievement).Distinct())
                {
                    bunifuDropdown1.Items.Add(item);
                }
                await Task.Delay(0);

            }
            catch (Exception)
            {

                MessageBox.Show("вышла ошибочка");
            }

        }
        async private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            bunifuLabel1.Text = (string)dropdown.SelectedItem;
            commandgrid.Rows.Clear();
            if (dropdown.SelectedItem == null)
            {
                foreach (var item in hockey.Participants.Where(p => p.Achievement == (string)bunifuDropdown1.SelectedItem))
                {
                    commandgrid.Rows.Add(1);
                    commandgrid.Rows[i].Cells[0].Value = item.Name.ToString();
                    commandgrid.Rows[i].Cells[1].Value = item.City.ToString();
                    commandgrid.Rows[i].Cells[2].Value = item.Countmatches.ToString();
                    commandgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.Win);
                    commandgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.Lose);
                    commandgrid.Rows[i].Cells[5].Value = Convert.ToInt32(item.Draw);
                    commandgrid.Rows[i].Cells[6].Value = Convert.ToInt32(item.Glasses);
                    commandgrid.Rows[i].Cells[7].Value = item.Achievement.ToString();
                    i++;
                }
            }
            else
            {
                foreach (var item in hockey.Participants.Where(p => p.Name == (string)dropdown.SelectedItem && p.Achievement == (string)bunifuDropdown1.SelectedItem))
                {
                    commandgrid.Rows.Add(1);
                    commandgrid.Rows[i].Cells[0].Value = item.Name.ToString();
                    commandgrid.Rows[i].Cells[1].Value = item.City.ToString();
                    commandgrid.Rows[i].Cells[2].Value = item.Countmatches.ToString();
                    commandgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.Win);
                    commandgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.Lose);
                    commandgrid.Rows[i].Cells[5].Value = Convert.ToInt32(item.Draw);
                    commandgrid.Rows[i].Cells[6].Value = Convert.ToInt32(item.Glasses);
                    commandgrid.Rows[i].Cells[7].Value = item.Achievement.ToString();
                    i++;
                }
            }
            await Task.Delay(0);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        async private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            try
            {
                commandgrid.Sort(commandgrid.Columns[(string)bunifuDropdown2.SelectedItem], ListSortDirection.Descending);
            }
            catch (Exception)
            {

                MessageBox.Show("Выберите название столбца");
            }
            await Task.Delay(0);
        }

        async private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                commandgrid.Sort(commandgrid.Columns[(string)bunifuDropdown2.SelectedItem], ListSortDirection.Ascending);
            }
            catch (Exception)
            {

                MessageBox.Show("Выберите название столбца");
            }
            await Task.Delay(0);
        }

        async private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuLabel1.Text = "Комманды";
            await Async_Load();
        }

        async private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {

        }
    }
}

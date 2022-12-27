using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHockey
{
    public partial class Sostavs : Form
    {
        HockeyEntities hockey;
        public Sostavs()
        {
            InitializeComponent();
            hockey = new HockeyEntities();
        }

        async private void Sostavs_Load(object sender, EventArgs e)
        {
            try
            {
                await AsyncLoad();
            }
            catch (Exception)
            {
                MessageBox.Show("Вышла ошибочка");
            }

        }

        async private Task AsyncLoad()
        {
            int i = 0;
            sostavgrid.Rows.Clear();
            foreach (var item in hockey.Sostav)
            {
                sostavgrid.Rows.Insert(0);
                sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                sostavgrid.Rows[i].Cells[2].Value = item.Participants.Name.ToString();
                sostavgrid.Rows[i].Cells[3].Value = item.amplua.ToString();
                sostavgrid.Rows[i].Cells[4].Value = item.countmatch.ToString();
            }
            foreach (var item in hockey.Participants)
            {
                dropdown.Items.Add(item.Name);
            }
            await Task.Delay(0);
        }

        async private void dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            sostavgrid.Rows.Clear();
            int i = 0;
                foreach (var item in hockey.Sostav.Where(p => p.Participants.Name == (string)dropdown.SelectedItem))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.Participants.Name.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.countmatch);
                    i++;
                }
            await Task.Delay(0);
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        async private void bunifuButton2_Click(object sender, EventArgs e)
        {
            sostavgrid.Rows.Clear();
            sostavgrid.Columns.Clear();
            int i = 0;
            bunifuLabel1.Text = "Нападающие";

            bunifuDropdown1.Items.Clear();
            bunifuDropdown1.Items.Add("Матчи");
            bunifuDropdown1.Items.Add("Голы");
            bunifuDropdown1.Items.Add("Обыгрыши");

            sostavgrid.Columns.Add("FIO", "ФИО");
            sostavgrid.Columns.Add("amplua", "Амплуа");
            sostavgrid.Columns.Add("number", "Номер");
            sostavgrid.Columns.Add("Матчи", "Матчи");
            sostavgrid.Columns.Add("Голы", "Голы");
            sostavgrid.Columns.Add("Обыгрыши", "Обыгрыши");
            if (dropdown.SelectedItem == null)
            {
                foreach (var item in hockey.Sostav.Where(p => p.amplua == "Нападающий"))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.countmatch);
                    sostavgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.goals);
                    sostavgrid.Rows[i].Cells[5].Value = Convert.ToInt32(item.gamble);
                    i++;
                }
            }
            else
            {
                foreach (var item in hockey.Sostav.Where(p => p.amplua == "Нападающий" && p.Participants.Name == (string)dropdown.SelectedItem))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.countmatch);
                    sostavgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.goals);
                    sostavgrid.Rows[i].Cells[5].Value = Convert.ToInt32(item.gamble);
                    i++;
                }
            }
            await Task.Delay(0);
        }

        async private void bunifuButton3_Click(object sender, EventArgs e)
        {
            sostavgrid.Rows.Clear();
            sostavgrid.Columns.Clear();
            int i = 0;
            bunifuLabel1.Text = "Защитники";

            bunifuDropdown1.Items.Clear();
            bunifuDropdown1.Items.Add("Матчи");
            bunifuDropdown1.Items.Add("Отборы");
            bunifuDropdown1.Items.Add("Голы");

            sostavgrid.Columns.Add("FIO", "ФИО");
            sostavgrid.Columns.Add("amplua", "Амплуа");
            sostavgrid.Columns.Add("number", "Номер");
            sostavgrid.Columns.Add("Матчи", "Матчи");
            sostavgrid.Columns.Add("Отборы", "Отборы");
            sostavgrid.Columns.Add("Голы", "Голы");
            if (dropdown.SelectedItem == null)
            {
                foreach (var item in hockey.Sostav.Where(p => p.amplua == "Защитник"))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.countmatch);
                    sostavgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.selections);
                    sostavgrid.Rows[i].Cells[5].Value = Convert.ToInt32(item.goals);
                    i++;
                }
            }
            else
            {
                foreach (var item in hockey.Sostav.Where(p => p.amplua == "Защитник" && p.Participants.Name == (string)dropdown.SelectedItem))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.countmatch);
                    sostavgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.selections);
                    sostavgrid.Rows[i].Cells[5].Value = Convert.ToInt32(item.goals);
                    i++;
                }
            }
            await Task.Delay(0);
        }

        async private void bunifuButton6_Click(object sender, EventArgs e)
        {
            sostavgrid.Rows.Clear();
            sostavgrid.Columns.Clear();
            int i = 0;
            bunifuLabel1.Text = "Вратари";

            bunifuDropdown1.Items.Clear();
            bunifuDropdown1.Items.Add("Матчи");
            bunifuDropdown1.Items.Add("Отбитие");

            sostavgrid.Columns.Add("FIO", "ФИО");
            sostavgrid.Columns.Add("amplua", "Амплуа");
            sostavgrid.Columns.Add("number", "Номер");
            sostavgrid.Columns.Add("Матчи", "Матчи");
            sostavgrid.Columns.Add("Отбитие", "Отбитие");
            if (dropdown.SelectedItem == null)
            {
                foreach (var item in hockey.Sostav.Where(p => p.amplua == "Вратарь"))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.countmatch);
                    sostavgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.rshots);
                    i++;
                }
            }
            else
            {
                foreach (var item in hockey.Sostav.Where(p => p.amplua == "Вратарь" && p.Participants.Name == (string)dropdown.SelectedItem))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = Convert.ToInt32(item.countmatch);
                    sostavgrid.Rows[i].Cells[4].Value = Convert.ToInt32(item.rshots);
                    i++;
                }
            }
            await Task.Delay(0);
        }

        async private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuLabel1.Text = "Состав";
            dropdown.SelectedItem = null;
            bunifuDropdown1.SelectedItem = null;
            int i = 0;
            if (bunifuTextBox1.Text == "")
                MessageBox.Show("Введите сначала фамилию и инициалы");
            try
            {
                sostavgrid.Rows.Clear();
                foreach (var item in hockey.Sostav.Where(p => p.FIO == bunifuTextBox1.Text))
                {
                    sostavgrid.Rows.Add(1);
                    sostavgrid.Rows[i].Cells[0].Value = item.FIO.ToString();
                    sostavgrid.Rows[i].Cells[1].Value = item.number.ToString();
                    sostavgrid.Rows[i].Cells[2].Value = item.Participants.Name.ToString();
                    sostavgrid.Rows[i].Cells[3].Value = item.amplua.ToString();
                    sostavgrid.Rows[i].Cells[4].Value = item.countmatch.ToString();
                }
                if (hockey.Sostav.Where(p => p.FIO == bunifuTextBox1.Text).ToArray().Length == 0)
                {
                    MessageBox.Show("Таких игроков не найдено");
                    bunifuTextBox1.Text = "";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Вышла ошибочка");
            }
            await Task.Delay(0);
        }

        async private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            bunifuLabel1.Text = "Состав";
            sostavgrid.Sort(sostavgrid.Columns[(string)bunifuDropdown1.SelectedItem], ListSortDirection.Descending);
            await Task.Delay(0);
        }

        async private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuLabel1.Text = "Состав";
            sostavgrid.Sort(sostavgrid.Columns[(string)bunifuDropdown1.SelectedItem], ListSortDirection.Ascending);
            await Task.Delay(0);
        }

        async private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuLabel1.Text = "Составы";
                await AsyncLoad();
            }
            catch (Exception)
            {
                MessageBox.Show("Вышла ошибочка");
            }
        }
    }
}

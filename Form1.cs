using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisPlayers.Models;

namespace TennisPlayers
{
    public partial class Form1 : Form
    {
        public static int idToEdit;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using(var context = new Tennis_DBContext())
            {
                dataGridView1.DataSource = context.Players.OrderByDescending(pl => pl.Wins)
                                                           .ToList();
                dataGridView1.Columns["PlayerName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_form af = new Add_form();
            af.ShowDialog();
            LoadData();
            this.Show();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            idToEdit = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            this.Hide();
            Edit_form ef = new Edit_form();
            ef.ShowDialog();
            LoadData();
            this.Show();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            idToEdit = int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            this.Hide();
            Remove_form rf = new ();
            rf.ShowDialog();
            LoadData();
            this.Show();
        }
    }
}

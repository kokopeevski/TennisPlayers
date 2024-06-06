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
    public partial class Edit_form : Form
    {
        public Edit_form()
        {
            InitializeComponent();
        }

        private void Edit_form_Load(object sender, EventArgs e)
        {
            using (var ctx = new Tennis_DBContext())
            {
                Player pl = ctx.Players.Where(p => p.Id == Form1.idToEdit)
                                       .FirstOrDefault();
                textBoxName.Text = pl.PlayerName;
                textBoxWins.Text = pl.Wins.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new Tennis_DBContext())
            {
                Player pl = ctx.Players.Where(p => p.Id == Form1.idToEdit)
                                       .FirstOrDefault();
                pl.PlayerName = textBoxName.Text;
                pl.Wins = int.Parse(textBoxWins.Text);
                ctx.SaveChanges();
                MessageBox.Show("1 record rdited :)");
                Close();
            }
        }
    }
}

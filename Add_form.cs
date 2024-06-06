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
    public partial class Add_form : Form
    {
        public Add_form()
        {
            InitializeComponent();
        }

        private void Add_form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new Tennis_DBContext())
            {
                Player newPlayer = new Player()
                {
                    PlayerName = textBoxName.Text,
                    Wins = int.Parse(textBoxWins.Text)
                };
                ctx.Add(newPlayer);
                int res = ctx.SaveChanges();
                textBoxName.Text = textBoxWins.Text = "";
                MessageBox.Show(res == 1 ? "+1 record :)" : "Try agaun later!");
            }
        }
    }
}

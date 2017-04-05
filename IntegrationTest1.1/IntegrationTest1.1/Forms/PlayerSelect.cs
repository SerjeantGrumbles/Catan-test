using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrationTest1._1
{
    public partial class PlayerSelect : Form
    {
        public PlayerSelect()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtPlayer1.Text == "" || txtPlayer2.Text == "" || txtPlayer3.Text == "" || txtPlayer4.Text == "")
            {
                MessageBox.Show("Player name cannot be left blank!", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GameScreen gameScreen = new GameScreen();
            gameScreen.players[0] = new Player(txtPlayer1.Text, Color.Red);
            gameScreen.players[1] = new Player(txtPlayer2.Text, Color.Blue);
            gameScreen.players[2] = new Player(txtPlayer3.Text, Color.Black);
            gameScreen.players[3] = new Player(txtPlayer4.Text, Color.DarkOrange);
            gameScreen.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Application.OpenForms[0];
            mainMenu.Show();
            this.Hide();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Application.OpenForms[0];
            mainMenu.Show();
            base.OnFormClosed(e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrationTest1._1.Forms
{
    public partial class DiceScreen : Form
    {
        private Dice[] dice = new Dice[4];
        GameScreen gameScreen = null;
        private int[] diceTotals = new int[4];
        public DiceScreen()
        {
            InitializeComponent();
        }

        private void DiceScreen_Load(object sender, EventArgs e)
        {
            int x = 2;
            do
            {
                try
                {
                    gameScreen = (GameScreen)Application.OpenForms[x];
                }
                catch (InvalidCastException)
                {
                    x += 1;
                }
            } while (gameScreen == null);
                        
            for (int i = 0; i <= dice.GetUpperBound(0); i++)
            {
                dice[i] = new Dice();
                dice[i].Roll();
                diceTotals[i] = dice[i].DiceTotal;
            }

            int[] tempTotals = new int[4];
            for (int i = 0; i <= dice.GetUpperBound(0); i++)
            {
                tempTotals[i] = diceTotals[i];
            }
            Array.Sort(tempTotals, dice);
            Array.Reverse(dice);

            dice[0].DisplayDice(picDice1, picDice2);
            dice[1].DisplayDice(picDice3, picDice4);
            dice[2].DisplayDice(picDice5, picDice6);
            dice[3].DisplayDice(picDice7, picDice8);

            Array.Sort(diceTotals, gameScreen.players);
            Array.Reverse(gameScreen.players);

            lblPlayer1.Text = gameScreen.players[0].Name;
            lblPlayer2.Text = gameScreen.players[1].Name;
            lblPlayer3.Text = gameScreen.players[2].Name;
            lblPlayer4.Text = gameScreen.players[3].Name;
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            //Array.Sort(diceTotals, gameScreen.players);
            //Array.Reverse(gameScreen.players);
            this.Close();
            gameScreen.startGame();
        }
    }
}

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
    public partial class DevCardScreen : Form
    {
        public int current;
        GameScreen gameScreen = null;
        public DevCardScreen()
        {
            InitializeComponent();
        }

        private void DevCardScreen_Load(object sender, EventArgs e)
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
            for (int i = 0; i < gameScreen.players[current].DevCards.Count; i++)
            lstDevCards.Items.Add(gameScreen.players[current].DevCards[i]);
        }

        private void lstDevCards_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DevCard currentCard = (DevCard)lstDevCards.SelectedItem;
            try
            {
                picDevCard.Image = currentCard.Image;
            } catch (NullReferenceException) { }
            
            btnPlay.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            DevCard currentCard = (DevCard)lstDevCards.SelectedItem;
            currentCard.Play(gameScreen, gameScreen.players[current]);
            gameScreen.players[current].DevCards.Remove(currentCard);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            gameScreen.playerUI.Enabled = true;
            base.OnFormClosed(e);
        }

       
    }
}

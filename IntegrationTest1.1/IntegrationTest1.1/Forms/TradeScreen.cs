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
    public partial class TradeScreen : Form
    {
        public int recipient;
        public int current;
        GameScreen gameScreen = null;
        public TradeScreen()
        {
            InitializeComponent();
        }

        private void TradeScreen_Load(object sender, EventArgs e)
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

            lblHeading.Text = "Trade with " + gameScreen.players[recipient].Name;
        }

        private void cmbCurrentPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.resourceType myResource = (Player.resourceType)cmbCurrentPlayer.SelectedIndex;
            switch (myResource)
            {
                case Player.resourceType.Lumber:
                    updCurrentPlayer.Maximum = gameScreen.players[current].LumberCount;                    
                    break;
                case Player.resourceType.Grain:
                    updCurrentPlayer.Maximum = gameScreen.players[current].GrainCount;
                    break;
                case Player.resourceType.Wool:
                    updCurrentPlayer.Maximum = gameScreen.players[current].WoolCount;
                    break;
                case Player.resourceType.Ore:
                    updCurrentPlayer.Maximum = gameScreen.players[current].OreCount;
                    break;
                case Player.resourceType.Brick:
                    updCurrentPlayer.Maximum = gameScreen.players[current].BrickCount;
                    break;
            }
            if (cmbRecipientPlayer.SelectedIndex != -1 && cmbCurrentPlayer.SelectedIndex != cmbRecipientPlayer.SelectedIndex)
            {
                btnTrade.Enabled = true;
            }
            else
            {
                btnTrade.Enabled = false;
            }
        }

        private void cmbRecipientPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.resourceType theirResource = (Player.resourceType)cmbRecipientPlayer.SelectedIndex;
            switch (theirResource)
            {
                case Player.resourceType.Lumber:
                    updRecipientPlayer.Maximum = gameScreen.players[recipient].LumberCount;
                    break;
                case Player.resourceType.Grain:
                    updRecipientPlayer.Maximum = gameScreen.players[recipient].GrainCount;
                    break;
                case Player.resourceType.Wool:
                    updRecipientPlayer.Maximum = gameScreen.players[recipient].WoolCount;
                    break;
                case Player.resourceType.Ore:
                    updRecipientPlayer.Maximum = gameScreen.players[recipient].OreCount;
                    break;
                case Player.resourceType.Brick:
                    updRecipientPlayer.Maximum = gameScreen.players[recipient].BrickCount;
                    break;
            }
            if (cmbCurrentPlayer.SelectedIndex != -1 && cmbCurrentPlayer.SelectedIndex != cmbRecipientPlayer.SelectedIndex)
            {
                btnTrade.Enabled = true;
            }
            else
            {
                btnTrade.Enabled = false;
            }
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            string input = "";
            ShowInputDialog(ref input);
            if (input == gameScreen.players[recipient].Name.ToUpper())
            {
                Player.resourceType myResource = (Player.resourceType)cmbCurrentPlayer.SelectedIndex;
                int myAmt = Convert.ToInt32(updCurrentPlayer.Value);
                Player.resourceType theirResource = (Player.resourceType)cmbRecipientPlayer.SelectedIndex;
                int theirAmt = Convert.ToInt32(updRecipientPlayer.Value);
                gameScreen.players[current].MakeTrade(gameScreen, gameScreen.players[recipient], myResource, myAmt, 
                    theirResource, theirAmt);
                MessageBox.Show("Trade successful");
                this.Close();
            }
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

        //Fie!  C# lacks an InputBox class, thus I must avail myself of this homebrew.
        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(275, 150);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            inputBox.BackColor = System.Drawing.Color.Maroon;
            inputBox.Text = "";

            System.Windows.Forms.Label lblPrompt = new Label();
            lblPrompt.Size = new System.Drawing.Size(size.Width - 45, 58);
            lblPrompt.Location = new System.Drawing.Point(5, 5);
            lblPrompt.Text = "Type your name in all caps to verify trade:";
            lblPrompt.ForeColor = System.Drawing.Color.Gold;
            inputBox.Controls.Add(lblPrompt);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 28);
            textBox.Location = new System.Drawing.Point(5, 65);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 200, 105);
            okButton.UseVisualStyleBackColor = true;
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(90, 23);
            cancelButton.Font = new System.Drawing.Font("Copperplate Gothic Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 100, 105);
            cancelButton.UseVisualStyleBackColor = true;
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}

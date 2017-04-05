using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IntegrationTest1._1.Properties;

namespace IntegrationTest1._1
{
    public partial class GameScreen : Form
    {
        private Board gameBoard = new Board();
        private Label[][] lblTokens = new Label[][] { new Label[] { new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label() }};
        public PictureBox[][] picNodes = new PictureBox[][] { new PictureBox[] { null, null, null },
        new PictureBox[] { null, null, null, null }, new PictureBox[] { null, null, null, null },
        new PictureBox[] { null, null, null, null, null }, new PictureBox[] { null, null, null, null, null },
        new PictureBox[] { null, null, null, null, null, null }, new PictureBox[] { null, null, null, null, null, null },
        new PictureBox[] { null, null, null, null, null }, new PictureBox[] { null, null, null, null, null },
        new PictureBox[] { null, null, null, null }, new PictureBox[] { null, null, null, null },
        new PictureBox[] { null, null, null}};
        private Dice dice = new Dice();
        public Player[] players = new Player[4];
        private int round = 1;
        private int turn = 0;
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            GenerateTokens();
            GenerateNodes();
            SetGame();
        }

        private void GameScreen_Paint(object Sender, PaintEventArgs e)
        {
            Bitmap[][] hexImages = new Bitmap[][] { new Bitmap[] { null, null, null },
                new Bitmap[] { null, null, null, null },
                new Bitmap[] { null, null, null, null, null },
                new Bitmap[] { null, null, null, null },
                new Bitmap[] { null, null, null }};

            for (int i = 0; i <= hexImages.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= hexImages[i].GetUpperBound(0); j++)
                {                   
                    try
                    {                        
                        hexImages[i][j] = new Bitmap(gameBoard.Hexes[i][j].Image);

                        TextureBrush texture = new TextureBrush(hexImages[i][j]);
                        texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                        Graphics formGraphics = this.CreateGraphics();
                        Pen pen15 = new Pen(Color.Black, 5);

                        formGraphics.DrawPolygon(pen15, gameBoard.Hexes[i][j].Points); //draw the outline of the hex
                        formGraphics.FillPolygon(texture, gameBoard.Hexes[i][j].Points); //fill the hex with the terrain texture
                        formGraphics.Dispose();
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
                    }
                }
            }
        } // end GameScreen_Paint

        private void GenerateTokens()
        {
            for (int i = 0; i <= lblTokens.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblTokens[i].GetUpperBound(0); j++)
                {
                    lblTokens[i][j] = new Label();
                    lblTokens[i][j].AutoSize = false;
                    lblTokens[i][j].BackColor = System.Drawing.Color.DarkKhaki;
                    lblTokens[i][j].Location = new System.Drawing.Point((int)gameBoard.Hexes[i][j].MidpointX - 10,
                        (int)gameBoard.Hexes[i][j].MidpointY - 10);
                    lblTokens[i][j].Font = new System.Drawing.Font("Copperplate Gothic Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblTokens[i][j].Name = "token" + i + "_" + j;
                    lblTokens[i][j].Cursor = System.Windows.Forms.Cursors.Hand;
                    if (gameBoard.Hexes[i][j].Token == 0)
                    {
                        lblTokens[i][j].Size = new System.Drawing.Size(0, 0);
                    } else
                    {
                        lblTokens[i][j].Size = new System.Drawing.Size(30, 25);
                    }                   
                    lblTokens[i][j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblTokens[i][j].Text = gameBoard.GetToken(i, j);
                    lblTokens[i][j].Click += new System.EventHandler(lblTokens_Click);
                    lblTokens[i][j].MouseHover += new System.EventHandler(lblTokens_MouseHover);
                    lblTokens[i][j].MouseLeave += new System.EventHandler(lblTokens_MouseLeave);
                    Controls.Add(lblTokens[i][j]);

                }
            }
        } // end GenerateTokens()

        private void GenerateNodes()
        {
            for (int i = 0; i <= picNodes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= picNodes[i].GetUpperBound(0); j++)
                {
                    picNodes[i][j] = new PictureBox();
                    picNodes[i][j].BackColor = System.Drawing.Color.Red;
                    picNodes[i][j].Cursor = System.Windows.Forms.Cursors.Hand;
                    picNodes[i][j].Location = new System.Drawing.Point((int)gameBoard.Nodes[i][j].LocationX, 
                        (int)gameBoard.Nodes[i][j].LocationY);
                    picNodes[i][j].Name = "node" + i + "_" + j;
                    picNodes[i][j].Size = new System.Drawing.Size(10, 10);
                    picNodes[i][j].TabStop = false;
                    picNodes[i][j].Visible = false;
                    picNodes[i][j].Click += new System.EventHandler(picNode_Click);
                    Controls.Add(picNodes[i][j]);
                }
            }
        }

        private void EraseTokens()
        {
            for (int i = 0; i <= lblTokens.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblTokens[i].GetUpperBound(0); j++)
                {
                    lblTokens[i][j].Dispose();
                }
            }
        }

        private void SetGame()
        {
            lblPlayer1.Text = players[0].Name;
            lblPlayer2.Text = players[1].Name;
            lblPlayer3.Text = players[2].Name;
            lblPlayer4.Text = players[3].Name;
            lblPlayer1.ForeColor = players[0].Colour;
            lblPlayer2.ForeColor = players[1].Colour;
            lblPlayer3.ForeColor = players[2].Colour;
            lblPlayer4.ForeColor = players[3].Colour;
            playerUI_TradeP1.Text = "Trade With " + players[0].Name;
            playerUI_TradeP2.Text = "Trade With " + players[1].Name;
            playerUI_TradeP3.Text = "Trade With " + players[2].Name;
            playerUI_TradeP4.Text = "Trade With " + players[3].Name;
            playerUI_TradeP1.Visible = false;
            playerUI_TradeP2.Visible = false;
            playerUI_TradeP3.Visible = false;
            playerUI_TradeP4.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Initialzing game.  Dice rolls will determine player order.");
            Forms.DiceScreen diceScreen = new Forms.DiceScreen();
            diceScreen.Show();
            btnStart.Visible = false;
            
        }

        public void startGame()
        {
            lblPlayer1.Text = players[0].Name;
            lblPlayer2.Text = players[1].Name;
            lblPlayer3.Text = players[2].Name;
            lblPlayer4.Text = players[3].Name;
            lblPlayer1.ForeColor = players[0].Colour;
            lblPlayer2.ForeColor = players[1].Colour;
            lblPlayer3.ForeColor = players[2].Colour;
            lblPlayer4.ForeColor = players[3].Colour;
            playerUI.Visible = true;
            picDice1.Visible = true;
            picDice2.Visible = true;
            players[0].StartTurn(this);
            MessageBox.Show(String.Format("The game has begun.  {0}, build your first settlement and road.",
                players[0].Name));
            lblRoundCount.Visible = true;
            lblRoundCount.Text = "Round 1";
        }

        private void playerUI_EndTurn_Click(object sender, EventArgs e)
        {
            int nextTurn;
            switch (round)
            {
                case 1: // round 1, everyone builds first settlement and road
                    if (turn < 3)
                    {
                        nextTurn = turn + 1;
                        MessageBox.Show(String.Format("End of turn for {0}.  {1}, build your first settlement and road.",
                                players[turn].Name, players[nextTurn].Name));
                        turn = nextTurn;
                    } else
                    {
                        MessageBox.Show("End of round 1.  Players will proceed in reverse order for round 2");
                        round += 1;
                        MessageBox.Show(String.Format("{0}, build your second settlement and road", players[turn].Name));
                        lblRoundCount.Text = String.Format("Round {0}", round);
                    }
                    players[turn].StartTurn(this);
                    playerUI_BuildSettlement.Enabled = true;
                    playerUI_EndTurn.Enabled = false;
                    break;
                case 2: // round 2, everyone builds second settlement and road, this time going in reverse order                   
                    if (turn > 0)
                    {
                        nextTurn = turn - 1;
                        MessageBox.Show(String.Format("End of turn for {0}.  {1}, build your second settlement and road.",
                                players[turn].Name, players[nextTurn].Name));
                        turn = nextTurn;
                        playerUI_EndTurn.Enabled = false;
                    } else
                    {
                        nextTurn = turn;
                        MessageBox.Show("End of round 2.  Initial settlements and roads are in place, and the game can truly begin.");
                        MessageBox.Show(String.Format("{0}, it is now your turn.", players[turn].Name));
                        round += 1;
                        lblRoundCount.Text = String.Format("Round {0}", round);
                        playerUI_BuildRoad.Enabled = true;
                        playerUI_BuildCity.Enabled = true;
                        playerUI_TradeP2.Visible = true;
                        playerUI_TradeP3.Visible = true;
                        playerUI_TradeP4.Visible = true;
                    }
                    playerUI_BuildSettlement.Enabled = true;
                    players[turn].StartTurn(this);
                    break;
                default: // start of the game proper, covering all rounds after the first two
                    nextTurn = (turn + 1) % 4;
                    if (nextTurn == 0)
                    {
                        MessageBox.Show(String.Format("End of turn for {0}.",
                            players[turn].Name));
                        MessageBox.Show(String.Format("End of round {0}", round));
                        MessageBox.Show(String.Format("{0}, it is now your turn.", players[nextTurn].Name));
                        round += 1;
                        lblRoundCount.Text = String.Format("Round {0}", round);
                    } else
                    {
                        MessageBox.Show(String.Format("End of turn for {0}.  {1}, it is now your turn.",
                            players[turn].Name, players[nextTurn].Name));
                    }
                    switch (nextTurn)
                    {
                        case 0:                           
                            playerUI_TradeP4.Visible = true;
                            playerUI_TradeP1.Visible = false;                           
                            break;
                        case 1:
                            playerUI_TradeP1.Visible = true;
                            playerUI_TradeP2.Visible = false;
                            break;
                        case 2:
                            playerUI_TradeP2.Visible = true;
                            playerUI_TradeP3.Visible = false;
                            break;
                        case 3:
                            playerUI_TradeP3.Visible = true;
                            playerUI_TradeP4.Visible = false;
                            break;
                    }
                    
                    turn = nextTurn;
                    players[turn].StartTurn(this);
                    break;
            }          
        }

        private void playerUI_BuildSettlement_Click(object sender, EventArgs e)
        {
            if (round < 3)
            {
                players[turn].BuildInitialSettlement(this);
            } else
            {
                players[turn].BuildSettlement(this);
            }           
        }

        private void playerUI_BuildCity_Click(object sender, EventArgs e)
        {
                players[turn].BuildCity(this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //reset players
            for (int i = 0; i <=3; i++)
            {
                players[i] = new Player(players[i]);
            }
            gameBoard = new Board(); //reset board
            EraseTokens();
            GenerateTokens();
            SetGame();
            picDice1.Image = (Image)Resources.ResourceManager.GetObject("dice_blank");
            picDice2.Image = (Image)Resources.ResourceManager.GetObject("dice_blank");
            playerUI_DiceResult.Text = "";
            playerUI.Visible = false;
            picDice1.Visible = false;
            picDice2.Visible = false;
            lblRoundCount.Visible = false;
            btnStart.Visible = true;
        }

        private void playerUI_BuildRoad_Click(object sender, EventArgs e)
        {
            if (round < 3)
            {
                players[turn].BuildInitialRoad(this);
            } else
            {
                players[turn].BuildRoad(this);
            }            
        }

        

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Application.OpenForms[0];
            mainMenu.Show();
            base.OnFormClosed(e);
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            dice.Roll();
            dice.DisplayDice(picDice1, picDice2);
            playerUI_DiceResult.Text = Convert.ToString(dice.DiceTotal);
            if (dice.DiceTotal == 7)
            {
                MessageBox.Show("You stole fizzy lifting drinks!", "Thief!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            for (int i = 0; i <= lblTokens.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblTokens[i].GetUpperBound(0); j++)
                {
                    
                    if (gameBoard.Hexes[i][j].Token == dice.DiceTotal)
                    {
                        lblTokens[i][j].ForeColor = Color.Red;
                    } else
                    {
                        lblTokens[i][j].ForeColor = Color.Black;
                    }
                }
            }
        }

        private void lblTokens_Click(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            int row = Convert.ToInt32(thisLabel.Name.Substring(5, 1));
            int column = Convert.ToInt32(thisLabel.Name.Substring(7, 1));
            string hexTerrain = Convert.ToString(gameBoard.Hexes[row][column].Terrain);
            MessageBox.Show(String.Format("Hex {0}, {1} \nTerrain: {2}", row, column, hexTerrain));
        }

        private void lblTokens_MouseHover(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            int i = Convert.ToInt32(thisLabel.Name.Substring(5, 1));
            int j = Convert.ToInt32(thisLabel.Name.Substring(7, 1));
            // show all the nodes neighboring this hex
            if (i > lblTokens.GetUpperBound(0) / 2)
            {
                picNodes[(2 * i)][j + 1].Visible = true;
            } else
            {
                picNodes[(2 * i)][j].Visible = true;
            }
            if (i >= lblTokens.GetUpperBound(0) / 2)
            {
                picNodes[(2 * i) + 3][j].Visible = true;
            } else
            {
                picNodes[(2 * i) + 3][j + 1].Visible = true;
            }
            picNodes[(2 * i) + 1][j].Visible = true;
            picNodes[(2 * i) + 1][j + 1].Visible = true;
            picNodes[(2 * i) + 2][j].Visible = true;
            picNodes[(2 * i) + 2][j + 1].Visible = true;
        }

        private void lblTokens_MouseLeave(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            int i = Convert.ToInt32(thisLabel.Name.Substring(5, 1));
            int j = Convert.ToInt32(thisLabel.Name.Substring(7, 1));
            // hide all the nodes neighboring this hex
            if (i > lblTokens.GetUpperBound(0) / 2)
            {
                picNodes[(2 * i)][j + 1].Visible = false;
            }
            else
            {
                picNodes[(2 * i)][j].Visible = false;
            }
            if (i >= lblTokens.GetUpperBound(0) / 2)
            {
                picNodes[(2 * i) + 3][j].Visible = false;
            }
            else
            {
                picNodes[(2 * i) + 3][j + 1].Visible = false;
            }
            picNodes[(2 * i) + 1][j].Visible = false;
            picNodes[(2 * i) + 1][j + 1].Visible = false;
            picNodes[(2 * i) + 2][j].Visible = false;
            picNodes[(2 * i) + 2][j + 1].Visible = false;
        }

        private void picNode_Click(object sender, EventArgs e)
        {

        }
    }
}

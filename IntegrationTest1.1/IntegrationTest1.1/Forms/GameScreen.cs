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
        private Label[][] lblTokens = new Label[][] { new Label[] { new Label(), new Label(), new Label() }, //3
            new Label[] { new Label(), new Label(), new Label(), new Label() }, //4
            new Label[] { new Label(), new Label(), new Label(), new Label(), new Label() },    //5
            new Label[] { new Label(), new Label(), new Label(), new Label() }, //4
            new Label[] { new Label(), new Label(), new Label() }}; //3
        private PictureBox[][] picNodes = new PictureBox[][] { new PictureBox[] { null, null, null }, //3
        new PictureBox[] { null, null, null, null }, new PictureBox[] { null, null, null, null }, //4 ~ 4
        new PictureBox[] { null, null, null, null, null }, new PictureBox[] { null, null, null, null, null }, //5 ~ 5
        new PictureBox[] { null, null, null, null, null, null }, new PictureBox[] { null, null, null, null, null, null }, //6 ~ 6
        new PictureBox[] { null, null, null, null, null }, new PictureBox[] { null, null, null, null, null },   //5 ~ 5
        new PictureBox[] { null, null, null, null }, new PictureBox[] { null, null, null, null },   //4 ~ 4
        new PictureBox[] { null, null, null}};  //3
        private Label[][] lblEdges = new Label[][] { new Label[] { null, null, null, null, null, null }, //6
        new Label[] { null, null, null, null},  //4
        new Label[] { null, null, null, null, null, null, null, null },  //8
        new Label[] { null, null, null, null, null },  //5
        new Label[] { null, null, null, null, null, null, null, null, null, null },  //10
        new Label[] { null, null, null, null, null, null },  //6
        new Label[] { null, null, null, null, null, null, null, null, null, null },  //10
        new Label[] { null, null, null, null, null },  //5
        new Label[] { null, null, null, null, null, null, null, null },  //8
        new Label[] { null, null, null, null },  //4
        new Label[] { null, null, null, null, null, null }}; //6
        private Dice dice = new Dice();
        public Player[] players = new Player[4];
        private DevCardDeck cardDeck = new DevCardDeck();
        private int round = 1;  //start from round 3 for testing purposes
        private int turn = 0;
        private int thRow;
        private int thCol;
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            GenerateTokens();
            GenerateNodes();
            GenerateEdges();
            InitializePlayerUI();
        }

        //Draws the hex tiles on the screen, as well as whatever roads exist
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

                        formGraphics.FillPolygon(texture, gameBoard.Hexes[i][j].Points); //fill the hex with the terrain texture
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
                    }
                }
            }

            for (int i = 0; i <= gameBoard.Edges.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= gameBoard.Edges[i].GetUpperBound(0); j++)
                {
                    Graphics formGraphics = this.CreateGraphics();
                    Pen pen15;
                    if (gameBoard.Edges[i][j].Road != null)
                    {
                        pen15 = new Pen(gameBoard.Edges[i][j].Road.Colour, 8);                                             
                    }
                    else
                    {
                        pen15 = new Pen(Color.DarkGreen, 2);
                    }
                    formGraphics.DrawLine(pen15, gameBoard.Edges[i][j].PointA, gameBoard.Edges[i][j].PointB);
                    formGraphics.Dispose();
                }
            }
        }

        private void GenerateTokens()
        {
            for (int i = 0; i <= lblTokens.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblTokens[i].GetUpperBound(0); j++)
                {
                    lblTokens[i][j] = new Label();
                    lblTokens[i][j].AutoSize = false;
                    lblTokens[i][j].BackColor = Color.DarkKhaki;
                    lblTokens[i][j].Location = new Point((int)gameBoard.Hexes[i][j].MidpointX - 10,
                        (int)gameBoard.Hexes[i][j].MidpointY - 10);
                    lblTokens[i][j].Font = new Font("Copperplate Gothic Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblTokens[i][j].Name = "token" + i + "_" + j;
                    if (gameBoard.Hexes[i][j].Thief)
                    {
                        lblTokens[i][j].Size = new Size(32, 32);
                        lblTokens[i][j].Image = (Image)Resources.ResourceManager.GetObject("thiefIcon");
                        thRow = i;
                        thCol = j;
                    } else
                    {
                        lblTokens[i][j].Size = new Size(30, 25);
                    }                   
                    lblTokens[i][j].TextAlign = ContentAlignment.MiddleCenter;
                    lblTokens[i][j].Text = gameBoard.GetToken(i, j);
                    Controls.Add(lblTokens[i][j]);

                }
            }
        }

        private void GenerateNodes()
        {
            for (int i = 0; i <= picNodes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= picNodes[i].GetUpperBound(0); j++)
                {
                    picNodes[i][j] = new PictureBox();
                    picNodes[i][j].Cursor = Cursors.Hand;
                    picNodes[i][j].Location = new Point((int)gameBoard.Nodes[i][j].LocationX, 
                        (int)gameBoard.Nodes[i][j].LocationY);
                    picNodes[i][j].Name = "node" + i + "_" + j;
                    picNodes[i][j].Size = new Size(10, 10);
                    picNodes[i][j].TabStop = false;
                    picNodes[i][j].Visible = false;
                    picNodes[i][j].SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(picNodes[i][j]);
                }
            }
        }

        private void GenerateEdges()
        {
            for (int i = 0; i <= lblEdges.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblEdges[i].GetUpperBound(0); j++)
                {
                    lblEdges[i][j] = new Label();
                    lblEdges[i][j].Cursor = System.Windows.Forms.Cursors.Hand;
                    int locX = (int)(gameBoard.Edges[i][j].PointA.X + gameBoard.Edges[i][j].PointB.X) / 2;
                    int locY = (int)(gameBoard.Edges[i][j].PointA.Y + gameBoard.Edges[i][j].PointB.Y) / 2;                  
                    lblEdges[i][j].Location = new System.Drawing.Point(locX - 5, locY - 5);
                    lblEdges[i][j].Name = "edge" + i + "_" + j;
                    lblEdges[i][j].Size = new System.Drawing.Size(10, 10);
                    lblEdges[i][j].TabStop = false;
                    lblEdges[i][j].Visible = false;
                    Controls.Add(lblEdges[i][j]);
                }
            }
        }

        //erase tokens whenever the game is reset
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

        //erase nodes whenever the game is reset
        private void EraseNodes()
        {
            for (int i = 0; i <= picNodes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= picNodes[i].GetUpperBound(0); j++)
                {
                    picNodes[i][j].Dispose();
                }
            }
        }

        private void InitializePlayerUI()
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
            DiceScreen diceScreen = new DiceScreen();

            diceScreen.Show();
            btnStart.Visible = false;
            
        }

        public void startGame()
        {
            InitializePlayerUI();
            playerUI.Visible = true;
            picDice1.Visible = true;
            picDice2.Visible = true;
            players[0].StartTurn(this);
            MessageBox.Show(String.Format("The game has begun.  {0}, build your first settlement and road.",
                players[0].Name));
            turnPanel.Visible = true;
            lblRoundCount.Text = "Round 1";
            // For testing purposes, Roll Dice button enabled from the start and play dev card visible
            /*btnRoll.Enabled = true;
            playerUI_PlayDevCard.Visible = true;*/
        }

        private void playerUI_EndTurn_Click(object sender, EventArgs e)
        {
            if (players[turn].Victory)
            {
                EndGame();
                return;
            }
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
                    break;
                case 2: // round 2, everyone builds second settlement and road, this time going in reverse order                   
                    if (turn > 0)
                    {
                        nextTurn = turn - 1;
                        MessageBox.Show(String.Format("End of turn for {0}.  {1}, build your second settlement and road.",
                                players[turn].Name, players[nextTurn].Name));
                        turn = nextTurn;
                        playerUI_BuildSettlement.Enabled = true;
                    } else
                    {
                        nextTurn = turn;
                        MessageBox.Show("End of round 2.  Initial settlements and roads are in place, and the game can truly begin.");
                        // distribute initial resources for first two settlements
                        MessageBox.Show("Players now harvest resources from their two starting settlements");
                        for (int i = 0; i <= gameBoard.Hexes.GetUpperBound(0); i++)
                        {
                            for (int j = 0; j <= gameBoard.Hexes[i].GetUpperBound(0); j++)
                            {

                                if (gameBoard.Hexes[i][j].Thief == false)
                                {
                                    DistributeResources(gameBoard.Hexes[i][j], i, j);
                                }
                            }
                        }
                        MessageBox.Show(String.Format("{0}, it is now your turn.", players[turn].Name));
                        round += 1;
                        lblRoundCount.Text = String.Format("Round {0}", round);
                        btnRoll.Enabled = true;
                        playerUI_TradeP2.Visible = true;
                        playerUI_TradeP3.Visible = true;
                        playerUI_TradeP4.Visible = true;
                        playerUI_PlayDevCard.Visible = true;
                    }                   
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
                    btnRoll.Enabled = true;
                    playerUI_BuildSettlement.Enabled = false;
                    playerUI_TradeP1.Enabled = false;
                    playerUI_TradeP2.Enabled = false;
                    playerUI_TradeP3.Enabled = false;
                    playerUI_TradeP4.Enabled = false;
                    turn = nextTurn;
                    players[turn].StartTurn(this);
                    break;
            }
            playerUI_BuildRoad.Enabled = false;
            playerUI_BuildCity.Enabled = false;
            playerUI_DevCard.Enabled = false;
            playerUI_EndTurn.Enabled = false;
        }

        private void playerUI_BuildSettlement_Click(object sender, EventArgs e)
        {
            if (round > 2)
            {
                // can only build a maximum of five settlements
                if (players[turn].SettlementCount == 5)
                {
                    MessageBox.Show("You've reached the maximum number of settlements(5)", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // costs 1 each brick, lumber, wool, grain
                if (players[turn].BrickCount < 1 || players[turn].LumberCount < 1 ||
                        players[turn].WoolCount < 1 || players[turn].GrainCount < 1)
                {
                    MessageBox.Show("Not enough resources!", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            btnRoll.Enabled = false;
            playerUI_BuildCity.Enabled = false;
            playerUI_BuildRoad.Enabled = false;
            playerUI_DevCard.Enabled = false;
            playerUI_TradeP1.Enabled = false;
            playerUI_TradeP2.Enabled = false;
            playerUI_TradeP3.Enabled = false;
            playerUI_TradeP4.Enabled = false;
            playerUI_PlayDevCard.Enabled = false;
            playerUI_EndTurn.Enabled = false;
            playerUI_BuildSettlement.Text = "Cancel";
            playerUI_BuildSettlement.Click -= playerUI_BuildSettlement_Click;
            playerUI_BuildSettlement.Click += new EventHandler(CancelSettlement_Click);
            for (int i = 0; i <= gameBoard.Nodes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= gameBoard.Nodes[i].GetUpperBound(0); j++)
                {
                   if (gameBoard.Nodes[i][j] != null && gameBoard.Nodes[i][j].Town == null)
                    {
                        if (TownAdjacentTowns(i, j))
                        {
                            continue;
                        }
                        //TEST: comment this out from the "if" statement                                               
                        if (round < 3 || TownAdjacentRoads(i, j))
                        {
                            picNodes[i][j].Visible = true;
                            picNodes[i][j].BackColor = players[turn].Colour;
                            picNodes[i][j].Click += new EventHandler(SelectSettlement_Click);
                        }                       
                    }
                }
            }
        } // end playerUI_BuildSettlement_Click

        private void playerUI_BuildCity_Click(object sender, EventArgs e)
        {
            // must upgrade from a settlement
            if (players[turn].SettlementCount == 0)
            {
                MessageBox.Show("Must upgrade from an existing settlement!", "No", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // can only build a maximum of four cities
            if (players[turn].CityCount == 4)
            {
                MessageBox.Show("You've reached the maximum number of cities(4)", "No", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // costs 3 ore, 2 grain
            if (players[turn].OreCount < 3 || players[turn].GrainCount < 2)
            {
                MessageBox.Show("Not enough resources!", "No", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            btnRoll.Enabled = false;
            playerUI_BuildSettlement.Enabled = false;
            playerUI_BuildRoad.Enabled = false;
            playerUI_DevCard.Enabled = false;
            playerUI_TradeP1.Enabled = false;
            playerUI_TradeP2.Enabled = false;
            playerUI_TradeP3.Enabled = false;
            playerUI_TradeP4.Enabled = false;
            playerUI_PlayDevCard.Enabled = false;
            playerUI_EndTurn.Enabled = false;
            playerUI_BuildCity.Text = "Cancel";
            playerUI_BuildCity.Click -= playerUI_BuildCity_Click;
            playerUI_BuildCity.Click += new EventHandler(CancelCity_Click);
            for (int i = 0; i <= gameBoard.Nodes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= gameBoard.Nodes[i].GetUpperBound(0); j++)
                {
                    if (gameBoard.Nodes[i][j].Town != null)
                    {
                        if (gameBoard.Nodes[i][j].Town.PlayerNum == turn &&
                        !(gameBoard.Nodes[i][j].Town is City))
                        {
                            picNodes[i][j].Enabled = true;
                            picNodes[i][j].Click += new EventHandler(SelectCity_Click);
                            picNodes[i][j].Cursor = Cursors.Hand;
                        }
                    }
                    
                }
            }
        }

        private void playerUI_BuildRoad_Click(object sender, EventArgs e)
        {
            if (round > 2)
            {
                // can only build a maximum of fifteen roads
                if (players[turn].RoadCount == 15)
                {
                    MessageBox.Show("You've reached the maximum number of roads(15)", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // costs 1 brick 1 lumber
                if (players[turn].BrickCount < 1 || players[turn].LumberCount < 1)
                {
                    MessageBox.Show("Not enough resources!", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            btnRoll.Enabled = false;
            playerUI_BuildSettlement.Enabled = false;
            playerUI_BuildCity.Enabled = false;
            playerUI_DevCard.Enabled = false;
            playerUI_TradeP1.Enabled = false;
            playerUI_TradeP2.Enabled = false;
            playerUI_TradeP3.Enabled = false;
            playerUI_TradeP4.Enabled = false;
            playerUI_PlayDevCard.Enabled = false;
            playerUI_EndTurn.Enabled = false;
            playerUI_BuildRoad.Text = "Cancel";
            playerUI_BuildRoad.Click -= playerUI_BuildRoad_Click;
            playerUI_BuildRoad.Click += new EventHandler(CancelRoad_Click);
            for (int i = 0; i <= gameBoard.Edges.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= gameBoard.Edges[i].GetUpperBound(0); j++)
                {
                    if (gameBoard.Edges[i][j].Road == null)
                    {                          
                        if (RoadAdjacentTowns(i,j) || RoadAdjacentRoads(i, j))
                        {
                        lblEdges[i][j].Visible = true;
                        lblEdges[i][j].BackColor = players[turn].Colour;
                        lblEdges[i][j].Click += new EventHandler(SelectRoad_Click);
                        }
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //reset players
            for (int i = 0; i <=3; i++)
            {
                players[i] = new Player(players[i]);
            }
            gameBoard = new Board(); //reset board
            cardDeck = new DevCardDeck();
            EraseTokens();
            GenerateTokens();
            EraseNodes();
            GenerateNodes();
            InitializePlayerUI();
            picDice1.Image = (Image)Resources.ResourceManager.GetObject("dice_blank");
            picDice2.Image = (Image)Resources.ResourceManager.GetObject("dice_blank");
            playerUI_DiceResult.Text = "";
            playerUI.Visible = false;
            picDice1.Visible = false;
            picDice2.Visible = false;
            turnPanel.Visible = false;
            victoryPanel.Visible = false;
            btnStart.Visible = true;
            btnRoll.Enabled = false;
            playerUI_BuildSettlement.Enabled = true;
            playerUI_BuildRoad.Enabled = false;
            playerUI_BuildCity.Enabled = false;
            playerUI_TradeP1.Enabled = false;
            playerUI_TradeP2.Enabled = false;
            playerUI_TradeP3.Enabled = false;
            playerUI_TradeP4.Enabled = false;
            playerUI_EndTurn.Enabled = false;
            playerUI.Enabled = true;
            round = 1;
            playerUI_BuildSettlement.Text = "Build Settlement";
            playerUI_BuildRoad.Text = "Build Road";
            playerUI_BuildCity.Text = "Build City";
        }       

        private void EndGame()
        {
            victoryPanel.Visible = true;
            lblPlayerVictor.Text = players[turn].Name;
            lblPlayerVictor.ForeColor = players[turn].Colour;
            playerUI.Enabled = false;
        }

        private void CancelSettlement_Click(object sender, EventArgs e)
        {
            HideNodes();        
            if (round > 2)
            {
                playerUI_BuildCity.Enabled = true;
                playerUI_DevCard.Enabled = true;
                playerUI_BuildRoad.Enabled = true;
                playerUI_PlayDevCard.Enabled = true;
                playerUI_TradeP1.Enabled = true;
                playerUI_TradeP2.Enabled = true;
                playerUI_TradeP3.Enabled = true;
                playerUI_TradeP4.Enabled = true;
                playerUI_EndTurn.Enabled = true;
            }            
            playerUI_BuildSettlement.Text = "Build Settlement";
            playerUI_BuildSettlement.Click -= CancelSettlement_Click;
            playerUI_BuildSettlement.Click += new EventHandler(playerUI_BuildSettlement_Click);
        }

        private void CancelRoad_Click(object sender, EventArgs e)
        {
            HideEdges();            
            if (round > 2)
            {
                playerUI_BuildSettlement.Enabled = true;
                playerUI_DevCard.Enabled = true;
                playerUI_PlayDevCard.Enabled = true;
                playerUI_BuildCity.Enabled = true;
                playerUI_TradeP1.Enabled = true;
                playerUI_TradeP2.Enabled = true;
                playerUI_TradeP3.Enabled = true;
                playerUI_TradeP4.Enabled = true;
                playerUI_EndTurn.Enabled = true;
            }            
            playerUI_BuildRoad.Text = "Build Road";
            playerUI_BuildRoad.Click -= CancelRoad_Click;
            playerUI_BuildRoad.Click += new EventHandler(playerUI_BuildRoad_Click);
        }

        private void CancelCity_Click(object sender, EventArgs e)
        {
            HideNodes();
            playerUI_TradeP1.Enabled = true;
            playerUI_TradeP2.Enabled = true;
            playerUI_TradeP3.Enabled = true;
            playerUI_TradeP4.Enabled = true;
            playerUI_BuildSettlement.Enabled = true;
            playerUI_DevCard.Enabled = true;
            playerUI_BuildRoad.Enabled = true;
            playerUI_PlayDevCard.Enabled = true;
            playerUI_EndTurn.Enabled = true;
            playerUI_BuildCity.Text = "Build City";
            playerUI_BuildCity.Click -= CancelCity_Click;
            playerUI_BuildCity.Click += new EventHandler(playerUI_BuildCity_Click);
        }

        private void SelectSettlement_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to place a settlement here?", 
                "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (round > 2)
                {
                    players[turn].BuildSettlement(this);
                }
                else
                {
                    players[turn].BuildInitialSettlement(this);
                    playerUI_BuildSettlement.Enabled = false;
                }
                int i;
                int j;
                PictureBox thisNode = (PictureBox)sender;
                if (thisNode.Name.Length == 7)
                {
                    i = Convert.ToInt32(thisNode.Name.Substring(4, 1));
                    j = Convert.ToInt32(thisNode.Name.Substring(6, 1));
                }
                else
                {
                    i = Convert.ToInt32(thisNode.Name.Substring(4, 2));
                    j = Convert.ToInt32(thisNode.Name.Substring(7, 1));
                }
                
                gameBoard.Nodes[i][j].Town = new Settlement(turn, players[turn].Colour);
                thisNode.Image = gameBoard.Nodes[i][j].Town.Image;
                thisNode.Click -= new EventHandler(SelectSettlement_Click);
                thisNode.Size = new System.Drawing.Size(21, 21);
                thisNode.Location = new Point(thisNode.Location.X - 4, thisNode.Location.Y - 4);
                thisNode.Cursor = Cursors.Arrow;
                thisNode.Enabled = false;
                HideNodes();
                playerUI_BuildRoad.Enabled = true;
                if (round > 2)
                {
                    playerUI_BuildCity.Enabled = true;
                    playerUI_DevCard.Enabled = true;
                    playerUI_PlayDevCard.Enabled = true;
                    playerUI_TradeP1.Enabled = true;
                    playerUI_TradeP2.Enabled = true;
                    playerUI_TradeP3.Enabled = true;
                    playerUI_TradeP4.Enabled = true;
                    playerUI_EndTurn.Enabled = true;
                }
                playerUI_BuildSettlement.Text = "Build Settlement";
                playerUI_BuildSettlement.Click -= CancelSettlement_Click;
                playerUI_BuildSettlement.Click += new EventHandler(playerUI_BuildSettlement_Click);
            }
        }

        private void SelectCity_Click(object sender, EventArgs e)
        {
            //confirming if you want to upgrade this settlement
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to upgrade this settlement into a city?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                players[turn].BuildCity(this);
                int i;
                int j;
                PictureBox thisNode = (PictureBox)sender;
                if (thisNode.Name.Length == 7)
                {
                    i = Convert.ToInt32(thisNode.Name.Substring(4, 1));
                    j = Convert.ToInt32(thisNode.Name.Substring(6, 1));
                }
                else
                {
                    i = Convert.ToInt32(thisNode.Name.Substring(4, 2));
                    j = Convert.ToInt32(thisNode.Name.Substring(7, 1));
                }

                gameBoard.Nodes[i][j].Town = new City(gameBoard.Nodes[i][j].Town);
                thisNode.Image = gameBoard.Nodes[i][j].Town.Image;
                thisNode.Click -= SelectCity_Click;
                thisNode.Size = new Size(30, 30);
                thisNode.Location = new Point(thisNode.Location.X - 4, thisNode.Location.Y - 4);
                thisNode.Cursor = Cursors.Arrow;
                thisNode.Enabled = false;
                HideNodes();
                playerUI_TradeP1.Enabled = true;
                playerUI_TradeP2.Enabled = true;
                playerUI_TradeP3.Enabled = true;
                playerUI_TradeP4.Enabled = true;
                playerUI_BuildSettlement.Enabled = true;
                playerUI_DevCard.Enabled = true;
                playerUI_BuildRoad.Enabled = true;
                playerUI_PlayDevCard.Enabled = true;
                playerUI_EndTurn.Enabled = true;
                playerUI_BuildCity.Text = "Build City";
                playerUI_BuildCity.Click -= CancelCity_Click;
                playerUI_BuildCity.Click += new EventHandler(playerUI_BuildCity_Click);
            }
        }

        private void SelectRoad_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to place a road here?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (round > 2)
                {
                    players[turn].BuildRoad(this);
                }
                else
                {
                    players[turn].BuildInitialRoad(this);
                    playerUI_BuildRoad.Enabled = false;
                }
                int i;
                int j;
                Label thisLabel = (Label)sender;
                if (thisLabel.Name.Length == 7)
                {
                    i = Convert.ToInt32(thisLabel.Name.Substring(4, 1));
                    j = Convert.ToInt32(thisLabel.Name.Substring(6, 1));
                }
                else
                {
                    i = Convert.ToInt32(thisLabel.Name.Substring(4, 2));
                    j = Convert.ToInt32(thisLabel.Name.Substring(7, 1));
                }
                gameBoard.Edges[i][j].Road = new Road(turn, players[turn].Colour);
                HideEdges();
                if (round > 2)
                {
                    playerUI_BuildCity.Enabled = true;
                    playerUI_DevCard.Enabled = true;
                    playerUI_BuildSettlement.Enabled = true;
                    playerUI_PlayDevCard.Enabled = true;
                    playerUI_TradeP1.Enabled = true;
                    playerUI_TradeP2.Enabled = true;
                    playerUI_TradeP3.Enabled = true;
                    playerUI_TradeP4.Enabled = true;
                    playerUI_EndTurn.Enabled = true;
                }
                playerUI_BuildRoad.Text = "Build Road";
                playerUI_BuildRoad.Click -= CancelRoad_Click;
                playerUI_BuildRoad.Click += new EventHandler(playerUI_BuildRoad_Click);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Player.ClearPlayerCount();
            Player.ResetLargestArmy();
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
                MessageBox.Show("You rolled 7!  All players with over seven total resources lose half.",
                "Dice rolled", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                for (int i = 0; i <= players.GetUpperBound(0); i++)
                {
                    players[i].DepleteResources();
                }
                ActivateThief();
            }
            else
            {
                MessageBox.Show(String.Format("You rolled {0}!", dice.DiceTotal), "Dice rolled");
                for (int i = 0; i <= gameBoard.Hexes.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= gameBoard.Hexes[i].GetUpperBound(0); j++)
                    {

                        if (gameBoard.Hexes[i][j].Token == dice.DiceTotal && 
                            gameBoard.Hexes[i][j].Thief == false)
                        {
                            DistributeResources(gameBoard.Hexes[i][j], i, j);
                        }
                    }
                }
            }
            playerUI_BrickCount.Text = Convert.ToString(players[turn].BrickCount);
            playerUI_GrainCount.Text = Convert.ToString(players[turn].GrainCount);
            playerUI_LumberCount.Text = Convert.ToString(players[turn].LumberCount);
            playerUI_OreCount.Text = Convert.ToString(players[turn].OreCount);
            playerUI_WoolCount.Text = Convert.ToString(players[turn].WoolCount);

            //For testing purposes, keep btnRoll enabled
            btnRoll.Enabled = false;
            playerUI_BuildSettlement.Enabled = true;
            playerUI_BuildCity.Enabled = true;
            playerUI_BuildRoad.Enabled = true;
            playerUI_DevCard.Enabled = true;                                
            playerUI_PlayDevCard.Enabled = true;
            playerUI_EndTurn.Enabled = true;
            playerUI_TradeP1.Enabled = true;
            playerUI_TradeP2.Enabled = true;
            playerUI_TradeP3.Enabled = true;
            playerUI_TradeP4.Enabled = true;
        }

        private void DistributeResources(Hex h, int i, int j)
        {
            Settlement currentSettlement;
            try
            {
                if (i > gameBoard.Hexes.GetUpperBound(0) / 2 && gameBoard.Nodes[(2 * i)][j + 1].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i)][j + 1].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
                else if (gameBoard.Nodes[(2 * i)][j].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i)][j].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (i >= gameBoard.Hexes.GetUpperBound(0) / 2 && gameBoard.Nodes[(2 * i) + 3][j].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i) + 3][j].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
                else if (gameBoard.Nodes[(2 * i) + 3][j + 1].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i) + 3][j + 1].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 1][j].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i) + 1][j].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 1][j + 1].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i) + 1][j + 1].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 2][j].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i) + 2][j].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 2][j + 1].Town != null)
                {
                    currentSettlement = gameBoard.Nodes[(2 * i) + 2][j + 1].Town;
                    players[currentSettlement.PlayerNum].HarvestResources(h, currentSettlement);
                }
            }
            catch (IndexOutOfRangeException) { }
        }
        
        //create event handlers to move thief to a new tile
        public void ActivateThief()
        {
            MessageBox.Show("Click on one of the tokens to move the thief to a different tile.", "Thief activated!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            for (int i = 0; i <= lblTokens.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblTokens[i].GetUpperBound(0); j++)
                {
                    if (gameBoard.Hexes[i][j].Thief == false)
                    {
                        lblTokens[i][j].Click += new EventHandler(MoveThief_Click);
                        lblTokens[i][j].Cursor = Cursors.Hand;
                        lblTokens[i][j].BackColor = players[turn].Colour;
                        lblTokens[i][j].ForeColor = Color.Gold;
                    }
                }
            }
            playerUI.Enabled = false;
        }

        //Select new tile to move thief
        private void MoveThief_Click(object sender, EventArgs e)
        {
            Label thisLabel = (Label)sender;
            int row = Convert.ToInt32(thisLabel.Name.Substring(5, 1));
            int column = Convert.ToInt32(thisLabel.Name.Substring(7, 1));
            gameBoard.Hexes[thRow][thCol].MoveThief(gameBoard.Hexes[row][column]);
            

            //restore previous thief token to its normal state
            if (gameBoard.Hexes[thRow][thCol].Terrain == Hex.terrainType.Desert)
            {
                lblTokens[thRow][thCol].Size = new Size(0, 0);
            }
            else
            {
                lblTokens[thRow][thCol].Size = new Size(30, 25);
                lblTokens[thRow][thCol].Text = gameBoard.GetToken(thRow, thCol);
            }
            lblTokens[thRow][thCol].Image = null;

            // update thief token index
            thRow = row;
            thCol = column;

            //remove event handlers
            for (int i = 0; i <= lblTokens.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblTokens[i].GetUpperBound(0); j++)
                {
                    lblTokens[i][j].Click -= MoveThief_Click;
                    lblTokens[i][j].Cursor = Cursors.Default;
                    if (i != thRow || j != thCol)
                    {
                        lblTokens[i][j].BackColor = Color.DarkKhaki;
                        lblTokens[i][j].ForeColor = Color.Black;
                    }
                }
            }

            ActivateRobPlayer();
        }

        //create event handlers for neighboring settlements/cities of the newly occupied thief tile
        private void ActivateRobPlayer()
        {
            int i = thRow;
            int j = thCol;
            bool adjacentPlayers = false;
            try
            {
                if (i > gameBoard.Hexes.GetUpperBound(0) / 2 && gameBoard.Nodes[(2 * i)][j + 1].Town != null && 
                    gameBoard.Nodes[(2 * i)][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i)][j + 1].Enabled = true;
                    picNodes[(2 * i)][j + 1].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i)][j + 1].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
                else if (gameBoard.Nodes[(2 * i)][j].Town != null && gameBoard.Nodes[(2 * i)][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i)][j].Enabled = true;
                    picNodes[(2 * i)][j].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i)][j].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (i >= gameBoard.Hexes.GetUpperBound(0) / 2 && gameBoard.Nodes[(2 * i) + 3][j].Town != null &&
                    gameBoard.Nodes[(2 * i) + 3][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 3][j].Enabled = true;
                    picNodes[(2 * i) + 3][j].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i) + 3][j].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
                else if (gameBoard.Nodes[(2 * i) + 3][j + 1].Town != null && 
                    gameBoard.Nodes[(2 * i) + 3][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 3][j + 1].Enabled = true;
                    picNodes[(2 * i) + 3][j + 1].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i) + 3][j + 1].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 1][j].Town != null && gameBoard.Nodes[(2 * i) + 1][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 1][j].Enabled = true;
                    picNodes[(2 * i) + 1][j].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i) + 1][j].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 1][j + 1].Town != null && 
                    gameBoard.Nodes[(2 * i) + 1][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 1][j + 1].Enabled = true;
                    picNodes[(2 * i) + 1][j + 1].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i) + 1][j + 1].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 2][j].Town != null && gameBoard.Nodes[(2 * i) + 2][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 2][j].Enabled = true;
                    picNodes[(2 * i) + 2][j].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i) + 2][j].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 2][j + 1].Town != null && 
                    gameBoard.Nodes[(2 * i) + 2][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 2][j + 1].Enabled = true;
                    picNodes[(2 * i) + 2][j + 1].Click += new EventHandler(RobPlayer_Click);
                    picNodes[(2 * i) + 2][j + 1].Cursor = Cursors.Hand;
                    adjacentPlayers = true;
                }
            }
            catch (IndexOutOfRangeException) { }
            if (adjacentPlayers == false)
            {
                MessageBox.Show("There are no neighboring players to rob!");
                //change thief-occupied token to thief state
                lblTokens[thRow][thCol].Size = new Size(32, 32);
                lblTokens[thRow][thCol].Image = (Image)Resources.ResourceManager.GetObject("thiefIcon");
                lblTokens[thRow][thCol].Text = "";
                lblTokens[thRow][thCol].BackColor = Color.DarkKhaki;
                lblTokens[thRow][thCol].ForeColor = Color.Black;

                playerUI.Enabled = true;
            }
            else
            {
                MessageBox.Show("Click a neighboring settlement/city to rob that corresponding player");
            }
        }

        //Select player to rob by clicking his/her settlement/city
        private void RobPlayer_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            PictureBox thisNode = (PictureBox)sender;
            if (thisNode.Name.Length == 7)
            {
                i = Convert.ToInt32(thisNode.Name.Substring(4, 1));
                j = Convert.ToInt32(thisNode.Name.Substring(6, 1));
            }
            else
            {
                i = Convert.ToInt32(thisNode.Name.Substring(4, 2));
                j = Convert.ToInt32(thisNode.Name.Substring(7, 1));
            }
            int pIndex = gameBoard.Nodes[i][j].Town.PlayerNum;
            players[turn].StealResource(this, players[pIndex]);

            DeactivateRobPlayer();

            //change thief-occupied token to thief state
            lblTokens[thRow][thCol].Size = new Size(32, 32);
            lblTokens[thRow][thCol].Image = (Image)Resources.ResourceManager.GetObject("thiefIcon");
            lblTokens[thRow][thCol].Text = "";
            lblTokens[thRow][thCol].BackColor = Color.DarkKhaki;
            lblTokens[thRow][thCol].ForeColor = Color.Black;

            playerUI.Enabled = true;
        }

        //Remove rob player event handlers from settlement/city nodes
        private void DeactivateRobPlayer()
        {
            int i = thRow;
            int j = thCol;
            try
            {
                if (i > gameBoard.Hexes.GetUpperBound(0) / 2 && gameBoard.Nodes[(2 * i)][j + 1].Town != null &&
                    gameBoard.Nodes[(2 * i)][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i)][j + 1].Enabled = false;
                    picNodes[(2 * i)][j + 1].Click -= RobPlayer_Click;
                    picNodes[(2 * i)][j + 1].Cursor = Cursors.Default;
                }
                else if (gameBoard.Nodes[(2 * i)][j].Town != null && gameBoard.Nodes[(2 * i)][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i)][j].Enabled = false;
                    picNodes[(2 * i)][j].Click -= RobPlayer_Click;
                    picNodes[(2 * i)][j].Cursor = Cursors.Default;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (i >= gameBoard.Hexes.GetUpperBound(0) / 2 && gameBoard.Nodes[(2 * i) + 3][j].Town != null &&
                    gameBoard.Nodes[(2 * i) + 3][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 3][j].Enabled = false;
                    picNodes[(2 * i) + 3][j].Click -= RobPlayer_Click;
                    picNodes[(2 * i) + 3][j].Cursor = Cursors.Default;
                }
                else if (gameBoard.Nodes[(2 * i) + 3][j + 1].Town != null &&
                    gameBoard.Nodes[(2 * i) + 3][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 3][j + 1].Enabled = false;
                    picNodes[(2 * i) + 3][j + 1].Click -= RobPlayer_Click;
                    picNodes[(2 * i) + 3][j + 1].Cursor = Cursors.Default;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 1][j].Town != null && gameBoard.Nodes[(2 * i) + 1][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 1][j].Enabled = false;
                    picNodes[(2 * i) + 1][j].Click -= RobPlayer_Click;
                    picNodes[(2 * i) + 1][j].Cursor = Cursors.Default;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 1][j + 1].Town != null &&
                    gameBoard.Nodes[(2 * i) + 1][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 1][j + 1].Enabled = false;
                    picNodes[(2 * i) + 1][j + 1].Click -= RobPlayer_Click;
                    picNodes[(2 * i) + 1][j + 1].Cursor = Cursors.Default;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 2][j].Town != null && gameBoard.Nodes[(2 * i) + 2][j].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 2][j].Enabled = false;
                    picNodes[(2 * i) + 2][j].Click -= RobPlayer_Click;
                    picNodes[(2 * i) + 2][j].Cursor = Cursors.Default;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[(2 * i) + 2][j + 1].Town != null &&
                    gameBoard.Nodes[(2 * i) + 2][j + 1].Town.PlayerNum != turn)
                {
                    picNodes[(2 * i) + 2][j + 1].Enabled = false;
                    picNodes[(2 * i) + 2][j + 1].Click -= RobPlayer_Click;
                    picNodes[(2 * i) + 2][j + 1].Cursor = Cursors.Default;
                }
            }
            catch (IndexOutOfRangeException) { }
        }

        //Remove the create settlement/city event handlers from nodes and hide all that are unsettled
        private void HideNodes()
        {
            for (int i = 0; i <= picNodes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= picNodes[i].GetUpperBound(0); j++)
                {                   
                    if (gameBoard.Nodes[i][j].Town == null)
                    {
                        picNodes[i][j].Visible = false;
                        picNodes[i][j].Click -= SelectSettlement_Click;
                    } else
                    {
                        picNodes[i][j].Cursor = Cursors.Arrow;
                    }
                    picNodes[i][j].Click -= SelectCity_Click;
                }
            }
        }

        //Remove the creat road event handlers and hide the "buttons"
        private void HideEdges()
        {
            for (int i = 0; i <= lblEdges.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblEdges[i].GetUpperBound(0); j++)
                {
                    lblEdges[i][j].Visible = false;
                    lblEdges[i][j].Click -= SelectRoad_Click;
                }
            }
        }

        private void playerUI_TradeP1_Click(object sender, EventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen();
            tradeScreen.current = turn;
            tradeScreen.recipient = 0;
            tradeScreen.Show();
            playerUI.Enabled = false;
        }

        private void playerUI_TradeP2_Click(object sender, EventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen();
            tradeScreen.current = turn;
            tradeScreen.recipient = 1;
            tradeScreen.Show();
            playerUI.Enabled = false;
        }

        private void playerUI_TradeP3_Click(object sender, EventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen();
            tradeScreen.current = turn;
            tradeScreen.recipient = 2;
            tradeScreen.Show();
            playerUI.Enabled = false;
        }

        private void playerUI_TradeP4_Click(object sender, EventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen();
            tradeScreen.current = turn;
            tradeScreen.recipient = 3;
            tradeScreen.Show();
            playerUI.Enabled = false;
        }

        private void playerUI_DevCard_Click(object sender, EventArgs e)
        {
            // cost one each wool, ore, grain
            if (players[turn].WoolCount < 1 || players[turn].OreCount < 1 || players[turn].GrainCount < 1)
            {
                MessageBox.Show("Not enough resources!", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cardDeck.DealCard(this, players[turn]);
        }

        private void playerUI_PlayDevCard_Click(object sender, EventArgs e)
        {
            DevCardScreen cardScreen = new DevCardScreen();
            cardScreen.current = turn;            
            cardScreen.Show();
            playerUI.Enabled = false;
        }

        private bool RoadAdjacentRoads(int i, int j)
        {
            // return true as soon as an adjacent road is found
            if (i % 2 == 0)     //Even row
            {
                try
                {
                    if (gameBoard.Edges[i][j - 1].Road != null && gameBoard.Edges[i][j - 1].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                } catch (IndexOutOfRangeException) { }
                try
                {
                    if (gameBoard.Edges[i][j + 1].Road != null && gameBoard.Edges[i][j + 1].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                if (i < gameBoard.Edges.GetUpperBound(0) / 2) //Before halfway point
                {
                    try
                    {
                        if (gameBoard.Edges[i + 1][(j + 1) / 2].Road != null && 
                            gameBoard.Edges[i + 1][(j + 1) / 2].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                    try
                    {
                        if (gameBoard.Edges[i - 1][j / 2].Road != null &&
                            gameBoard.Edges[i - 1][j / 2].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
                else  //After halfway point
                {
                    try
                    {
                        if (gameBoard.Edges[i + 1][j/ 2].Road != null && gameBoard.Edges[i + 1][j / 2].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                    try
                    {
                        if (gameBoard.Edges[i - 1][(j + 1) / 2].Road != null &&
                            gameBoard.Edges[i - 1][(j + 1) / 2].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
            }
            else    //Odd Row
            {
                try
                {
                    if (gameBoard.Edges[i - 1][j * 2].Road != null && gameBoard.Edges[i - 1][j * 2].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                try
                {
                    if (gameBoard.Edges[i + 1][j * 2].Road != null && gameBoard.Edges[i + 1][j * 2].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                if (i <= gameBoard.Edges.GetUpperBound(0) / 2) //before or at halfway point
                {
                    try
                    {
                        if (gameBoard.Edges[i - 1][(j * 2) - 1].Road != null && 
                            gameBoard.Edges[i - 1][(j * 2) - 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
                else //after halfway point
                {
                    try
                    {
                        if (gameBoard.Edges[i - 1][(j * 2) + 1].Road != null &&
                            gameBoard.Edges[i - 1][(j * 2) + 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
                if (i < gameBoard.Edges.GetUpperBound(0) / 2) //before halfway point
                {
                    try
                    {
                        if (gameBoard.Edges[i + 1][(j * 2) + 1].Road != null &&
                            gameBoard.Edges[i + 1][(j * 2) + 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
                else //after or at halfway point
                {
                    try
                    {
                        if (gameBoard.Edges[i + 1][(j * 2) - 1].Road != null &&
                            gameBoard.Edges[i + 1][(j * 2) - 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
            }
            return false;
        }

        private bool RoadAdjacentTowns(int i, int j)
        {
            if (i % 2 == 0)     //Even row
            {
                if (i < gameBoard.Edges.GetUpperBound(0) / 2) //Before halfway point
                {
                    if ((gameBoard.Nodes[i][j / 2].Town != null && gameBoard.Nodes[i][j / 2].Town.PlayerNum == turn) ||
                    (gameBoard.Nodes[i + 1][(j + 1) / 2].Town != null && gameBoard.Nodes[i + 1][(j + 1) / 2].Town.PlayerNum == turn))
                    {
                        return true;
                    }
                }
                else //After halfway point
                {
                    if ((gameBoard.Nodes[i][(j + 1) / 2].Town != null && gameBoard.Nodes[i][(j + 1) / 2].Town.PlayerNum == turn) ||
                    (gameBoard.Nodes[i + 1][j / 2].Town != null && gameBoard.Nodes[i + 1][j / 2].Town.PlayerNum == turn))
                    {
                        return true;
                    }
                }
            }
            else    //Odd row
            {
                if ((gameBoard.Nodes[i][j].Town != null && gameBoard.Nodes[i][j].Town.PlayerNum == turn) ||
                    (gameBoard.Nodes[i + 1][j].Town != null && gameBoard.Nodes[i + 1][j].Town.PlayerNum == turn))
                {
                    return true;
                }
            }
                return false;
        }

        private bool TownAdjacentTowns(int i, int j)
        {
            try
            {
                if (gameBoard.Nodes[i + 1][j].Town != null)
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (gameBoard.Nodes[i - 1][j].Town != null)
                {
                    return true;
                }
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (i % 2 == 1) //Odd row
                {
                    if (i < gameBoard.Nodes.Length / 2) //Before halfway point
                    {
                        if (gameBoard.Nodes[i - 1][j - 1].Town != null)
                        {
                            return true;
                        }
                    }
                    else //After halfway point
                    {
                        if (gameBoard.Nodes[i - 1][j + 1].Town != null)
                        {
                            return true;
                        }
                    }
                }
                else //Even row
                {
                    if (i < gameBoard.Nodes.Length / 2) //Before halfway point
                    {
                        if (gameBoard.Nodes[i + 1][j + 1].Town != null)
                        {
                            return true;
                        }
                    }
                    else //After halfway point
                    {
                        if (gameBoard.Nodes[i + 1][j - 1].Town != null)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException) { }
            return false;
        }

        private bool TownAdjacentRoads(int i, int j)
        {
            if (i % 2 == 0) //Even row
            {
                // i - 1, j
                try
                {
                    if (gameBoard.Edges[i - 1][j].Road != null && gameBoard.Edges[i - 1][j].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                // i, 2j
                try
                {
                    if (gameBoard.Edges[i][j * 2].Road != null && gameBoard.Edges[i][j * 2].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                if (i < gameBoard.Nodes.Length / 2) //Before halfway point
                {
                    // i, 2j+1	
                    try
                    {
                        if (gameBoard.Edges[i][(j * 2) + 1].Road != null && 
                            gameBoard.Edges[i][(j * 2) + 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
                else //After halfway point
                {
                    // i, 2j-1
                    try
                    {
                        if (gameBoard.Edges[i][(j * 2) - 1].Road != null && 
                            gameBoard.Edges[i][(j * 2) - 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
            }
            else //Odd row
            {
                // i, j
                try
                {
                    if (gameBoard.Edges[i][j].Road != null && gameBoard.Edges[i][j].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                // i - 1, 2j
                try
                {
                    if (gameBoard.Edges[i - 1][j * 2].Road != null && gameBoard.Edges[i - 1][j * 2].Road.PlayerNum == turn)
                    {
                        return true;
                    }
                }
                catch (IndexOutOfRangeException) { }
                if (i < gameBoard.Nodes.Length / 2) //Before halfway point
                {
                    // i-1, 2j-1
                    try
                    {
                        if (gameBoard.Edges[i - 1][(j * 2) - 1].Road != null && 
                            gameBoard.Edges[i - 1][(j * 2) - 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
                else //After halfway point
                {
                    // i-1,2j+1
                    try
                    {
                        if (gameBoard.Edges[i - 1][(j * 2) + 1].Road != null && 
                            gameBoard.Edges[i - 1][(j * 2) + 1].Road.PlayerNum == turn)
                        {
                            return true;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
            }
            return false;
        }

        //Implements quick tests using Button btnTest and NumericUpDown updTest (both dummied out)
        /*private void btnTest_Click(object sender, EventArgs e)
        {
            if (updTest.Value == 7)
            {
                ActivateThief();
            } 
            else
            {
                for (int i = 0; i <= gameBoard.Hexes.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= gameBoard.Hexes[i].GetUpperBound(0); j++)
                    {

                        if (gameBoard.Hexes[i][j].Token == updTest.Value &&
                            gameBoard.Hexes[i][j].Thief == false)
                        {
                            DistributeResources(gameBoard.Hexes[i][j], i, j);
                        }
                    }
                }
                playerUI_BrickCount.Text = Convert.ToString(players[turn].BrickCount);
                playerUI_GrainCount.Text = Convert.ToString(players[turn].GrainCount);
                playerUI_LumberCount.Text = Convert.ToString(players[turn].LumberCount);
                playerUI_OreCount.Text = Convert.ToString(players[turn].OreCount);
                playerUI_WoolCount.Text = Convert.ToString(players[turn].WoolCount);
            }            
        }*/
    }
}

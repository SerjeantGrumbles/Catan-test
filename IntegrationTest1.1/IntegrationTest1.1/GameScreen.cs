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
    public partial class GameScreen : Form
    {
        private Board gameBoard = new Board();
        private Label[][] lblTokens = new Label[][] { new Label[] { new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label(), new Label() },
            new Label[] { new Label(), new Label(), new Label() }};
        private Dice dice = new Dice();
        public Player player1, player2, player3, player4;
        int roundCounter = 1;
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            GenerateTokens();
            lblPlayer1.Text = player1.Name;
            lblPlayer2.Text = player2.Name;
            lblPlayer3.Text = player3.Name;
            lblPlayer4.Text = player4.Name;
            lblPlayer1.ForeColor = player1.Colour;
            lblPlayer2.ForeColor = player2.Colour;
            lblPlayer3.ForeColor = player3.Colour;
            lblPlayer4.ForeColor = player4.Colour;
            playerUI_TradeP1.Text = "Trade With " + player1.Name;
            playerUI_TradeP2.Text = "Trade With " + player2.Name;
            playerUI_TradeP3.Text = "Trade With " + player3.Name;
            playerUI_TradeP4.Text = "Trade With " + player4.Name;
            playerUI_TradeP1.Visible = false;
        }

        private void GameScreen_Paint(object Sender, PaintEventArgs e)
        {
            Bitmap[][] hexImages = new Bitmap[][] { new Bitmap[] { null, null, null },
                new Bitmap[] { null, null, null, null },
                new Bitmap[] { null, null, null, null, null },
                new Bitmap[] { null, null, null, null },
                new Bitmap[] { null, null, null }};

            //The midpoints of the hexagon
            float x_0 = 200;
            float y_0 = 200;

            int r = 50; //radius of hexagon

            for (int i = 0; i <= hexImages.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= hexImages[i].GetUpperBound(0); j++)
                {
                    string fileDirectory = @"C:\Users\Conrad\Documents\Class Folders\SDEV265-Projects\FillHexTest\FillHexTest\Resources\";

                    try
                    {
                        hexImages[i][j] = (Bitmap)Image.FromFile((fileDirectory + gameBoard.GetHex(i, j)),
                            true);

                        TextureBrush texture = new TextureBrush(hexImages[i][j]);
                        texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
                        Graphics formGraphics = this.CreateGraphics();
                        Pen pen15 = new Pen(Color.Black, 5);

                        PointF[] points = new PointF[6];
                        //Create 6 points
                        for (int a = 0; a < 6; a++)
                        {
                            float yCoord = x_0 + r * (float)Math.Cos(a * 60 * Math.PI / 180f);
                            float xCoord = y_0 + r * (float)Math.Sin(a * 60 * Math.PI / 180f);
                            points[a] = new PointF(xCoord, yCoord);
                        }

                        formGraphics.DrawPolygon(pen15, points);
                        formGraphics.FillPolygon(texture, points);
                        formGraphics.Dispose();
                        y_0 += 87;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
                    }


                }
                switch (i)
                {
                    case 0:
                        y_0 = 157;
                        break;
                    case 1:
                        y_0 = 113;
                        break;
                    case 2:
                        y_0 = 157;
                        break;
                    case 3:
                        y_0 = 200;
                        break;
                }
                x_0 += (1.5f * (float)r);
            }
        } // end GameScreen_Paint

        private void GenerateTokens()
        {
            int x = 190;
            int y = 190;

            for (int i = 0; i <= lblTokens.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= lblTokens[i].GetUpperBound(0); j++)
                {
                    lblTokens[i][j] = new Label();
                    lblTokens[i][j].AutoSize = false;
                    lblTokens[i][j].BackColor = System.Drawing.Color.DarkKhaki;
                    lblTokens[i][j].Location = new System.Drawing.Point(x, y);
                    lblTokens[i][j].Font = new System.Drawing.Font("Copperplate Gothic Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //lblTokens[i][j].Name = "label1";
                    if (gameBoard.Hexes[i][j].Token == 0)
                    {
                        lblTokens[i][j].Size = new System.Drawing.Size(0, 0);
                    } else
                    {
                        lblTokens[i][j].Size = new System.Drawing.Size(30, 25);
                    }                   
                    lblTokens[i][j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lblTokens[i][j].Text = gameBoard.GetToken(i, j);
                    this.Controls.Add(lblTokens[i][j]);
                    x += 87;
                }
                switch (i)
                {
                    case 0:
                        x = 147;
                        break;
                    case 1:
                        x = 103;
                        break;
                    case 2:
                        x = 147;
                        break;
                    case 3:
                        x = 190;
                        break;
                }
                y += 75;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnReset.Visible = true;
            playerUI.Visible = true;
            picDice1.Visible = true;
            picDice2.Visible = true;
            player1.StartTurn(this);
        }

        private void playerUI_EndTurn_Click(object sender, EventArgs e)
        {
            if (player1.MyTurn)
            {
                player1.EndTurn();
                MessageBox.Show(String.Format("End of turn for {0}.  {1}, it is now your turn.", 
                    player1.Name, player2.Name));
                player2.StartTurn(this);
                playerUI_TradeP1.Visible = true;
                playerUI_TradeP2.Visible = false;
            } else if (player2.MyTurn)
            {
                player2.EndTurn();
                MessageBox.Show(String.Format("End of turn for {0}.  {1}, it is now your turn.",
                    player2.Name, player3.Name));
                player3.StartTurn(this);
                playerUI_TradeP2.Visible = true;
                playerUI_TradeP3.Visible = false;
            }
            else if (player3.MyTurn)
            {
                player3.EndTurn();
                MessageBox.Show(String.Format("End of turn for {0}.  {1}, it is now your turn.",
                    player3.Name, player4.Name));
                player4.StartTurn(this);
                playerUI_TradeP3.Visible = true;
                playerUI_TradeP4.Visible = false;
            } else
            {
                player4.EndTurn();
                MessageBox.Show(String.Format("End of turn for {0}.  {1}, it is now your turn.",
                    player4.Name, player1.Name));
                player1.StartTurn(this);
                playerUI_TradeP4.Visible = true;
                playerUI_TradeP1.Visible = false;
                roundCounter += 1;
            }
        }

        private void playerUI_BuildSettlement_Click(object sender, EventArgs e)
        {
            if (player1.MyTurn)
            {
                player1.BuildSettlement(this);
            }
            else if (player2.MyTurn)
            {
                player2.BuildSettlement(this);
            }
            else if (player3.MyTurn)
            {
                player3.BuildSettlement(this);
            }
            else
            {
                player4.BuildSettlement(this);
            }
        }

        private void playerUI_BuildCity_Click(object sender, EventArgs e)
        {
            if (player1.MyTurn)
            {
                player1.BuildCity(this);
            }
            else if (player2.MyTurn)
            {
                player2.BuildCity(this);
            }
            else if (player3.MyTurn)
            {
                player3.BuildCity(this);
            }
            else
            {
                player4.BuildCity(this);
            }
        }

        private void playerUI_BuildRoad_Click(object sender, EventArgs e)
        {
            if (player1.MyTurn)
            {
                player1.BuildRoad(this);
            }
            else if (player2.MyTurn)
            {
                player2.BuildRoad(this);
            }
            else if (player3.MyTurn)
            {
                player3.BuildRoad(this);
            }
            else
            {
                player4.BuildRoad(this);
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
    }
}

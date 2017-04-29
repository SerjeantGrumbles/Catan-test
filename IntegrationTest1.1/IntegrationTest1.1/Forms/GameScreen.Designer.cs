namespace IntegrationTest1._1
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.btnRoll = new System.Windows.Forms.Button();
            this.picDice1 = new System.Windows.Forms.PictureBox();
            this.picDice2 = new System.Windows.Forms.PictureBox();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.playerPanel = new System.Windows.Forms.Panel();
            this.lblPlayer4 = new System.Windows.Forms.Label();
            this.lblPlayer3 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.playerUI = new System.Windows.Forms.GroupBox();
            this.playerUI_TradeP2 = new System.Windows.Forms.Button();
            this.playerUI_DiceResult = new System.Windows.Forms.TextBox();
            this.playerUI_TradeP4 = new System.Windows.Forms.Button();
            this.playerUI_TradeP3 = new System.Windows.Forms.Button();
            this.playerUI_TradeP1 = new System.Windows.Forms.Button();
            this.playerUI_DevCard = new System.Windows.Forms.Button();
            this.playerUI_BuildRoad = new System.Windows.Forms.Button();
            this.playerUI_BuildCity = new System.Windows.Forms.Button();
            this.playerUI_BuildSettlement = new System.Windows.Forms.Button();
            this.playerUI_EndTurn = new System.Windows.Forms.Button();
            this.picLongestRoad = new System.Windows.Forms.PictureBox();
            this.picLargestArmy = new System.Windows.Forms.PictureBox();
            this.playerUI_KnightCount = new System.Windows.Forms.TextBox();
            this.lblKnights = new System.Windows.Forms.Label();
            this.picRoadCount = new System.Windows.Forms.PictureBox();
            this.playerUI_RoadCount = new System.Windows.Forms.TextBox();
            this.picSettlementCount = new System.Windows.Forms.PictureBox();
            this.playerUI_SettlementCount = new System.Windows.Forms.TextBox();
            this.picCityCount = new System.Windows.Forms.PictureBox();
            this.playerUI_CityCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblResources = new System.Windows.Forms.Label();
            this.picWool = new System.Windows.Forms.PictureBox();
            this.playerUI_WoolCount = new System.Windows.Forms.TextBox();
            this.picOre = new System.Windows.Forms.PictureBox();
            this.playerUI_OreCount = new System.Windows.Forms.TextBox();
            this.picGrain = new System.Windows.Forms.PictureBox();
            this.playerUI_GrainCount = new System.Windows.Forms.TextBox();
            this.picBrick = new System.Windows.Forms.PictureBox();
            this.playerUI_BrickCount = new System.Windows.Forms.TextBox();
            this.picLumber = new System.Windows.Forms.PictureBox();
            this.playerUI_VPCount = new System.Windows.Forms.TextBox();
            this.lblVP = new System.Windows.Forms.Label();
            this.playerUI_Info = new System.Windows.Forms.Label();
            this.playerUI_LumberCount = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblRoundCount = new System.Windows.Forms.Label();
            this.picBuildCosts = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDice2)).BeginInit();
            this.playerPanel.SuspendLayout();
            this.playerUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLongestRoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLargestArmy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettlementCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCityCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuildCosts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRoll
            // 
            this.btnRoll.Font = new System.Drawing.Font("Copperplate Gothic Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoll.ForeColor = System.Drawing.Color.Black;
            this.btnRoll.Location = new System.Drawing.Point(26, 19);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(93, 23);
            this.btnRoll.TabIndex = 1;
            this.btnRoll.Text = "Roll Dice";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // picDice1
            // 
            this.picDice1.BackColor = System.Drawing.Color.Transparent;
            this.picDice1.Image = global::IntegrationTest1._1.Properties.Resources.dice_blank;
            this.picDice1.Location = new System.Drawing.Point(676, 12);
            this.picDice1.Name = "picDice1";
            this.picDice1.Size = new System.Drawing.Size(50, 50);
            this.picDice1.TabIndex = 11;
            this.picDice1.TabStop = false;
            this.picDice1.Visible = false;
            // 
            // picDice2
            // 
            this.picDice2.BackColor = System.Drawing.Color.Transparent;
            this.picDice2.Image = ((System.Drawing.Image)(resources.GetObject("picDice2.Image")));
            this.picDice2.Location = new System.Drawing.Point(751, 12);
            this.picDice2.Name = "picDice2";
            this.picDice2.Size = new System.Drawing.Size(50, 50);
            this.picDice2.TabIndex = 12;
            this.picDice2.TabStop = false;
            this.picDice2.Visible = false;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.Gold;
            this.lblPlayer1.Location = new System.Drawing.Point(3, 7);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(183, 25);
            this.lblPlayer1.TabIndex = 19;
            this.lblPlayer1.Text = "(Player)";
            // 
            // playerPanel
            // 
            this.playerPanel.BackColor = System.Drawing.Color.Maroon;
            this.playerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.playerPanel.Controls.Add(this.lblPlayer4);
            this.playerPanel.Controls.Add(this.lblPlayer3);
            this.playerPanel.Controls.Add(this.lblPlayer2);
            this.playerPanel.Controls.Add(this.lblPlayer1);
            this.playerPanel.Location = new System.Drawing.Point(12, 12);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(253, 109);
            this.playerPanel.TabIndex = 20;
            // 
            // lblPlayer4
            // 
            this.lblPlayer4.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer4.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer4.ForeColor = System.Drawing.Color.Gold;
            this.lblPlayer4.Location = new System.Drawing.Point(3, 80);
            this.lblPlayer4.Name = "lblPlayer4";
            this.lblPlayer4.Size = new System.Drawing.Size(183, 25);
            this.lblPlayer4.TabIndex = 22;
            this.lblPlayer4.Text = "(Player)";
            // 
            // lblPlayer3
            // 
            this.lblPlayer3.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer3.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer3.ForeColor = System.Drawing.Color.Gold;
            this.lblPlayer3.Location = new System.Drawing.Point(3, 55);
            this.lblPlayer3.Name = "lblPlayer3";
            this.lblPlayer3.Size = new System.Drawing.Size(183, 25);
            this.lblPlayer3.TabIndex = 21;
            this.lblPlayer3.Text = "(Player)";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.Gold;
            this.lblPlayer2.Location = new System.Drawing.Point(3, 31);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(183, 25);
            this.lblPlayer2.TabIndex = 20;
            this.lblPlayer2.Text = "(Player)";
            // 
            // playerUI
            // 
            this.playerUI.BackColor = System.Drawing.Color.Maroon;
            this.playerUI.Controls.Add(this.picBuildCosts);
            this.playerUI.Controls.Add(this.playerUI_TradeP2);
            this.playerUI.Controls.Add(this.playerUI_DiceResult);
            this.playerUI.Controls.Add(this.playerUI_TradeP4);
            this.playerUI.Controls.Add(this.playerUI_TradeP3);
            this.playerUI.Controls.Add(this.playerUI_TradeP1);
            this.playerUI.Controls.Add(this.playerUI_DevCard);
            this.playerUI.Controls.Add(this.playerUI_BuildRoad);
            this.playerUI.Controls.Add(this.btnRoll);
            this.playerUI.Controls.Add(this.playerUI_BuildCity);
            this.playerUI.Controls.Add(this.playerUI_BuildSettlement);
            this.playerUI.Controls.Add(this.playerUI_EndTurn);
            this.playerUI.Controls.Add(this.picLongestRoad);
            this.playerUI.Controls.Add(this.picLargestArmy);
            this.playerUI.Controls.Add(this.playerUI_KnightCount);
            this.playerUI.Controls.Add(this.lblKnights);
            this.playerUI.Controls.Add(this.picRoadCount);
            this.playerUI.Controls.Add(this.playerUI_RoadCount);
            this.playerUI.Controls.Add(this.picSettlementCount);
            this.playerUI.Controls.Add(this.playerUI_SettlementCount);
            this.playerUI.Controls.Add(this.picCityCount);
            this.playerUI.Controls.Add(this.playerUI_CityCount);
            this.playerUI.Controls.Add(this.label6);
            this.playerUI.Controls.Add(this.lblResources);
            this.playerUI.Controls.Add(this.picWool);
            this.playerUI.Controls.Add(this.playerUI_WoolCount);
            this.playerUI.Controls.Add(this.picOre);
            this.playerUI.Controls.Add(this.playerUI_OreCount);
            this.playerUI.Controls.Add(this.picGrain);
            this.playerUI.Controls.Add(this.playerUI_GrainCount);
            this.playerUI.Controls.Add(this.picBrick);
            this.playerUI.Controls.Add(this.playerUI_BrickCount);
            this.playerUI.Controls.Add(this.picLumber);
            this.playerUI.Controls.Add(this.playerUI_VPCount);
            this.playerUI.Controls.Add(this.lblVP);
            this.playerUI.Controls.Add(this.playerUI_Info);
            this.playerUI.Controls.Add(this.playerUI_LumberCount);
            this.playerUI.Font = new System.Drawing.Font("Copperplate Gothic Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerUI.ForeColor = System.Drawing.Color.Gold;
            this.playerUI.Location = new System.Drawing.Point(872, 12);
            this.playerUI.Name = "playerUI";
            this.playerUI.Size = new System.Drawing.Size(217, 874);
            this.playerUI.TabIndex = 71;
            this.playerUI.TabStop = false;
            this.playerUI.Text = "(Player)";
            this.playerUI.Visible = false;
            // 
            // playerUI_TradeP2
            // 
            this.playerUI_TradeP2.ForeColor = System.Drawing.Color.Black;
            this.playerUI_TradeP2.Location = new System.Drawing.Point(26, 162);
            this.playerUI_TradeP2.Name = "playerUI_TradeP2";
            this.playerUI_TradeP2.Size = new System.Drawing.Size(163, 23);
            this.playerUI_TradeP2.TabIndex = 8;
            this.playerUI_TradeP2.Text = "Trade With Player 2";
            this.playerUI_TradeP2.UseVisualStyleBackColor = true;
            this.playerUI_TradeP2.Click += new System.EventHandler(this.playerUI_TradeP2_Click);
            // 
            // playerUI_DiceResult
            // 
            this.playerUI_DiceResult.ForeColor = System.Drawing.Color.Black;
            this.playerUI_DiceResult.Location = new System.Drawing.Point(128, 19);
            this.playerUI_DiceResult.Name = "playerUI_DiceResult";
            this.playerUI_DiceResult.ReadOnly = true;
            this.playerUI_DiceResult.Size = new System.Drawing.Size(43, 20);
            this.playerUI_DiceResult.TabIndex = 2;
            // 
            // playerUI_TradeP4
            // 
            this.playerUI_TradeP4.ForeColor = System.Drawing.Color.Black;
            this.playerUI_TradeP4.Location = new System.Drawing.Point(26, 216);
            this.playerUI_TradeP4.Name = "playerUI_TradeP4";
            this.playerUI_TradeP4.Size = new System.Drawing.Size(163, 23);
            this.playerUI_TradeP4.TabIndex = 10;
            this.playerUI_TradeP4.Text = "Trade With Player 4";
            this.playerUI_TradeP4.UseVisualStyleBackColor = true;
            this.playerUI_TradeP4.Click += new System.EventHandler(this.playerUI_TradeP4_Click);
            // 
            // playerUI_TradeP3
            // 
            this.playerUI_TradeP3.ForeColor = System.Drawing.Color.Black;
            this.playerUI_TradeP3.Location = new System.Drawing.Point(27, 189);
            this.playerUI_TradeP3.Name = "playerUI_TradeP3";
            this.playerUI_TradeP3.Size = new System.Drawing.Size(163, 23);
            this.playerUI_TradeP3.TabIndex = 9;
            this.playerUI_TradeP3.Text = "Trade With Player 3";
            this.playerUI_TradeP3.UseVisualStyleBackColor = true;
            this.playerUI_TradeP3.Click += new System.EventHandler(this.playerUI_TradeP3_Click);
            // 
            // playerUI_TradeP1
            // 
            this.playerUI_TradeP1.ForeColor = System.Drawing.Color.Black;
            this.playerUI_TradeP1.Location = new System.Drawing.Point(26, 135);
            this.playerUI_TradeP1.Name = "playerUI_TradeP1";
            this.playerUI_TradeP1.Size = new System.Drawing.Size(163, 23);
            this.playerUI_TradeP1.TabIndex = 7;
            this.playerUI_TradeP1.Text = "Trade With Player 1";
            this.playerUI_TradeP1.UseVisualStyleBackColor = true;
            this.playerUI_TradeP1.Click += new System.EventHandler(this.playerUI_TradeP1_Click);
            // 
            // playerUI_DevCard
            // 
            this.playerUI_DevCard.ForeColor = System.Drawing.Color.Black;
            this.playerUI_DevCard.Location = new System.Drawing.Point(26, 106);
            this.playerUI_DevCard.Name = "playerUI_DevCard";
            this.playerUI_DevCard.Size = new System.Drawing.Size(163, 23);
            this.playerUI_DevCard.TabIndex = 6;
            this.playerUI_DevCard.Text = "Buy Development Card";
            this.playerUI_DevCard.UseVisualStyleBackColor = true;
            this.playerUI_DevCard.Click += new System.EventHandler(this.playerUI_DevCard_Click);
            // 
            // playerUI_BuildRoad
            // 
            this.playerUI_BuildRoad.Enabled = false;
            this.playerUI_BuildRoad.ForeColor = System.Drawing.Color.Black;
            this.playerUI_BuildRoad.Location = new System.Drawing.Point(106, 77);
            this.playerUI_BuildRoad.Name = "playerUI_BuildRoad";
            this.playerUI_BuildRoad.Size = new System.Drawing.Size(83, 23);
            this.playerUI_BuildRoad.TabIndex = 5;
            this.playerUI_BuildRoad.Text = "Build Road";
            this.playerUI_BuildRoad.UseVisualStyleBackColor = true;
            this.playerUI_BuildRoad.Click += new System.EventHandler(this.playerUI_BuildRoad_Click);
            // 
            // playerUI_BuildCity
            // 
            this.playerUI_BuildCity.Enabled = false;
            this.playerUI_BuildCity.ForeColor = System.Drawing.Color.Black;
            this.playerUI_BuildCity.Location = new System.Drawing.Point(25, 77);
            this.playerUI_BuildCity.Name = "playerUI_BuildCity";
            this.playerUI_BuildCity.Size = new System.Drawing.Size(75, 23);
            this.playerUI_BuildCity.TabIndex = 4;
            this.playerUI_BuildCity.Text = "Build City";
            this.playerUI_BuildCity.UseVisualStyleBackColor = true;
            this.playerUI_BuildCity.Click += new System.EventHandler(this.playerUI_BuildCity_Click);
            // 
            // playerUI_BuildSettlement
            // 
            this.playerUI_BuildSettlement.ForeColor = System.Drawing.Color.Black;
            this.playerUI_BuildSettlement.Location = new System.Drawing.Point(26, 48);
            this.playerUI_BuildSettlement.Name = "playerUI_BuildSettlement";
            this.playerUI_BuildSettlement.Size = new System.Drawing.Size(163, 23);
            this.playerUI_BuildSettlement.TabIndex = 3;
            this.playerUI_BuildSettlement.Text = "Build Settlement";
            this.playerUI_BuildSettlement.UseVisualStyleBackColor = true;
            this.playerUI_BuildSettlement.Click += new System.EventHandler(this.playerUI_BuildSettlement_Click);
            // 
            // playerUI_EndTurn
            // 
            this.playerUI_EndTurn.Enabled = false;
            this.playerUI_EndTurn.ForeColor = System.Drawing.Color.Black;
            this.playerUI_EndTurn.Location = new System.Drawing.Point(68, 248);
            this.playerUI_EndTurn.Name = "playerUI_EndTurn";
            this.playerUI_EndTurn.Size = new System.Drawing.Size(75, 23);
            this.playerUI_EndTurn.TabIndex = 11;
            this.playerUI_EndTurn.Text = "End Turn";
            this.playerUI_EndTurn.UseVisualStyleBackColor = true;
            this.playerUI_EndTurn.Click += new System.EventHandler(this.playerUI_EndTurn_Click);
            // 
            // picLongestRoad
            // 
            this.picLongestRoad.Location = new System.Drawing.Point(116, 369);
            this.picLongestRoad.Name = "picLongestRoad";
            this.picLongestRoad.Size = new System.Drawing.Size(92, 127);
            this.picLongestRoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLongestRoad.TabIndex = 26;
            this.picLongestRoad.TabStop = false;
            this.picLongestRoad.Visible = false;
            // 
            // picLargestArmy
            // 
            this.picLargestArmy.Location = new System.Drawing.Point(12, 369);
            this.picLargestArmy.Name = "picLargestArmy";
            this.picLargestArmy.Size = new System.Drawing.Size(90, 127);
            this.picLargestArmy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLargestArmy.TabIndex = 25;
            this.picLargestArmy.TabStop = false;
            this.picLargestArmy.Visible = false;
            // 
            // playerUI_KnightCount
            // 
            this.playerUI_KnightCount.ForeColor = System.Drawing.Color.Black;
            this.playerUI_KnightCount.Location = new System.Drawing.Point(130, 343);
            this.playerUI_KnightCount.Name = "playerUI_KnightCount";
            this.playerUI_KnightCount.ReadOnly = true;
            this.playerUI_KnightCount.Size = new System.Drawing.Size(60, 20);
            this.playerUI_KnightCount.TabIndex = 13;
            // 
            // lblKnights
            // 
            this.lblKnights.AutoSize = true;
            this.lblKnights.Location = new System.Drawing.Point(37, 347);
            this.lblKnights.Name = "lblKnights";
            this.lblKnights.Size = new System.Drawing.Size(52, 12);
            this.lblKnights.TabIndex = 23;
            this.lblKnights.Text = "Knights";
            // 
            // picRoadCount
            // 
            this.picRoadCount.Image = global::IntegrationTest1._1.Properties.Resources.roadIcon;
            this.picRoadCount.Location = new System.Drawing.Point(128, 523);
            this.picRoadCount.Name = "picRoadCount";
            this.picRoadCount.Size = new System.Drawing.Size(27, 25);
            this.picRoadCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRoadCount.TabIndex = 22;
            this.picRoadCount.TabStop = false;
            // 
            // playerUI_RoadCount
            // 
            this.playerUI_RoadCount.ForeColor = System.Drawing.Color.Black;
            this.playerUI_RoadCount.Location = new System.Drawing.Point(127, 552);
            this.playerUI_RoadCount.Name = "playerUI_RoadCount";
            this.playerUI_RoadCount.ReadOnly = true;
            this.playerUI_RoadCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_RoadCount.TabIndex = 16;
            this.playerUI_RoadCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picSettlementCount
            // 
            this.picSettlementCount.Image = global::IntegrationTest1._1.Properties.Resources.settlementIcon;
            this.picSettlementCount.Location = new System.Drawing.Point(95, 523);
            this.picSettlementCount.Name = "picSettlementCount";
            this.picSettlementCount.Size = new System.Drawing.Size(27, 25);
            this.picSettlementCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSettlementCount.TabIndex = 20;
            this.picSettlementCount.TabStop = false;
            // 
            // playerUI_SettlementCount
            // 
            this.playerUI_SettlementCount.ForeColor = System.Drawing.Color.Black;
            this.playerUI_SettlementCount.Location = new System.Drawing.Point(94, 552);
            this.playerUI_SettlementCount.Name = "playerUI_SettlementCount";
            this.playerUI_SettlementCount.ReadOnly = true;
            this.playerUI_SettlementCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_SettlementCount.TabIndex = 15;
            this.playerUI_SettlementCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picCityCount
            // 
            this.picCityCount.Image = global::IntegrationTest1._1.Properties.Resources.cityIcon;
            this.picCityCount.Location = new System.Drawing.Point(62, 523);
            this.picCityCount.Name = "picCityCount";
            this.picCityCount.Size = new System.Drawing.Size(27, 25);
            this.picCityCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCityCount.TabIndex = 18;
            this.picCityCount.TabStop = false;
            // 
            // playerUI_CityCount
            // 
            this.playerUI_CityCount.ForeColor = System.Drawing.Color.Black;
            this.playerUI_CityCount.Location = new System.Drawing.Point(61, 552);
            this.playerUI_CityCount.Name = "playerUI_CityCount";
            this.playerUI_CityCount.ReadOnly = true;
            this.playerUI_CityCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_CityCount.TabIndex = 14;
            this.playerUI_CityCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 508);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cities, Settlements, Roads";
            // 
            // lblResources
            // 
            this.lblResources.AutoSize = true;
            this.lblResources.Location = new System.Drawing.Point(69, 578);
            this.lblResources.Name = "lblResources";
            this.lblResources.Size = new System.Drawing.Size(71, 12);
            this.lblResources.TabIndex = 15;
            this.lblResources.Text = "Resources";
            // 
            // picWool
            // 
            this.picWool.Image = global::IntegrationTest1._1.Properties.Resources.sheepIcon;
            this.picWool.Location = new System.Drawing.Point(161, 600);
            this.picWool.Name = "picWool";
            this.picWool.Size = new System.Drawing.Size(27, 25);
            this.picWool.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWool.TabIndex = 14;
            this.picWool.TabStop = false;
            // 
            // playerUI_WoolCount
            // 
            this.playerUI_WoolCount.Location = new System.Drawing.Point(160, 629);
            this.playerUI_WoolCount.Name = "playerUI_WoolCount";
            this.playerUI_WoolCount.ReadOnly = true;
            this.playerUI_WoolCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_WoolCount.TabIndex = 21;
            this.playerUI_WoolCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picOre
            // 
            this.picOre.Image = global::IntegrationTest1._1.Properties.Resources.oreIcon;
            this.picOre.Location = new System.Drawing.Point(128, 600);
            this.picOre.Name = "picOre";
            this.picOre.Size = new System.Drawing.Size(27, 25);
            this.picOre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOre.TabIndex = 12;
            this.picOre.TabStop = false;
            // 
            // playerUI_OreCount
            // 
            this.playerUI_OreCount.Location = new System.Drawing.Point(128, 629);
            this.playerUI_OreCount.Name = "playerUI_OreCount";
            this.playerUI_OreCount.ReadOnly = true;
            this.playerUI_OreCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_OreCount.TabIndex = 20;
            this.playerUI_OreCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picGrain
            // 
            this.picGrain.Image = global::IntegrationTest1._1.Properties.Resources.grainIcon;
            this.picGrain.Location = new System.Drawing.Point(95, 600);
            this.picGrain.Name = "picGrain";
            this.picGrain.Size = new System.Drawing.Size(27, 25);
            this.picGrain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGrain.TabIndex = 10;
            this.picGrain.TabStop = false;
            // 
            // playerUI_GrainCount
            // 
            this.playerUI_GrainCount.Location = new System.Drawing.Point(94, 629);
            this.playerUI_GrainCount.Name = "playerUI_GrainCount";
            this.playerUI_GrainCount.ReadOnly = true;
            this.playerUI_GrainCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_GrainCount.TabIndex = 19;
            this.playerUI_GrainCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picBrick
            // 
            this.picBrick.Image = global::IntegrationTest1._1.Properties.Resources.brickIcon;
            this.picBrick.Location = new System.Drawing.Point(62, 600);
            this.picBrick.Name = "picBrick";
            this.picBrick.Size = new System.Drawing.Size(27, 25);
            this.picBrick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBrick.TabIndex = 8;
            this.picBrick.TabStop = false;
            // 
            // playerUI_BrickCount
            // 
            this.playerUI_BrickCount.Location = new System.Drawing.Point(61, 629);
            this.playerUI_BrickCount.Name = "playerUI_BrickCount";
            this.playerUI_BrickCount.ReadOnly = true;
            this.playerUI_BrickCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_BrickCount.TabIndex = 18;
            this.playerUI_BrickCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picLumber
            // 
            this.picLumber.Image = global::IntegrationTest1._1.Properties.Resources.woodIcon;
            this.picLumber.Location = new System.Drawing.Point(29, 600);
            this.picLumber.Name = "picLumber";
            this.picLumber.Size = new System.Drawing.Size(27, 25);
            this.picLumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLumber.TabIndex = 6;
            this.picLumber.TabStop = false;
            // 
            // playerUI_VPCount
            // 
            this.playerUI_VPCount.ForeColor = System.Drawing.Color.Black;
            this.playerUI_VPCount.Location = new System.Drawing.Point(129, 313);
            this.playerUI_VPCount.Name = "playerUI_VPCount";
            this.playerUI_VPCount.ReadOnly = true;
            this.playerUI_VPCount.Size = new System.Drawing.Size(61, 20);
            this.playerUI_VPCount.TabIndex = 12;
            // 
            // lblVP
            // 
            this.lblVP.AutoSize = true;
            this.lblVP.Location = new System.Drawing.Point(8, 316);
            this.lblVP.Name = "lblVP";
            this.lblVP.Size = new System.Drawing.Size(94, 12);
            this.lblVP.TabIndex = 4;
            this.lblVP.Text = "Victory Points";
            // 
            // playerUI_Info
            // 
            this.playerUI_Info.AutoSize = true;
            this.playerUI_Info.Location = new System.Drawing.Point(56, 292);
            this.playerUI_Info.Name = "playerUI_Info";
            this.playerUI_Info.Size = new System.Drawing.Size(133, 12);
            this.playerUI_Info.TabIndex = 3;
            this.playerUI_Info.Text = "Player 1 Information";
            // 
            // playerUI_LumberCount
            // 
            this.playerUI_LumberCount.Location = new System.Drawing.Point(28, 629);
            this.playerUI_LumberCount.Name = "playerUI_LumberCount";
            this.playerUI_LumberCount.ReadOnly = true;
            this.playerUI_LumberCount.Size = new System.Drawing.Size(28, 20);
            this.playerUI_LumberCount.TabIndex = 17;
            this.playerUI_LumberCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Copperplate Gothic Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(372, 826);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 23);
            this.btnStart.TabIndex = 72;
            this.btnStart.Text = "Begin Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Copperplate Gothic Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(487, 826);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 23);
            this.btnReset.TabIndex = 73;
            this.btnReset.Text = "Restart Game";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblRoundCount
            // 
            this.lblRoundCount.BackColor = System.Drawing.Color.Maroon;
            this.lblRoundCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRoundCount.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoundCount.ForeColor = System.Drawing.Color.Gold;
            this.lblRoundCount.Location = new System.Drawing.Point(353, 12);
            this.lblRoundCount.Name = "lblRoundCount";
            this.lblRoundCount.Size = new System.Drawing.Size(183, 25);
            this.lblRoundCount.TabIndex = 28;
            this.lblRoundCount.Text = "(Round)";
            this.lblRoundCount.Visible = false;
            // 
            // picBuildCosts
            // 
            this.picBuildCosts.Image = global::IntegrationTest1._1.Properties.Resources.BuildingCosts;
            this.picBuildCosts.Location = new System.Drawing.Point(6, 668);
            this.picBuildCosts.Name = "picBuildCosts";
            this.picBuildCosts.Size = new System.Drawing.Size(202, 200);
            this.picBuildCosts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBuildCosts.TabIndex = 74;
            this.picBuildCosts.TabStop = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IntegrationTest1._1.Properties.Resources.Sea;
            this.ClientSize = new System.Drawing.Size(1103, 886);
            this.Controls.Add(this.lblRoundCount);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.playerUI);
            this.Controls.Add(this.playerPanel);
            this.Controls.Add(this.picDice2);
            this.Controls.Add(this.picDice1);
            this.Name = "GameScreen";
            this.Text = "Settlers of Catan";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picDice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDice2)).EndInit();
            this.playerPanel.ResumeLayout(false);
            this.playerUI.ResumeLayout(false);
            this.playerUI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLongestRoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLargestArmy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRoadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettlementCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCityCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBrick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuildCosts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.PictureBox picDice1;
        private System.Windows.Forms.PictureBox picDice2;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Panel playerPanel;
        private System.Windows.Forms.Label lblPlayer4;
        private System.Windows.Forms.Label lblPlayer3;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.TextBox playerUI_DiceResult;
        private System.Windows.Forms.Button playerUI_TradeP4;
        private System.Windows.Forms.Button playerUI_TradeP3;
        private System.Windows.Forms.Button playerUI_TradeP1;
        private System.Windows.Forms.Button playerUI_DevCard;
        private System.Windows.Forms.Button playerUI_BuildCity;
        private System.Windows.Forms.Label lblKnights;
        private System.Windows.Forms.PictureBox picRoadCount;
        private System.Windows.Forms.PictureBox picSettlementCount;
        private System.Windows.Forms.PictureBox picCityCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblResources;
        private System.Windows.Forms.PictureBox picWool;
        private System.Windows.Forms.PictureBox picOre;
        private System.Windows.Forms.PictureBox picGrain;
        private System.Windows.Forms.PictureBox picBrick;
        private System.Windows.Forms.PictureBox picLumber;
        private System.Windows.Forms.Label lblVP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.GroupBox playerUI;
        public System.Windows.Forms.PictureBox picLongestRoad;
        public System.Windows.Forms.PictureBox picLargestArmy;
        public System.Windows.Forms.TextBox playerUI_KnightCount;
        public System.Windows.Forms.TextBox playerUI_RoadCount;
        public System.Windows.Forms.TextBox playerUI_SettlementCount;
        public System.Windows.Forms.TextBox playerUI_CityCount;
        public System.Windows.Forms.TextBox playerUI_WoolCount;
        public System.Windows.Forms.TextBox playerUI_OreCount;
        public System.Windows.Forms.TextBox playerUI_GrainCount;
        public System.Windows.Forms.TextBox playerUI_BrickCount;
        public System.Windows.Forms.TextBox playerUI_VPCount;
        public System.Windows.Forms.Label playerUI_Info;
        public System.Windows.Forms.TextBox playerUI_LumberCount;
        private System.Windows.Forms.Button playerUI_TradeP2;
        public System.Windows.Forms.Button playerUI_BuildRoad;
        public System.Windows.Forms.Button playerUI_BuildSettlement;
        public System.Windows.Forms.Button playerUI_EndTurn;
        private System.Windows.Forms.Label lblRoundCount;
        private System.Windows.Forms.PictureBox picBuildCosts;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using IntegrationTest1._1;
using IntegrationTest1._1.Properties;

namespace IntegrationTest1._1
{
    public class Player
    {
        private string name;
        private Color colour;
        private int victoryPts = 0;
        private int knightCt = 0;
        //TEST: Set resources to 20
        private int lumberCt = 0, brickCt = 0, grainCt = 0, woolCt = 0, oreCt = 0; //Resources
        private int cityCt = 0, settlementCt = 0, roadCt = 0; //Buildings
        private int vpCardsPlayed = 0;
        private bool longestRoad = false, largestArmy = false, victory = false;
        public enum resourceType { Lumber, Grain, Wool, Ore, Brick}
        public ArrayList DevCards;
        private static ArrayList allPlayers = new ArrayList();
        private static int largestArmyCt = 2;

        public Player(string nome, Color colore)
        {
            name = nome;
            colour = colore;
            DevCards = new ArrayList();
            allPlayers.Add(this);
        }

        public Player(Player p)
        {
            name = p.Name;
            colour = p.Colour;
            DevCards = new ArrayList();
        }

        public string Name
        {
            get { return name; }
        }

        public Color Colour
        {
            get { return colour; }
        }

        public int VictoryPoints
        {
            get { return victoryPts; }
        }

        public int KnightCount
        {
            get { return knightCt; }
        }

        public int LumberCount
        {
            get { return lumberCt; }
        }

        public int BrickCount
        {
            get { return brickCt; }
        }

        public int GrainCount
        {
            get { return grainCt; }
        }

        public int WoolCount
        {
            get { return woolCt; }
        }

        public int OreCount
        {
            get { return oreCt; }
        }

        public int CityCount
        {
            get { return cityCt; }
        }

        public int TotalResources
        {
            get { return lumberCt + brickCt + grainCt + woolCt + oreCt; }
        }

        public int SettlementCount
        {
            get { return settlementCt; }
        }

        public int RoadCount
        {
            get { return roadCt; }
        }

        public bool LongestRoad
        {
            get { return longestRoad; }
        }

        public bool LargestArmy
        {
            get { return largestArmy; }
        }

        public bool Victory
        {
            get { return victory; }
        }

        public void StartTurn(GameScreen g)
        {
            SetVictoryPoints();
            g.playerUI.Text = Name;
            g.playerUI_Info.Text = Name + " Information";
            g.playerUI_KnightCount.Text = Convert.ToString(KnightCount);
            //Cities, Settlements, Roads
            g.playerUI_CityCount.Text = Convert.ToString(CityCount);
            g.playerUI_SettlementCount.Text = Convert.ToString(SettlementCount);
            g.playerUI_RoadCount.Text = Convert.ToString(RoadCount);
            //Resources
            g.playerUI_LumberCount.Text = Convert.ToString(LumberCount);
            g.playerUI_BrickCount.Text = Convert.ToString(BrickCount);
            g.playerUI_GrainCount.Text = Convert.ToString(GrainCount);
            g.playerUI_WoolCount.Text = Convert.ToString(WoolCount);
            g.playerUI_OreCount.Text = Convert.ToString(OreCount);
            
            g.playerUI_VPCount.Text = Convert.ToString(VictoryPoints);
            if (LargestArmy)
            {
                g.picLargestArmy.Image = Resources.largestArmy;
            }
            else
            {
                g.picLargestArmy.Image = null;
            }

            g.lblTurn.ForeColor = Colour;
            g.lblTurn.Text = Name + "'s Turn";
        }

        public void BuildInitialSettlement(GameScreen g)
        {
            settlementCt += 1;
            SetVictoryPoints();
            MessageBox.Show("Settlement placed!");
            //Update display
            g.playerUI_VPCount.Text = Convert.ToString(VictoryPoints);
            g.playerUI_SettlementCount.Text = Convert.ToString(SettlementCount);
            g.playerUI_BuildSettlement.Enabled = false;
            g.playerUI_BuildRoad.Enabled = true;             
        }

        public void BuildInitialRoad(GameScreen g)
        {
            roadCt += 1;
            SetVictoryPoints();
            MessageBox.Show("Road placed!");
            g.playerUI_RoadCount.Text = Convert.ToString(RoadCount);
            g.playerUI_BuildRoad.Enabled = false;
            g.playerUI_EndTurn.Enabled = true;
        }

        public void BuildSettlement(GameScreen g)
        {
            settlementCt += 1;
            brickCt -= 1;
            lumberCt -= 1;
            woolCt -= 1;
            grainCt -= 1;
            SetVictoryPoints();
            MessageBox.Show("Settlement placed!");
            //Update display
            g.playerUI_VPCount.Text = Convert.ToString(VictoryPoints);
            g.playerUI_SettlementCount.Text = Convert.ToString(SettlementCount);
            g.playerUI_BrickCount.Text = Convert.ToString(BrickCount);
            g.playerUI_LumberCount.Text = Convert.ToString(LumberCount);
            g.playerUI_WoolCount.Text = Convert.ToString(WoolCount);
            g.playerUI_GrainCount.Text = Convert.ToString(GrainCount);
        }

        public void BuildCity(GameScreen g)
        {
            cityCt += 1;
            settlementCt -= 1;
            oreCt -= 3;
            grainCt -= 2;
            SetVictoryPoints();
            MessageBox.Show("City created!");
            //Update display
            g.playerUI_VPCount.Text = Convert.ToString(VictoryPoints);
            g.playerUI_CityCount.Text = Convert.ToString(CityCount);
            g.playerUI_SettlementCount.Text = Convert.ToString(SettlementCount);
            g.playerUI_OreCount.Text = Convert.ToString(OreCount);
            g.playerUI_GrainCount.Text = Convert.ToString(GrainCount);               
        }

        public void BuildRoad(GameScreen g)
        {

            roadCt += 1;
            brickCt -= 1;
            lumberCt -= 1;
            SetVictoryPoints();
            MessageBox.Show("Road placed!");
            g.playerUI_RoadCount.Text = Convert.ToString(RoadCount);
            g.playerUI_BrickCount.Text = Convert.ToString(BrickCount);
            g.playerUI_LumberCount.Text = Convert.ToString(LumberCount);
        }

        public void BuyDevCard()
        {
            woolCt -= 1;
            oreCt -= 1;
            grainCt -= 1;
        }

        private void SetVictoryPoints()
        {
            int pts = vpCardsPlayed;
            if (LongestRoad)
            {
                pts += 2;
            }
            if (LargestArmy)
            {
                pts += 2;
            }
            victoryPts = pts + SettlementCount + (2 * CityCount);

            if (VictoryPoints >= 10)
            {
                MessageBox.Show("You are the winner!  Click the \"End Turn\" button to end the game.",
                    "Victory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                victory = true;
            }
        }

        public void HarvestResources(Hex h, Settlement s)
        {
            switch (h.Terrain)
            {
                case Hex.terrainType.Field:
                    grainCt += s.ResourceYield;
                    break;
                case Hex.terrainType.Forest:
                    lumberCt += s.ResourceYield;
                    break;
                case Hex.terrainType.Hills:
                    brickCt += s.ResourceYield;
                    break;
                case Hex.terrainType.Mountains:
                    oreCt += s.ResourceYield;
                    break;
                case Hex.terrainType.Pasture:
                    woolCt += s.ResourceYield;
                    break;
            }
        }

        public void DepleteResources()
        {
            if (TotalResources > 7)
            {
                int target = TotalResources / 2;
                int counter = 1;
                Random RNG = new Random();
                while (counter <= target)
                {
                    resourceType resourceEnum = (resourceType)RNG.Next(5);
                    switch (resourceEnum)
                    {
                        case resourceType.Lumber:
                            if (LumberCount > 0)
                            {
                                lumberCt -= 1;
                                counter += 1;
                            }
                            break;
                        case resourceType.Grain:
                            if (GrainCount > 0)
                            {
                                grainCt -= 1;
                                counter += 1;
                            }
                            break;
                        case resourceType.Wool:
                            if (WoolCount > 0)
                            {
                                woolCt -= 1;
                                counter += 1;
                            }
                            break;
                        case resourceType.Ore:
                            if (OreCount > 0)
                            {
                                oreCt -= 1;
                                counter += 1;
                            }
                            break;
                        case resourceType.Brick:
                            if (BrickCount > 0)
                            {
                                brickCt -= 1;
                                counter += 1;
                            }
                            break;
                    }
                }
            }
        }

        public void MakeTrade(GameScreen g, Player recipient, resourceType myResource, int myAmt, 
            resourceType theirResource, int theirAmt)
        {
            // Resource the current player is giving
            switch (myResource){
                case resourceType.Lumber:
                    lumberCt -= myAmt;
                    recipient.lumberCt += myAmt;
                    g.playerUI_LumberCount.Text = Convert.ToString(LumberCount);
                    break;
                case resourceType.Grain:                    
                    grainCt -= myAmt;
                    recipient.grainCt += myAmt;
                    g.playerUI_GrainCount.Text = Convert.ToString(GrainCount);
                    break;
                case resourceType.Wool:                 
                    woolCt -= myAmt;
                    recipient.woolCt += myAmt;
                    g.playerUI_WoolCount.Text = Convert.ToString(WoolCount);
                    break;
                case resourceType.Ore:                    
                    oreCt -= myAmt;
                    recipient.oreCt += myAmt;
                    g.playerUI_OreCount.Text = Convert.ToString(OreCount);
                    break;
                case resourceType.Brick:
                    brickCt -= myAmt;
                    recipient.brickCt += myAmt;
                    g.playerUI_BrickCount.Text = Convert.ToString(BrickCount);
                    break;
            }
            // Resource the current player is receiving
            switch (theirResource)
            {
                case resourceType.Lumber:
                    lumberCt += theirAmt;
                    recipient.lumberCt -= theirAmt;
                    g.playerUI_LumberCount.Text = Convert.ToString(LumberCount);
                    break;
                case resourceType.Grain:
                    grainCt += theirAmt;
                    recipient.grainCt -= theirAmt;
                    g.playerUI_GrainCount.Text = Convert.ToString(GrainCount);
                    break;
                case resourceType.Wool:
                    woolCt += theirAmt;
                    recipient.woolCt -= theirAmt;
                    g.playerUI_WoolCount.Text = Convert.ToString(WoolCount);
                    break;
                case resourceType.Ore:
                    oreCt += theirAmt;
                    recipient.oreCt -= theirAmt;
                    g.playerUI_OreCount.Text = Convert.ToString(OreCount);
                    break;
                case resourceType.Brick:
                    brickCt += theirAmt;
                    recipient.brickCt -= theirAmt;
                    g.playerUI_BrickCount.Text = Convert.ToString(BrickCount);
                    break;
            }
            //recipient.ReceiveTrade(theirResource, theirAmt, myResource, myAmt);
        }

        public void StealResource(GameScreen g, Player p)
        {
            if (p.TotalResources < 1)
            {
                MessageBox.Show("The thief has returned empty handed!", "No resources to steal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Random RNG = new Random();
            bool stolen = false;
            resourceType resourceEnum = resourceType.Lumber;
            while (stolen == false)
            {
                resourceEnum = (resourceType)RNG.Next(5);
                switch (resourceEnum)
                {
                    case resourceType.Lumber:
                        if (p.LumberCount > 0)
                        {
                            lumberCt += 1;
                            p.lumberCt -= 1;
                            g.playerUI_LumberCount.Text = Convert.ToString(LumberCount);
                            stolen = true;                            
                        }
                        break;
                    case resourceType.Grain:
                        if (p.GrainCount > 0)
                        {
                            grainCt += 1;
                            p.grainCt -= 1;
                            g.playerUI_GrainCount.Text = Convert.ToString(GrainCount);
                            stolen = true;
                        }
                        break;
                    case resourceType.Wool:
                        if (p.WoolCount > 0)
                        {
                            woolCt += 1;
                            p.woolCt -= 1;
                            g.playerUI_WoolCount.Text = Convert.ToString(WoolCount);
                            stolen = true;
                        }
                        break;
                    case resourceType.Ore:
                        if (p.OreCount > 0)
                        {
                            oreCt += 1;
                            p.oreCt -= 1;
                            g.playerUI_OreCount.Text = Convert.ToString(OreCount);
                            stolen = true;
                        }
                        break;
                    case resourceType.Brick:
                        if (p.BrickCount > 0)
                        {
                            brickCt += 1;
                            p.brickCt -= 1;
                            g.playerUI_BrickCount.Text = Convert.ToString(BrickCount);
                            stolen = true;
                        }
                        break;
                }
            }
            MessageBox.Show(String.Format("You have stolen {0} from {1}", resourceEnum, p.Name),"Theft successful!",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
        }

        public void AddKnight()
        {
            knightCt += 1;
            if (KnightCount > largestArmyCt)
            {
                MessageBox.Show("Your army has surpassed all others.  Take two extra victory points", "Largest Army!",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                largestArmy = true;
                for (int i = 0; i < allPlayers.Count; i++)
                {
                    Player currentPlayer = (Player)allPlayers[i];
                    if (currentPlayer != this)
                    {
                        currentPlayer.largestArmy = false;
                    }                    
                }
                SetVictoryPoints();
                largestArmyCt = KnightCount;
            }
        }

        public void AddVPCard()
        {
            vpCardsPlayed += 1;
            SetVictoryPoints();
        }

        public static void ClearPlayerCount()
        {
            allPlayers = new ArrayList();
        }

        public static void ResetLargestArmy()
        {
            largestArmyCt = 2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using IntegrationTest1._1.Forms;

namespace IntegrationTest1._1
{
    public class Player
    {
        private string name;
        private Color colour;
        private int victoryPts = 0;
        private int knights = 0;
        private int lumberCt = 20, brickCt = 20, grainCt = 20, woolCt = 20, oreCt = 20; //Resources
        private int cityCt = 0, settlementCt = 0, roadCt = 0; //Buildings
        private bool longestRoad = false, largestArmy = false;
        public enum resourceType { Lumber, Grain, Wool, Ore, Brick}

        public Player(string nome, Color colore)
        {
            name = nome;
            colour = colore;
        }

        public Player(Player p)
        {
            name = p.Name;
            colour = p.Colour;
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

        public int Knights
        {
            get { return knights; }
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

        public void StartTurn(GameScreen g)
        {
            g.playerUI.Text = Name;
            g.playerUI_Info.Text = Name + " Information";
            g.playerUI_VPCount.Text = Convert.ToString(VictoryPoints);
            g.playerUI_KnightCount.Text = Convert.ToString(Knights);
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to place a road here?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                roadCt += 1;
                SetVictoryPoints();
                MessageBox.Show("Road placed!");
                g.playerUI_RoadCount.Text = Convert.ToString(RoadCount);
                g.playerUI_BuildRoad.Enabled = false;
                g.playerUI_EndTurn.Enabled = true;
            }
        }

        public void BuildSettlement(GameScreen g) //For testing purposes; not the real implementation
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

        public void BuildCity(GameScreen g) //For testing purposes; not the real implementation
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

        public void BuildRoad(GameScreen g) //For testing purposes; not the real implementation
        {
            // can only build a maximum of fifteen roads
            if (RoadCount == 15)
            {
                MessageBox.Show("You've reached the maximum number of roads(15)", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // costs 1 brick 1 lumber
            if (BrickCount >= 1 && LumberCount >= 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to place a road here?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
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
            } else
            {
                MessageBox.Show("Not enough resources!", "No", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetVictoryPoints()
        {
            int pts = 0;
            if (LongestRoad)
            {
                pts += 2;
            }
            if (LargestArmy)
            {
                pts += 2;
            }

            victoryPts = pts + SettlementCount + (2 * CityCount);
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
            int totalResources = BrickCount + GrainCount + LumberCount + OreCount + WoolCount;
            if (totalResources > 7)
            {
                int counter = 1;
                Random RNG = new Random();
                while (counter <= totalResources / 2)
                {
                    int resourceEnum = RNG.Next(5);
                    switch (resourceEnum)
                    {

                    }
                }
            }
        }
    }
}

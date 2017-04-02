using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using IntegrationTest1._1.Properties;

namespace IntegrationTest1._1
{
    class Board
    {
        // private const int NUMBER_OF_TILES = 19;
        public Hex[][] Hexes = new Hex[][] { new Hex[] {new Hex(), new Hex(), new Hex()},
        new Hex[] {new Hex(), new Hex(), new Hex(), new Hex()},
        new Hex[] {new Hex(), new Hex(), new Hex(), new Hex(), new Hex()},
        new Hex[] {new Hex(), new Hex(), new Hex(), new Hex()},
        new Hex[] {new Hex(), new Hex(), new Hex()},};
        private int[] tokenValues = new int[18];
        private static Random RNG = new Random();

        public Board()
        {
            InitializeTokens();
            ShuffleTokens();
            InitializeHexes();
            ShuffleHexes();
        }

        private void InitializeTokens()
        {
            for (int i = 0; i < tokenValues.Length; i++)
            {
                if (i == 0)
                {
                    tokenValues[i] = 2;
                }
                else if (i < 17)
                {
                    if (i % 8 == 1)
                    {
                        tokenValues[i] = 3;
                    }
                    if (i % 8 == 2)
                    {
                        tokenValues[i] = 4;
                    }
                    if (i % 8 == 3)
                    {
                        tokenValues[i] = 5;
                    }
                    if (i % 8 == 4)
                    {
                        tokenValues[i] = 6;
                    }
                    if (i % 8 == 5)
                    {
                        tokenValues[i] = 8;
                    }
                    if (i % 8 == 6)
                    {
                        tokenValues[i] = 9;
                    }
                    if (i % 8 == 7)
                    {
                        tokenValues[i] = 10;
                    }
                    if (i % 8 == 0)
                    {
                        tokenValues[i] = 11;
                    }
                }
                else
                {
                    tokenValues[i] = 12;
                }
            }
        }

        private void ShuffleTokens()
        {
            for (int first = 0; first < tokenValues.Length; first++)
            {
                int second = RNG.Next(tokenValues.Length);

                int temp = tokenValues[first];
                tokenValues[first] = tokenValues[second];
                tokenValues[second] = temp;
            }
        }

        private void InitializeHexes()
        {
            Hex.terrainType terra = Hex.terrainType.Desert;
            int num = 0;
            int k = 0;
            for (int i = 0; i <= Hexes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Hexes[i].GetUpperBound(0); j++)
                {
                    switch (i)
                    {
                        case 0:
                            terra = Hex.terrainType.Mountains;
                            break;
                        case 1:
                            terra = Hex.terrainType.Field;
                            break;
                        case 2:
                            if (i == 2 && j == 2)
                            {
                                terra = Hex.terrainType.Desert;
                            }
                            else
                            {
                                terra = Hex.terrainType.Forest;
                            }
                            break;
                        case 3:
                            terra = Hex.terrainType.Pasture;
                            break;
                        case 4:
                            terra = Hex.terrainType.Hills;
                            break;
                    }
                    if (i == 2 && j == 2)
                    {
                        num = 0;
                    }
                    else
                    {
                        num = tokenValues[k];
                        k++;
                    }
                    Hexes[i][j] = new Hex(terra, num);
                }
            }
        } // end void

        private void ShuffleHexes()
        {
            for (int i = 0; i <= Hexes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Hexes[i].GetUpperBound(0); j++)
                {
                    int altI = RNG.Next(Hexes.Length);
                    int altJ = RNG.Next(Hexes[i].Length);
                    Hex temp = Hexes[i][j];
                    try
                    {
                        Hexes[i][j] = Hexes[altI][altJ];
                        Hexes[altI][altJ] = temp;
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }

                }
            }
        }


        /*public void GetHex(Label lbl, int i, int j)
        {
            object O = Resources.ResourceManager.GetObject(Convert.ToString(Hexes[i][j].Terrain));
            Image image = (Image)O;

            lbl.Image = image;
            if (Hexes[i][j].Token > 0)
            {
                lbl.Text = Convert.ToString(Hexes[i][j].Token);
            }
            else
            {
                lbl.Text = "";
            }
        }*/

        public string GetHex(int i, int j)
        {
            return Convert.ToString(Hexes[i][j].Terrain) + ".jpg";
        }

        public string GetToken(int i, int j)
        {
            if (Hexes[i][j].Token > 0)
            {
                return Convert.ToString(Hexes[i][j].Token);
            }
            else
            {
                return "";
            }
        }
    }
}

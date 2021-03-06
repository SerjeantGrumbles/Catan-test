﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using IntegrationTest1._1.Properties;
using IntegrationTest1._1;

namespace IntegrationTest1._1
{
    public class Board
    {
        public Hex[][] Hexes = new Hex[][] { new Hex[] {null, null, null}, //3
        new Hex[] { null, null, null, null},    //4
        new Hex[] { null, null, null, null, null},  //5
        new Hex[] {null, null, null, null}, //4
        new Hex[] {null, null, null}};  //3
        public Node[][] Nodes = new Node[][] { new Node[] { null, null, null }, //3
        new Node[] { null, null, null, null }, new Node[] { null, null, null, null },   //4 ~ 4
        new Node[] { null, null, null, null, null }, new Node[] { null, null, null, null, null }, //5 ~ 5
        new Node[] { null, null, null, null, null, null }, new Node[] { null, null, null, null, null, null }, //6 ~ 6
        new Node[] { null, null, null, null, null }, new Node[] { null, null, null, null, null },   //5 ~ 5
        new Node[] { null, null, null, null }, new Node[] { null, null, null, null },   //4 ~ 4
        new Node[] { null, null, null}};    //3
        public Edge[][] Edges = new Edge[][] { new Edge[] { null, null, null, null, null, null }, //6
        new Edge[] { null, null, null, null},  //4
        new Edge[] { null, null, null, null, null, null, null, null },  //8
        new Edge[] { null, null, null, null, null },  //5
        new Edge[] { null, null, null, null, null, null, null, null, null, null },  //10
        new Edge[] { null, null, null, null, null, null },  //6
        new Edge[] { null, null, null, null, null, null, null, null, null, null },  //10
        new Edge[] { null, null, null, null, null },  //5
        new Edge[] { null, null, null, null, null, null, null, null },  //8
        new Edge[] { null, null, null, null },  //4
        new Edge[] { null, null, null, null, null, null }}; //6
        private int[] tokenValues = {10, 2, 9, 12, 6, 4, 10, 9, 11, 3, 8, 8, 3, 4, 5, 5, 6, 11 };
        private static Random RNG = new Random();
        private const float X_START_POINT = 225;
        private const float Y_START_POINT = 225;

        public Board()
        {
            // tokens should not have 6 or 8 values adjacent; until we can redesign the algorithm
            //ShuffleTokens();       to accomodate this, they should not be randomized
            InitializeHexes();
            ShuffleHexes();
            ArrangeHexes();
            InitializeNodes();
            InitializeEdges();
        }

        /* private void ShuffleTokens()
        {
            for (int first = 0; first < tokenValues.Length; first++)
            {
                int second = RNG.Next(tokenValues.Length);

                int temp = tokenValues[first];
                tokenValues[first] = tokenValues[second];
                tokenValues[second] = temp;
            }
        } */

        private void InitializeHexes()
        {
            Hex.terrainType terra = Hex.terrainType.Desert;
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
                    Hexes[i][j] = new Hex(terra);
                }
            }
        } // end void

        private void ShuffleHexes() // randomizes the order of the hexes
        {
            for (int i = 0; i <= Hexes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Hexes[i].GetUpperBound(0); j++)
                {
                    int altI = RNG.Next(Hexes.Length);
                    int altJ = RNG.Next(Hexes[altI].Length);
                    Hex temp = Hexes[i][j];
                        Hexes[i][j] = Hexes[altI][altJ];
                        Hexes[altI][altJ] = temp;
                }
            }
            //swap out one of the 8 tokens if Desert hex is in the last two rows
            for (int i = Hexes.Length / 2 + 1; i <= Hexes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Hexes[i].GetUpperBound(0); j++)
                {
                    if (Hexes[i][j].Terrain == Hex.terrainType.Desert)
                    {
                        int temp = tokenValues[10];
                        tokenValues[10] = tokenValues[2];
                        tokenValues[2] = temp;
                    }
                }
            }
        }

        private void ArrangeHexes() // assigns their position of the board; this must be done after shuffling
        {
            int num = 0;
            int k = 0;
            // midpoints of the hexagon
            float x_0 = X_START_POINT;
            float y_0 = Y_START_POINT;

            float width = (float)Math.Sqrt(3) * Hex.Radius;
            float totalWidth = 0; //accumulated width for each row of hexes
            for (int i = 0; i <= Hexes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Hexes[i].GetUpperBound(0); j++)
                {
                    // assign token values
                    if (Hexes[i][j].Terrain == Hex.terrainType.Desert)
                    {
                        num = 0;
                    }
                    else
                    {
                        num = tokenValues[k];
                        k++;
                    }
                    Hexes[i][j] = new Hex(Hexes[i][j], num, x_0, y_0);
                    x_0 += width;
                    totalWidth += width;
                }
                if (i < Hexes.Length / 2)
                {
                    x_0 -= (totalWidth + (0.5f * width));
                }
                else
                {
                    x_0 -= (totalWidth - (0.5f * width));
                }
                y_0 += (1.5f * Hex.Radius);
                totalWidth = 0;
            }
        }

        private void InitializeNodes()
        {
            // midpoints of the hexagon
            float x_0 = X_START_POINT - 5;
            float y_0 = Y_START_POINT - 5 - Hex.Radius;

            float width = (float)Math.Sqrt(3) * Hex.Radius;
            float totalWidth = 0; //accumulated width for each row of nodes
            for (int i = 0; i <= Nodes.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Nodes[i].GetUpperBound(0); j++)
                {
                    Nodes[i][j] = new Node(x_0, y_0);
                    x_0 += width;
                    totalWidth += width;
                }
                if (i < Nodes.Length / 2) // before halfway point
                {
                    if (i % 2 == 0) // even row
                    {
                        x_0 -= (totalWidth + (0.5f * width));
                        y_0 += (0.5f * Hex.Radius);
                    }
                    else // odd row
                    {
                        x_0 -= totalWidth;
                        y_0 += Hex.Radius;
                    }
                }
                else
                {
                    if (i % 2 == 0) // even row
                    {
                        x_0 -= (totalWidth - (0.5f * width));
                        y_0 += (0.5f * Hex.Radius);
                    }
                    else // odd row
                    {
                        x_0 -= totalWidth;
                        y_0 += Hex.Radius;
                    }
                }
                totalWidth = 0;
            }
        }

        private void InitializeEdges()
        {
            //starting point of lines
            PointF start = new PointF();
            start.X = X_START_POINT + Hex.Radius * (float)Math.Sin(4 * 60 * Math.PI / 180f);
            start.Y = Y_START_POINT + Hex.Radius * (float)Math.Cos(4 * 60 * Math.PI / 180f);

            float width = (float)Math.Sqrt(3) * Hex.Radius;
            float totalWidth = 0;

            for (int i = 0; i <= Edges.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= Edges[i].GetUpperBound(0); j++)
                {
                    PointF end = new PointF();
                    if (i % 2 == 0) //even row, diagonal line
                    {
                        end.X = start.X + width / 2;
                        totalWidth += width / 2;
                        if (i < Edges.Length /2) //before halfway point 
                        {
                            if (j % 2 == 0) //even column
                            {
                                end.Y = start.Y - Hex.Radius / 2;
                            }
                            else //odd column
                            {
                                end.Y = start.Y + Hex.Radius / 2;
                            }
                        }
                        else //after halfway point
                        {
                            if (j % 2 == 0) //even column
                            {
                                end.Y = start.Y + Hex.Radius / 2;
                            }
                            else //odd column
                            {
                                end.Y = start.Y - Hex.Radius / 2;
                            }
                        }
                        Edges[i][j] = new Edge(start, end);
                        start = end;
                    }
                    else //odd row, vertical line
                    {
                        totalWidth += width;
                        end.X = start.X;
                        end.Y = start.Y + Hex.Radius;
                        Edges[i][j] = new Edge(start, end);
                        start.X += width;
                    }
                }
                // Determining the start point for the next row
                if (i < Edges.Length / 2) // before halfway point
                {
                    if (i % 2 == 0) // even row
                    {
                        start.X -= totalWidth;
                    }
                    else // odd row
                    {
                        start.X -= totalWidth + width / 2;
                        start.Y += 3 * Hex.Radius / 2;
                    }
                }
                else
                {
                    if (i % 2 == 0) // even row
                    {
                        start.X -= totalWidth - width / 2;
                        start.Y += Hex.Radius / 2;
                    }
                    else // odd row
                    {
                        start.X -= totalWidth;
                        start.Y += Hex.Radius;
                    }
                }
                totalWidth = 0;
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

        /*public string GetHex(int i, int j)
        {
            return Convert.ToString(Hexes[i][j].Terrain) + ".jpg";
        } */

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

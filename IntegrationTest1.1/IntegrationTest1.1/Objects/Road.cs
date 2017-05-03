using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IntegrationTest1._1
{
    public class Road
    {
        private int playerNum;
        private Color colour;

        public Road(int num, Color colore)
        {
            playerNum = num;
            colour = colore;
        }

        public int PlayerNum
        {
            get { return playerNum; }
        }

        public Color Colour
        {
            get { return colour; }
        }
    }
}

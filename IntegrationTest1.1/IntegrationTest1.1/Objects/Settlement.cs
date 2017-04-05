using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IntegrationTest1._1.Forms
{
    class Settlement
    {
        private int playerNum;
        private Color colour;

        public Settlement(int num, Color colore)
        {
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

        public virtual int GetResource()
        {
            return 1;
        }
    }
}

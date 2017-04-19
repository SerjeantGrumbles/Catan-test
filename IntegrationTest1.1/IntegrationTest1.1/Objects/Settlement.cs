using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IntegrationTest1._1.Properties;

namespace IntegrationTest1._1
{
    public class Settlement
    {
        protected int playerNum;
        protected Color colour;

        public Settlement()
        {

        }

        public Settlement(int num, Color colore)
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

        public virtual int ResourceYield
        {
            get { return 1; }
        }

        public virtual Image Image
        {
            get
            {
                string strColour = Colour.ToString();
                strColour = strColour.Substring(7, strColour.Length - 8);
                Object O = Resources.ResourceManager.GetObject(strColour + "Settlement");
                Image image = (Image)O;
                return image;
            }
        }
    }
}

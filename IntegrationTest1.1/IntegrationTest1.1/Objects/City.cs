using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IntegrationTest1._1.Properties;

namespace IntegrationTest1._1
{
    class City : Settlement
    {
        public City (Settlement s)
        {
            playerNum = s.PlayerNum;
            colour = s.Colour;
        }

        public override int ResourceYield()
        {
            return 2;
        }

        public override Image Image
        {
            get
            {
                string strColour = Colour.ToString();
                strColour = strColour.Substring(7, strColour.Length - 8);
                Object O = Resources.ResourceManager.GetObject(strColour + "City");
                Image image = (Image)O;
                return image;
            }
        }
    }
}

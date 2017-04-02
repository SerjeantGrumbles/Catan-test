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
    class Dice
    {
        private int die1 = 1;
        private int die2 = 1;
        private static Random RNG = new Random();

        public void Roll()
        {
            die1 = RNG.Next(1, 7);
            die2 = RNG.Next(1, 7);
        }

        public void DisplayDice(PictureBox pic1, PictureBox pic2)
        {
            Object resource1 = Resources.ResourceManager.GetObject(String.Format("dice_{0}", die1));
            Object resource2 = Resources.ResourceManager.GetObject(String.Format("dice_{0}", die2));
            pic1.Image = (Image)resource1;
            pic2.Image = (Image)resource2;
        }

        public int DiceTotal
        {
            get
            {
                return die1 + die2;
            }
        }
    }
}

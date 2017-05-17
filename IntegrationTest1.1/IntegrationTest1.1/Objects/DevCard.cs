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
    public abstract class DevCard
    {
        public virtual Image Image
        {
            get { return null; }
        }

        public abstract void Play(GameScreen g, Player p);
    }

    public class KnightCard : DevCard
    {
        public KnightCard() { }

        public override Image Image
        {
            get { return Resources.Knight; }
        }

        public override string ToString()
        {
            return "Knight Card";
        }

        public override void Play(GameScreen g, Player p)
        {
            MessageBox.Show("Knight Card played!", "Development Card");
            p.AddKnight();
            g.playerUI_KnightCount.Text = Convert.ToString(p.KnightCount);
            if (p.LargestArmy)
            {
                g.picLargestArmy.Image = Resources.largestArmy;
                g.playerUI_VPCount.Text = Convert.ToString(p.VictoryPoints);
            }
            else
            {
                g.picLargestArmy.Image = null;
            }
            g.ActivateThief();
        }
    }

    public class VPCard : DevCard
    {
        public enum VPCardType { Chapel, Library, Market, Palace, University}
        private VPCardType cardType;

        public VPCard(VPCardType type)
        {
            cardType = type;
        }

        public VPCardType CardType
        {
            get { return cardType; }
        }

        public override Image Image
        {
            get
            {
                object O = Resources.ResourceManager.GetObject(Convert.ToString(CardType));
                Image image = (Image)O;
                return image;
            }
        }

        public override string ToString()
        {
            return "Victory Point Card: " + Convert.ToString(CardType);
        }

        public override void Play(GameScreen g, Player p)
        {
            MessageBox.Show("Victory Card played!", "Development Card");
            p.AddVPCard();
            g.playerUI_VPCount.Text = Convert.ToString(p.VictoryPoints);
        }
    }

    public class MonopolyCard : DevCard
    {
        public MonopolyCard() { }

        public override Image Image
        {
            get { return Resources.Monopoly; }
        }

        public override string ToString()
        {
            return "Monopoly Card";
        }

        public override void Play(GameScreen g, Player p)
        {
            MessageBox.Show("Monopoly Card played!", "Development Card");
        }
    }

    public class RoadBuildCard : DevCard
    {
        public RoadBuildCard() { }

        public override Image Image
        {
            get { return Resources.Roadbuild; }
        }

        public override string ToString()
        {
            return "Road Building Card";
        }

        public override void Play(GameScreen g, Player p)
        {
            MessageBox.Show("Road Building Card played!", "Development Card");
        }
    }

    public class YearPlentyCard : DevCard
    {
        public YearPlentyCard() { }

        public override Image Image
        {
            get { return Resources.Year; }
        }

        public override string ToString()
        {
            return "Year of Plenty Card";
        }

        public override void Play(GameScreen g, Player p)
        {
            MessageBox.Show("Year of Plenty Card played!", "Development Card");
        }
    }
}

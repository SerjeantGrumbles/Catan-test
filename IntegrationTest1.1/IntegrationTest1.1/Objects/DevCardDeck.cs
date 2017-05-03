using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegrationTest1._1
{
    public class DevCardDeck
    {
        private const int NUMBER_OF_CARDS = 25;
        private DevCard[] deck = new DevCard[NUMBER_OF_CARDS];
        private int currentCard;
        private static Random RNG = new Random();

        public DevCardDeck()
        {
            for (int i = 0; i <= deck.GetUpperBound(0); i++)
            {
                if (i < 14) // 14 Knight Cards
                {
                    deck[i] = new KnightCard();
                }
                else if (i < 19) // 5 Victory Point Cards
                {
                    deck[i] = new VPCard((VPCard.VPCardType)(i % 5));
                }
                else if (i < 21)    // 2 Road Building Cards
                {
                    deck[i] = new RoadBuildCard();
                }
                else if (i < 23)    // 2 Monopoly Cards
                {
                    deck[i] = new MonopolyCard();
                }
                else    // 2 Year of Plenty Cards
                {
                    deck[i] = new YearPlentyCard();
                }
            }
            Shuffle();
        }

        private void Shuffle()
        {
            currentCard = 0;

            for (int first = 0; first <= deck.GetUpperBound(0); first++)
            {
                // select a random number between 0 and 24
                int second = RNG.Next(NUMBER_OF_CARDS);

                // swap current Card with randomly selected Card
                DevCard temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public void DealCard(GameScreen g, Player p)
        {
            if (currentCard <= deck.GetUpperBound(0))
            {
                p.DevCards.Add(deck[currentCard]);
                p.BuyDevCard();
                MessageBox.Show("Card Drawn: " + deck[currentCard].ToString(), "Development Card Purchased");
                g.playerUI_WoolCount.Text = Convert.ToString(p.WoolCount);
                g.playerUI_OreCount.Text = Convert.ToString(p.OreCount);
                g.playerUI_GrainCount.Text = Convert.ToString(p.GrainCount);
                currentCard += 1;
            }
            else
            {
                MessageBox.Show("The end of the deck has been reached!", "86 Development Cards", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Evaluator
{
    class DeckofCards : Card
    {
        const int TotalCards = 52;
        private Card[] Deck;

        public DeckofCards()
        {
            Deck = new Card[TotalCards];
            Deck = SetupDeck(Deck);
            Deck = ShuffleDeck(Deck);
        }
        public Card[] getDeck { get{ return Deck; } }

        public static Card[] SetupDeck(Card[] cards)
        {
            int i = 0; 
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    cards[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }
            return cards;
        }
        public static Card[] ShuffleDeck(Card[] cards)
        {
            Random rand = new Random();
            Card temp;

            for(int shufflecount = 0;shufflecount<1000; shufflecount++)
            {
                for(int i = 0; i < TotalCards; i++)
                {
                    int secondCardIndex = rand.Next(13);
                    temp = cards[i];
                    cards[i] = cards[secondCardIndex];
                    cards[secondCardIndex] = temp;
                }
            }

            return cards;
        }
    }
}

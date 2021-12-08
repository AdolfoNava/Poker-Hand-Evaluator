using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Evaluator
{
    class DealCards
    {
        private Card[] Deck;
        private Card[] Player1Hand;
        private Card[] Player2Hand;
        public int Players;
        public DealCards()
        {
            Player1Hand = new Card[5];
            Player2Hand = new Card[5];
            Deck = new Card[52];
        }
        public void Deal()
        {
            DeckofCards.SetupDeck(Deck);
            DeckofCards.ShuffleDeck(Deck);
            Player1Hand=GetHand(Player1Hand, 0);
            Player2Hand=GetHand(Player2Hand, 5);
            SortCards(Player1Hand);
            SortCards(Player2Hand);
            DisplayCardForGame();
            EvaluateHands();
        }

        private Card[] GetHand(Card[] PlayerHand, int value)
        {
            for(int i = 0; i < 5; i++)
            {
                PlayerHand[i] = Deck[i+value];
            }
            return PlayerHand;
        }  
        
        private Card[] SortCards(Card[] HandToSorted)
        {
            var QueryHand = from hand in HandToSorted orderby hand.MyValue select hand;
            var index = 0;
            foreach(var element in QueryHand.ToList())
            {
                HandToSorted[index] = element;
                index++;
            }
            return HandToSorted;
        }        
        public void DisplayCardForGame()
        {
            Console.Clear();
            int x = 0;
            int y = 1;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Player 1's Hand");
            for(int i = 0; i < Player1Hand.Length; i++)
            {
                DisplayCards.DrawCardOutLine(x, y);
                DisplayCards.DrawCardSuitValue(Player1Hand[i], x, y);
                x++;

                
            }
            x = 0;
            y = 15;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player 2's Hand");
            y++;
            for(int i = 0; i < Player2Hand.Length; i++)
            {
                DisplayCards.DrawCardOutLine(x, y);
                DisplayCards.DrawCardSuitValue(Player2Hand[i], x, y);
                x++;

            }
        }
        private void EvaluateHands()
        {
            HandEvaluator Player1Evaluator = new HandEvaluator(Player1Hand);
            HandEvaluator Player2Evaluator = new HandEvaluator(Player2Hand);

            Hand player1Hand = Player1Evaluator.EvaluateHand();
            Hand player2Hand = Player2Evaluator.EvaluateHand();

            Console.WriteLine($"\n\n\n\n\nPlayer 1's Hand: {player1Hand}");
            Console.WriteLine($"\nPlayer 2's Hand: {player2Hand}" );

            if (player1Hand > player2Hand)
            {
                Console.WriteLine("Player 1 Wins!");
            }
            else if (player1Hand < player2Hand)
            {
                Console.WriteLine("Player 2 Wins!");
            }
            else
            {
                if (Player1Evaluator.HandValues.Total > Player2Evaluator.HandValues.Total) 
                {
                    Console.WriteLine("Player 1 Wins!");
                }
                else if (Player1Evaluator.HandValues.Total < Player2Evaluator.HandValues.Total)
                {
                    Console.WriteLine("Player 1 Wins!");
                }
                else if (Player1Evaluator.HandValues.HighCard > Player2Evaluator.HandValues.HighCard)
                {
                    Console.WriteLine("Player 1 Wins!");
                }
                else if (Player1Evaluator.HandValues.HighCard < Player2Evaluator.HandValues.HighCard)
                {
                    Console.WriteLine("Player 2 Wins!");
                }
                else
                {
                    Console.WriteLine("DRAW no winners.");
                }
            }
        }
    }
}

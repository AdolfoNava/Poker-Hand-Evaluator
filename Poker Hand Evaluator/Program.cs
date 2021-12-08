using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Evaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Poker Game";
            //DisplayCards.DrawCardOutLine(0, 0);
            //Card card = new Card();
            //card.MySuit = Card.SUIT.Spades;
            //card.MyValue = Card.VALUE.Ace;
            //DisplayCards.DrawCardSuitValue(card, 0, 0);
            Console.SetWindowSize(65, 40);
            //Console.BufferHeight = 65;
            //Console.BufferWidth = 40; 
            //Console.ReadKey(true);
            DealCards dealCards = new DealCards();
            bool quit = false;
            while (!quit)
            {
                dealCards.Deal();

                char selection = ' ';
                while (!selection.Equals('Y')&& !selection.Equals('N'))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 33);
                    Console.WriteLine("Play Again? type Y or N");
                    try {
                    
                        selection = Convert.ToChar(Console.ReadLine().ToUpper());
                     }
                    catch {
                        selection = ' ';
                    }
                    //Console.ReadKey(true);
                    if (selection.Equals('Y'))
                    {
                        quit = false;
                    }else if (selection.Equals('N'))
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection. Try it again");
                    }
                }
            }

        }
    }
}

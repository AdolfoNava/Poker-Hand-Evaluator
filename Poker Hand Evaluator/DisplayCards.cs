using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Evaluator
{
    class DisplayCards
    {
        public static void DrawCardOutLine(int xcoor,int ycoor)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int x = xcoor * 12;
            int y = ycoor;

            Console.SetCursorPosition(x, y);
            Console.Write(" ____________\n");
            for(int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                if(i != 9)
                {
                    Console.WriteLine("|            |");
                }
                else
                    Console.WriteLine("|____________|");
            }
        }
        public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
        {
            char cardSuit = ' ';
            int x = xcoor * 12;
            int y = ycoor;

            switch (card.MySuit)
            {
                case Card.SUIT.Hearts:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.Spades:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Card.SUIT.Diamonds:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 5 })[0];
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.Clubs:
                    cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(x+5, y+5);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.MyValue);
        }
    }
}

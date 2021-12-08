using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Evaluator
{
    public enum Hand
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        StriaghtRoyalFlush
    }
    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }
    class HandEvaluator : Card
    {
        private  int heartsSum;
        private int diamondsSum;
        private int clubsSum;
        private int spadesSum;

        private Card[] cards;
        private HandValue handValue;
        public HandEvaluator(Card[] sortedHand)
        {
            heartsSum    = 0;
            diamondsSum  = 0;
            clubsSum     = 0;
            spadesSum    = 0;
            cards = sortedHand;
            handValue = new HandValue();
        }
        public HandValue HandValues
        {
            get { return handValue; }
                set { handValue = value; }
        }
        public Card[] Cards
        {
            get { return cards; }
            set { 
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }
        public Hand EvaluateHand()
        {
            getNumberOfSuit();
            if (StrightRoyalFlush())
                return Hand.StriaghtRoyalFlush;

            else if (StrightFlush())
                return Hand.StraightFlush;

            else if (FourOfAKind())
                return Hand.FourOfAKind;

            else if (FullHouse())
                return Hand.FullHouse;

            else if (Flush())
                return Hand.Flush;

            else if (Striaght())
                return Hand.Straight;

            else if (ThreeOfAKind())
                return Hand.ThreeOfAKind;

            else if (TwoPair())
                return Hand.TwoPairs;

            else if (OnePair())
                return Hand.OnePair;

            handValue.HighCard = (int)cards[4].MyValue;
            return Hand.HighCard;
        }
        private void getNumberOfSuit()
        {
            foreach(var element in cards)
            {
                switch (element.MySuit)
                {
                    case Card.SUIT.Hearts:
                        heartsSum++;
                        break;
                    case Card.SUIT.Diamonds:
                        diamondsSum++;
                        break;
                    case Card.SUIT.Clubs:
                        clubsSum++;
                        break;
                    case Card.SUIT.Spades:
                        spadesSum++;
                        break;
                    default:
                        break;
                }

            }
        }
        private bool StrightRoyalFlush()
        {
            if( ( spadesSum==5 || heartsSum == 5 || diamondsSum == 5 || clubsSum == 5) &&(cards[0].MyValue == VALUE.Ten)&&cards[4].MyValue == VALUE.Ace)
            {
                return true;
            }
            return false;
        }
        private bool StrightFlush()
        {
            handValue.Total = (int)cards[4].MyValue;
            return false;
        }
        private bool FourOfAKind()
        {
            if (cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[0].MyValue == cards[3].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }else if(cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue && cards[1].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[1].MyValue * 4;
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;
        }
        private bool FullHouse() 
        { 
            // 1 2 3 are a 3 of a kind and the 4 5 cards are a single pair or
            // 3 4 5 are a 3 of a kind and the 1 2 cards are a single pair
            if (cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue||//card 1 2 3 have the 3 of a kind with 4 and 5 having a different higher value pair
                cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue && cards[2].MyValue == cards[4].MyValue)// 1 and 2 have the same value pair with 3 4 5 having the higher different 3 of a kind
            {
                handValue.Total = 
                    (int)cards[0].MyValue + 
                    (int)cards[1].MyValue + 
                    (int)cards[2].MyValue + 
                    (int)cards[3].MyValue + 
                    (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool Flush()
        {
            if (heartsSum == 5 || diamondsSum == 5 || clubsSum == 5 || spadesSum == 5)
            {
                handValue.Total=(int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool Striaght()
        {
            if(cards[0].MyValue + 1 == cards[1].MyValue &&
               cards[1].MyValue + 1 == cards[2].MyValue &&
               cards[2].MyValue + 1 == cards[3].MyValue &&
               cards[3].MyValue + 1 == cards[4].MyValue)
            {
                handValue.Total = (int)cards[4].MyValue;
                return true;
            }
            return false;
        }
        private bool ThreeOfAKind()
        { //For if the 1 2 3 cards have the same number value
            if((cards[0].MyValue == cards[1].MyValue && cards[0].MyValue == cards[2].MyValue) ||
                (cards[1].MyValue == cards[2].MyValue && cards[1].MyValue == cards[3].MyValue))
            {
                handValue.Total = (int)cards[2].MyValue * 3;
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }else 
            //For if the 3 4 5 cards have the same number value
            if (cards[2].MyValue == cards[4].MyValue && cards[2].MyValue == cards[4].MyValue)
            {
                handValue.Total = (int)cards[2].MyValue*3;
                handValue.HighCard = (int)cards[1].MyValue;
                return true;
            }
            return false;
        }
        private bool TwoPair()
        {
            // 1, 2 and 3, 4
            // 1, 2 and 4, 5
            // 2, 3 and 4, 5
            if(cards[0].MyValue == cards[1].MyValue && cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[0].MyValue == cards[1].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue && cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2) + ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[0].MyValue;
                return true;
            }
            return false;
        }
        private bool OnePair()
        {
            if (cards[0].MyValue == cards[1].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2);
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[1].MyValue == cards[2].MyValue)
            {
                handValue.Total = ((int)cards[1].MyValue * 2);
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[2].MyValue == cards[3].MyValue)
            {
                handValue.Total = ((int)cards[3].MyValue * 2);
                handValue.HighCard = (int)cards[4].MyValue;
                return true;
            }
            else if (cards[3].MyValue == cards[4].MyValue)
            {
                handValue.Total = ((int)cards[4].MyValue * 2);
                handValue.HighCard = (int)cards[2].MyValue;
                return true;
            }
            return false;
        }
    }
}

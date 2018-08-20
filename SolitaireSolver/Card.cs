using System;
namespace SolitaireSolver
{
    public class Card
    {
        readonly Suit _suit;
        readonly Rank _rank;

        public Suit Suit {
            get => _suit;
        }

        public Rank Rank {
            get => _rank;
        }

        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }

        public override string ToString()
        {
            var rankStr = "";
            switch (Rank)
            {
                case Rank.Ace:
                    rankStr = "A";
                    break;
                case Rank.Jack:
                    rankStr = "J";
                    break;
                case Rank.Queen:
                    rankStr = "Q";
                    break;
                case Rank.King:
                    rankStr = "K";
                    break;
                default:
                    rankStr = ((int)Rank).ToString();
                    break;
            }
            var suitStr = "";
            switch (Suit)
            {
                case Suit.Spades:
                    suitStr = "♠";
                    break;
                case Suit.Hearts:
                    suitStr = "♥";
                    break;
                case Suit.Clubs:
                    suitStr = "♣";
                    break;
                case Suit.Diamonds:
                    suitStr = "♦";
                    break;
                default:
                    suitStr = Suit.ToString();
                    break;
            }
            return rankStr + suitStr;
        }
    }
}

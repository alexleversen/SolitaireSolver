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

        public Card(string cardString)
        {
            switch(cardString[0])
            {
                case 'A':
                    _rank = Rank.Ace;
                    break;
                case 'J':
                    _rank = Rank.Jack;
                    break;
                case 'Q':
                    _rank = Rank.Queen;
                    break;
                case 'K':
                    _rank = Rank.King;
                    break;
                default:
                    _rank = (Rank)(int.Parse(cardString[0].ToString()));
                    break;
            }
            switch(cardString[1])
            {
                case '♠':
                    _suit = Suit.Spades;
                    break;
                case '♥':
                    _suit = Suit.Hearts;
                    break;
                case '♣':
                    _suit = Suit.Clubs;
                    break;
                case '♦':
                    _suit = Suit.Diamonds;
                    break;
            }
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

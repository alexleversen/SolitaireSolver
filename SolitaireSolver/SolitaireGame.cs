using System.Collections.Generic;
using System.Text;

namespace SolitaireSolver
{
    public class SolitaireGame
    {
        public List<List<Card>> MainRows {
            get;
            private set;
        }

        public List<List<Card>> UpperRows {
            get;
            private set;
        }

        public List<Card> DrawPile {
            get;
            private set;
        }

        public SolitaireGame(Deck deck)
        {
            MainRows = new List<List<Card>>();
            for (var i = 0; i < 7; i++)
            {
                MainRows.Add(new List<Card>());
                for (var j = 0; j <= i; j++)
                {
                    MainRows[i].Add(deck.DealCard());
                }
            }
            UpperRows = new List<List<Card>>();
            for (var i = 0; i < 4; i++)
            {
                UpperRows.Add(new List<Card>());
            }
            DrawPile = new List<Card>(deck);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var row in UpperRows)
            {
                if(row.Count > 0)
                {
                    sb.Append(row[row.Count - 1].ToString());
                }
                else
                {
                    sb.Append("__");
                }
                sb.Append("\t");
            }
            sb.Append("\t");
            if(DrawPile.Count > 0)
            {
                sb.Append(DrawPile[0]);
            }
            if (DrawPile.Count > 1)
            {
                sb.Append("\t|_|");
            }
            sb.Append("\n");
            var j = 0;
            while (true)
            {
                var cardsLeft = false;
                for (var i = 0; i < 7; i++)
                {
                    if(j < MainRows[i].Count)
                    {
                        cardsLeft = true;
                        if (j == MainRows[i].Count - 1)
                        {
                            sb.Append(MainRows[i][j].ToString());
                        }
                        else
                        {
                            sb.Append("|_|");
                        }
                    }
                    else
                    {
                        sb.Append("  ");
                    }
                    sb.Append("\t");
                }
                if(cardsLeft)
                {
                    sb.Append("\n");
                }
                else
                {
                    break;
                }
                j++;
            }
            return sb.ToString();
        }
    }
}

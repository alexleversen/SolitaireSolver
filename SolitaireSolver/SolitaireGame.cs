using System;
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

        Stack<GameState> _gameStateStack;

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

        public Stack<GameState> Solve()
        {
            _gameStateStack.Push(new GameState(MainRows, UpperRows, DrawPile, 0, _gameStateStack));
            while(!_gameStateStack.Peek().IsWinningState())
            {
                
            }
            return _gameStateStack;
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

        public class GameState : IComparable<GameState>
        {
            public string MainRowsString 
            {
                get;
                private set;
            }
            public string UpperRowsString
            {
                get;
                private set;
            }
            public string DrawPileString
            {
                get;
                private set;
            }
            public int MoveIndex
            {
                get;
                private set;
            }
            Stack<GameState> PreviousStates;


            public GameState(List<List<Card>> mainRows, List<List<Card>> upperRows, List<Card> drawPile, int moveIndex, Stack<GameState> previousStates)
            {
                MainRowsString = ConvertRowsToString(mainRows);
                UpperRowsString = ConvertRowsToString(upperRows);
                DrawPileString = ConvertCardsToString(drawPile);
                MoveIndex = moveIndex;
                PreviousStates = previousStates;
            }

            public bool IsWinningState()
            {
                return MainRowsString.Equals("{[];[];[];[];[];[];[];}")
                                     && UpperRowsString.Equals("{[];[];[];[];}");
            }

            public int TryMove()
            {
                for (var i = MoveIndex; i < 12; i++)
                {
                    if (CanMove(i, out int moveLoc))
                    {
                        MoveIndex = i;
                        return moveLoc;
                    }
                }
                return -1;
            }

            bool CanMove(int index, out int moveLocation)
            {
                Card cardToMove = null;
                if(index >=0 && index < 7)
                {
                    cardToMove = CardAtTop(MainRowsString, index);
                }
                else if(index >= 7 && index < 11)
                {
                    cardToMove = CardAtTop(UpperRowsString, index - 7);
                }
                else
                {
                    cardToMove = CardAtTop(DrawPileString);
                }
                //TODO: apply rule to each other card not at the current index to see if the current card can be placed there. Define CanPlace method?
            }

            Card CardAtTop(string cardList, int row = -1)
            {
                var splitList = new string[0];
                if (row == -1)
                {
                    splitList = cardList.Split(',');
                }
                else
                {
                    splitList = cardList.Split(';')[row].Split(',');
                }
                if(splitList.Length == 1)
                {
                    return null;
                }
                return new Card(splitList[0].Substring(1));
            }

            string ConvertRowsToString(List<List<Card>> rows)
            {
                var sb = new StringBuilder();
                sb.Append("{");
                foreach(var row in rows)
                {
                    sb.Append("[");
                    foreach(var card in row)
                    {
                        sb.Append(card.ToString());
                        sb.Append(",");
                    }
                    sb.Append("];");
                }
                sb.Append("}");
                return sb.ToString();
            }

            string ConvertCardsToString(List<Card> cards)
            {
                var sb = new StringBuilder();
                sb.Append("[");
                foreach(var card in cards)
                {
                    sb.Append(card.ToString());
                    sb.Append(",");
                }
                sb.Append("]");
                return sb.ToString();
            }

            public int CompareTo(GameState other)
            {
                return MainRowsString.Equals(other.MainRowsString)
                                     && UpperRowsString.Equals(other.UpperRowsString)
                                     && DrawPileString.Equals(other.DrawPileString) ?
                                     0 : -1;
            }
        }
    }
}

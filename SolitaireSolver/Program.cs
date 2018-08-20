using System;

namespace SolitaireSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();
            var game = new SolitaireGame(deck);
            Console.WriteLine(game);
        }
    }
}

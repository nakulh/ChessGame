using System;
using Chess.Implementations;
using Chess.Models;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantToPlay = "Y";
            while (wantToPlay.Equals("Y"))
            {
                GameManager game = new GameManager(5, 5, new ConsoleInteractor());
                wantToPlay = game.beginNewGame();
            }
            
        }
    }
}

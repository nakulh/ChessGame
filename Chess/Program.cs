using System;
using Chess.Implementations;
using Chess.Models;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GameManager game = new GameManager(5, 5, new ConsoleInteractor());
            game.beginNewGame();
        }
    }
}

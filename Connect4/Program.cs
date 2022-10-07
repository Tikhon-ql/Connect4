using Connect4.Models;
using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Game game = Game.GetInstance();
            game.Run();
            Console.ReadKey();
        }
    }
}

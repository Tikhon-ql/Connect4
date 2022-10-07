using Connect4Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class Player : IPlayer
    {
        public string Id { get; set; }
        public Chip PlayerChip { get; set; } = new Chip();
        public string Nickname { get; set; }
        public int Number { get; set; }
        public static int addedPlayersCount;

        public Player()
        {
            
        }
        public Player(string id, string nickname, int number)
        {
            Id = id;
            Nickname = nickname;
            Number = number;
        }

        public int MakeStepChip(object sender, EventArgs args)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 2);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            int i = 0;
            do
            {
                key = Console.ReadKey();
                switch (key.Key) 
                {
                    case ConsoleKey.RightArrow:
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                            i++;
                            //Console.Beep(350, 200);
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop);
                            i--;
                            //Console.Beep(350, 200);
                            break;
                        }
                    default: { break; }
                }

            } 
            while (key.Key != ConsoleKey.Enter);

            return i;
        }

    }
}

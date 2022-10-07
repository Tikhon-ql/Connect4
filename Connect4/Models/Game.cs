using Connect4Library.Interfaces;
using Connect4Library.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class Game : IGame
    {
        private Chip[,] gameArea = new Chip[6, 7];  
        //private List<Player> players = new List<Player>();

        private IWinEngine<string> winEngine = new WinEngine();

        private List<int> lastPicks = new List<int>() { 0,0,0,0,0,0,0 };

        private Pair<int> lastPick = new Pair<int>();
        //private Player winPlayer = new Player();

        private static Game instance;

        public IEnumerable<IPlayer> Players { get; set; } = new List<Player>();

        private Game()
        {
            for (int i = 0; i < gameArea.GetLength(0); i++)
            {
                for (int j = 0; j < gameArea.GetLength(1); j++)
                {
                    gameArea[i, j] = new Chip();
                }
            }
        }
        public static Game GetInstance()
        {
            if (instance == null)
                instance = new Game();
            return instance;
        }
        public void Run()
        {
            Customization();
            Authenticate();
            Console.Clear();
            ShowGameArea();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 0);
            while (true)
            {
                for(int i = 0; i < Players.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}, ваш ход!");
                    Player player = (Player)Players.FirstOrDefault(p => ((Player)p).Number == i);
                    int index = player.MakeStepChip(this,EventArgs.Empty);
                    
                    gameArea[gameArea.GetLength(0) - lastPicks[index] - 1, index].Value = player.PlayerChip.Value;
                    lastPicks[index]++;
                    lastPick.First = gameArea.GetLength(0) - lastPicks[index];
                    lastPick.Second = index;
                    //thread.Start();

                    ShowGameArea();
                    if (winEngine.IsWin(gameArea,lastPick))
                    {
                        //Console.Beep(100, 1000);
                        Win(player);
                        return;
                    }
                }
            }
        }
        private void Authenticate()
        {
            string response = "";
            while (true)
            {
                Console.WriteLine($"Введите имя {Player.addedPlayersCount + 1} игрока: ");
                response = Console.ReadLine();
                if (response == "start" && Player.addedPlayersCount > 1)
                    break;
                Player player = new Player(Guid.NewGuid().ToString(), response, Player.addedPlayersCount);
                player.PlayerChip.Value = (Player.addedPlayersCount + 1).ToString();
                ((List<Player>)Players).Add(player);
                Player.addedPlayersCount++;
            }
        }
        private void Customization()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
        }
        public void ShowGameArea()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 3);

            Console.WriteLine("_____________________________");
            
            for (int i = 0; i < gameArea.GetLength(0); i++)
            {             
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 4 + i);
                string str = "|";
                for (int j = 0; j < gameArea.GetLength(1); j++)
                {
                    str += " "+ gameArea[i, j].Value + " |";
                }
                Console.WriteLine(str);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 5 + i);
            }
          
            Console.WriteLine("_____________________________");
        }
       public void Win(Player player)
        {
            Console.WriteLine(player.Nickname + " win!!!");
        }
    }
}

using Connect4Library.DAL.Interfaces.IWinnerRepositories;
using Connect4Library.DAL.Models;
using Connect4Library.DAL.Repositories;
using Connect4Library.Interfaces;
using Connect4Library.Support;
using Connect4WUI.Configuration;
using Connect4WUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Connect4WUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IGame
    {
        public List<Rectangle> choices = new List<Rectangle>();
        private List<int> lastPicks = new List<int>();

        public int currentChoice = 0;
        private int currentPlayer = 0;

        public IChip<Ellipse>[,] GameArea { get; set; } = new IChip<Ellipse>[6, 7];

        public SolidColorBrush indianRedColorToReplace = new SolidColorBrush(Colors.IndianRed);
        public SolidColorBrush whiteColorToReplace = new SolidColorBrush(Colors.White);

        public bool IsRun = false;

        public IEnumerable<IPlayer> Players { get; set; } = new List<Player>();

        public IWinnerRepository repository;
        public IWinEngine<Ellipse> winEngine;

        public MainWindow()
        {
            InitializeComponent();
            Configure();
            Populate();
            ShowGameArea();
        }

        public void Run()
        {
            IsRun = true;
        }

        private void Populate()
        {
            choices.Add(rect0);
            choices.Add(rect1);
            choices.Add(rect2);
            choices.Add(rect3);
            choices.Add(rect4);
            choices.Add(rect5);
            choices.Add(rect6);
            for (int i = 0; i < GameArea.GetLength(0); i++)
            {
                for (int j = 0; j < GameArea.GetLength(1); j++)
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = 30;
                    ellipse.Height = 30;
                    ellipse.Fill = indianRedColorToReplace;
                    GameArea[i, j] = new Chip();
                    GameArea[i, j].Value = ellipse;
                }
            }

            for (int i = 0; i < 7; i++)
            {
                lastPicks.Add(GameArea.GetLength(0) - 1);
            }

            for (int i = 0; i < gameAreaGrid.RowDefinitions.Count() - 1; i++)
            {
                for (int j = 0; j < gameAreaGrid.ColumnDefinitions.Count(); j++)
                {
                    gameAreaGrid.Children.Add(GameArea[i, j].Value);
                }
            }
        }

        private void Configure()
        {
            IServiceCollection services = new ServiceCollection();
            Startup.Configure(services);
            ServiceProvider provider = services.BuildServiceProvider();
            repository = provider.GetService<IWinnerRepository>();
            winEngine = provider.GetService<IWinEngine<Ellipse>>();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsRun && Players.Count() > 0)
            {
                int d = ((List<Player>)Players)[currentPlayer].MakeStepChip(this, e);
                if (d == 1 && lastPicks[currentChoice] >= 0)
                {
                    Player current = ((List<Player>)Players)[currentPlayer];
                    GameArea[lastPicks[currentChoice], currentChoice].Value.Fill = current.playersChip.Value.Fill;
                    lastPicks[currentChoice]--;
                    currentPlayer++;
                    currentPlayer %= Players.Count();
                    ShowGameArea();
                    if (winEngine.IsWin(GameArea, new Pair<int> { First = lastPicks[currentChoice] + 1, Second = currentChoice }))
                    {
                        MessageBox.Show($"{current.Nickname} won!!!");
                        Refresh();
                        ShowGameArea();
                        ///Pretty chit code
                        repository.Create(new Winner(current.Id, current.Nickname,true));
                        foreach(var item in Players)
                        {
                            repository.Create(new Winner(item.Id, item.Nickname, false));
                        }
                    }
                    choices[currentChoice].Fill = indianRedColorToReplace;
                    choices[0].Fill = whiteColorToReplace;
                    currentChoice = 0;
                }
            }
        }
        public void ShowGameArea()
        {
            for (int i = 0; i < gameAreaGrid.RowDefinitions.Count() - 1; i++)
            {
                for (int j = 0; j < gameAreaGrid.ColumnDefinitions.Count(); j++)
                {
                    Grid.SetRow(GameArea[i, j].Value, i + 1);
                    Grid.SetColumn(GameArea[i, j].Value, j);
                }
            }
        }
        private void Refresh()
        {
            for (int i = 0; i < GameArea.GetLength(0); i++)
            {
                for (int j = 0; j < GameArea.GetLength(1); j++)
                {
                    GameArea[i, j].Value.Fill = indianRedColorToReplace;
                }
            }
            for (int i = 0; i < 7; i++)
            {
                lastPicks[i] = GameArea.GetLength(0) - 1;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                List<Winner> winners = repository.ReadAll().ToList();
                using (StreamWriter writer = new StreamWriter(openFileDialog.FileName))
                {
                    winners.ForEach(item => writer.Write(item.ToString() + ";"));
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (firstPalyer.Text != "" && secondPlayer.Text != "")
            {
                registrationGroupBox.Visibility = Visibility.Hidden;
                mainGroupBox.Visibility = Visibility.Visible;
                ((List<Player>)Players).Add(new Player(Guid.NewGuid().ToString(), firstPalyer.Text, Colors.White));
                ((List<Player>)Players).Add(new Player(Guid.NewGuid().ToString(), secondPlayer.Text, Colors.Black));
                Run();
                startButton.Focusable = false;
            }
            else
                MessageBox.Show("Enter the names of players");
        }
    }
}

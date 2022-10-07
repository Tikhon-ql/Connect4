using Connect4Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Connect4WUI.Models
{
    class Player : IPlayer
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public int Number { get; set; }

        public Chip playersChip = new Chip();

        public Player()
        {
            playersChip.Value.Width = 30;
            playersChip.Value.Height = 30;
            playersChip.Value.Fill = new SolidColorBrush(Colors.Black);
        }
        public Player(string id, string nickname,Color color)
        {
            Id = id;
            Nickname = nickname;
            playersChip.Value.Width = 30;
            playersChip.Value.Height = 30;
            playersChip.Value.Fill = new SolidColorBrush(color);
        }

        public int MakeStepChip(object sender, EventArgs args)
        {

            MainWindow main = (MainWindow)sender;
            KeyEventArgs e = (KeyEventArgs)args;
            if (e.Key == Key.Enter)
                return 1;
            switch (e.Key)
            {
                case Key.Right:
                    {
                        if (main.currentChoice < main.choices.Count - 1)
                        {
                            main.choices[main.currentChoice].Fill = main.indianRedColorToReplace;
                            main.choices[main.currentChoice + 1].Fill = main.whiteColorToReplace;
                            main.currentChoice++;
                        }

                        break;
                    }
                case Key.Left:
                    {
                        if (main.currentChoice >= 1)
                        {
                            main.choices[main.currentChoice].Fill = main.indianRedColorToReplace;
                            main.choices[main.currentChoice - 1].Fill = main.whiteColorToReplace;
                            main.currentChoice--;
                        }
                        break;
                    }
            }
           
            return 0;
        }

    }
}

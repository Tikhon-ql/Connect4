using Connect4Library.Interfaces;
using Connect4Library.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Connect4WUI.Implementations
{
    public class WinEngine : IWinEngine<Ellipse>
    {
        public bool IsWin(IChip<Ellipse>[,] gameArea, Pair<int> lastPick)
        {
            return IsVerticalWin(gameArea, lastPick) || IsHorizontalWin(gameArea, lastPick) || IsDiagonalWin(gameArea, lastPick);
        }
        private bool IsVerticalWin(IChip<Ellipse>[,] gameArea, Pair<int> lastPick)
        {
            IChip<Ellipse> chip = gameArea[lastPick.First, lastPick.Second];
            int count = 0;
            for (int i = 1; i < 5 && lastPick.First + i < gameArea.GetLength(0)
                && gameArea[lastPick.First + i, lastPick.Second].Equals(chip); i++)
            {
                count++;
            }
            if (count >= 3)
                return true;
            return false;
        }
        private bool IsHorizontalWin(IChip<Ellipse>[,] gameArea, Pair<int> lastPick)
        {
            IChip<Ellipse> chip = gameArea[lastPick.First, lastPick.Second];
            int leftCount = 0;
            int rightCount = 0;
            int i = 1;
            while(lastPick.Second - i >= 0 && gameArea[lastPick.First, lastPick.Second - i].Equals(chip))
            {
                leftCount++;
                i++;
            }
            i = 1;
            while (lastPick.Second + i < gameArea.GetLength(1) && gameArea[lastPick.First, lastPick.Second + i].Equals(chip))
            {
                rightCount++;
                i++;
            }
            if (leftCount + rightCount >= 3)
                return true;
            return false;
        }
        private bool IsDiagonalWin(IChip<Ellipse>[,] gameArea, Pair<int> lastPick)
        {
            IChip<Ellipse> chip = gameArea[lastPick.First, lastPick.Second];
            int leftCount = 0;
            int rightCount = 0;
        
            int i = 1;
            while (lastPick.Second + i < gameArea.GetLength(1) && lastPick.First - i >= 0 && gameArea[lastPick.First - i, lastPick.Second + i].Equals(chip))
            {
                rightCount++;
                i++;
            }
            i = 1;
            while (lastPick.Second - i >= 0 && lastPick.First + i < gameArea.GetLength(0) && gameArea[lastPick.First + i, lastPick.Second - i].Equals(chip))
            {
                leftCount++;
                i++;
            }
            i = 1;
            if (leftCount + rightCount >= 3)
                return true;
            leftCount = 0;
            rightCount = 0;
            while (lastPick.Second - i >= 0 && lastPick.First - i >= 0 && gameArea[lastPick.First - i, lastPick.Second - i].Equals(chip))
            {
                leftCount++;
                i++;
            }
            i = 1;
            while (lastPick.Second + i < gameArea.GetLength(1) && lastPick.First + i < gameArea.GetLength(0) && gameArea[lastPick.First + i, lastPick.Second + i].Equals(chip))
            {
                rightCount++;
                i++;
            }
            if (leftCount + rightCount >= 3)
                return true;
            return false;
        }

    }
}

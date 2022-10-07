using Connect4Library.Interfaces;
using Connect4Library.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class WinEngine : IWinEngine<string>
    {
        public bool IsWin(IChip<string>[,] gameArea, Pair<int> lastPick)
        {
            return IsVerticalWin(gameArea, lastPick) || IsHorizontalWin(gameArea, lastPick) || IsDiagonalWin(gameArea, lastPick);
        }
        private bool IsVerticalWin(IChip<string>[,] gameArea,Pair<int> lastPick)
        {
            IChip<string> chip = gameArea[lastPick.First, lastPick.Second];
            int count = 0;
            for (int i = 1; i < 5 && lastPick.First + i < gameArea.GetLength(0)
                && gameArea[lastPick.First + i, lastPick.Second].Value == chip.Value; i++)
            {
                count++;
            }
            if (count >= 3)
                return true;
            return false;
        }
        private bool IsHorizontalWin(IChip<string>[,] gameArea, Pair<int> lastPick)
        {
            IChip<string> chip = gameArea[lastPick.First, lastPick.Second];
            int count = 0;
            for (int i = 1; i < 5; i++)
            {
                if (lastPick.Second - i >= 0 && gameArea[lastPick.First, lastPick.Second - i].Value == chip.Value)
                    count++;
                if (lastPick.Second + i < gameArea.GetLength(1) && gameArea[lastPick.First, lastPick.Second + i].Value == chip.Value)
                    count++;
            }
            if (count >= 3)
                return true;
            return false;
        }
        private bool IsDiagonalWin(IChip<string>[,] gameArea, Pair<int> lastPick)
        {
            IChip<string> chip = gameArea[lastPick.First, lastPick.Second];
            int count = 0;
            for (int i = 1; i < 5; i++)
            {
                if (lastPick.Second - i >= 0 && lastPick.First + i < gameArea.GetLength(0) && gameArea[lastPick.First + i, lastPick.Second - i].Value == chip.Value)
                {
                    count++;
                    continue;
                }

                if (lastPick.Second + i < gameArea.GetLength(1) && lastPick.First + i < gameArea.GetLength(0) && gameArea[lastPick.First + i, lastPick.Second + i].Value == chip.Value)
                {
                    count++;
                    continue;
                }

                if (lastPick.Second - i >= 0 && lastPick.First - i >= 0 && gameArea[lastPick.First - i, lastPick.Second - i].Value == chip.Value)
                {
                    count++;
                    continue;
                }
                if (lastPick.Second + i < gameArea.GetLength(1) && lastPick.First - i >= 0 && gameArea[lastPick.First - i, lastPick.Second + i].Value == chip.Value)
                {
                    count++;
                    continue;
                }
            }
            if (count >= 3)
                return true;
            return false;
        }

    }
}

using Connect4Library.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Library.Interfaces
{
    public interface IWinEngine<T>
    {
        bool IsWin(IChip<T>[,] gameArea, Pair<int> lastPick);
    }
}

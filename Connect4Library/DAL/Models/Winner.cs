using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Library.DAL.Models
{
    public class Winner
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public int CountOfWins { get; set; } = 0;
        public int CountOfLoses { get; set; } = 0;
        public double WinLoseKD { get; set; } = 0.00;
        /// <summary>
        /// Shit code
        /// </summary>
        public bool IsWin { get; set; }
        public DateTime LastWin { get; set; }
        public Winner(string id,string name)
        {
            Id = id;
            Name = name;
        }
        public Winner(string id, string name,bool isWin)
        {
            Id = id;
            Name = name;
            IsWin = isWin;
        }
        public Winner()
        {

        }
        public void ResetKD()
        {
            if(CountOfLoses != 0)
                WinLoseKD = (double)CountOfWins / (double)CountOfLoses;
        }
        public override string ToString()
        {
            return Id + " " + Name; 
        }
    }
}

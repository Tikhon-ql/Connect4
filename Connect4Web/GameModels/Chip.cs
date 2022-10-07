using Connect4Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4Web.GameModels
{
    public class Chip : IChip<Color>
    {
        public Color Value { get ; set ; }
        public int PlayerId { get; set; }

        public override bool Equals(object obj)
        {
            return Value == ((Chip)obj).Value && PlayerId == ((Chip)obj).PlayerId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

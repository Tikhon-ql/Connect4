using Connect4Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.Models
{
    public class Chip : IChip<string>
    {
        public string Value { get; set; } = "0";

        public override bool Equals(object obj)
        {
            return Value == ((Chip)obj).Value;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

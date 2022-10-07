using Connect4Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Library.Models
{
    public class Chip : IChip<string>
    {
        public string Value { get; set; } = "0";

    }
}

using Connect4Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Connect4WUI.Models
{
    public class Chip : IChip<Ellipse>
    {
        public Ellipse Value { get; set; } = new Ellipse();
        public Chip()
        {

        }
        public Chip(Ellipse ellipse)
        {
            Value = ellipse;
        }

        public override bool Equals(object obj)
        {
            return Value.Fill == ((Chip)obj).Value.Fill;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4Library.Interfaces
{
    public interface IPlayer
    {
        string Id { get; set; }
        string Nickname { get; set; }
        int MakeStepChip(object sender,EventArgs args);
    }
}

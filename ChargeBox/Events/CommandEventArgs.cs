using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox.Events
{
    public class CommandEventArgs
    {
        public ControlBoard ControlBoard { get; set; }
        public string Command { get; set; }

        public CommandEventArgs(ControlBoard board, string command)
        {
            this.ControlBoard = board;
            this.Command = command;
        }
    }
}

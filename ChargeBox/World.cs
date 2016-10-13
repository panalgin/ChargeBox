using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox
{
    public static class World
    {
        public static ControlBoard ControlBoard { get; set; }
        public static List<PortState> PortStates { get; set; }
        public static void Initialize()
        {
            PortStates = new List<PortState>();
        }
    }
}

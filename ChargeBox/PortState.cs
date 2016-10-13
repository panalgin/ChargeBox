using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox
{
    public class PortState
    {
        public byte PortID { get; set; }
        public bool IsConnected { get; set; }
        public bool IsCharging { get; set; }
        public ushort RemainingChargingTime { get; set; }

        public PortState()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox.Commands
{
    public class SettingsCommand : BaseCommand
    {
        public byte TokenMax1 { get; set; }
        public byte TokenMax2 { get; set; }
        public byte ChargePeriod { get; set; }
        public byte AwaitInterval { get; set; }
        public bool Mode { get; set; } // false: auto, true: manual

        public SettingsCommand(byte tokenMax1, byte tokenMax2, byte chargePeriod, byte awaitInterval, bool mode)
        {
            this.TokenMax1 = tokenMax1;
            this.TokenMax2 = tokenMax2;
            this.ChargePeriod = chargePeriod;
            this.AwaitInterval = awaitInterval;
            this.Mode = mode;

            this.Name = "Settings";
            this.Parameters = string.Format("{0}:{1}:{2}:{3}:{4}", this.TokenMax1, this.TokenMax2, this.ChargePeriod, this.AwaitInterval, this.Mode.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox.Commands
{
    public class OpenDrawerCommand : BaseCommand
    {
        public byte DrawerID { get; set; }


        public OpenDrawerCommand(byte id)
        {
            this.DrawerID = id;
            this.Name = "OpenDrawer";
            this.Parameters = string.Format("{0}", this.DrawerID.ToString());
        }
    }
}

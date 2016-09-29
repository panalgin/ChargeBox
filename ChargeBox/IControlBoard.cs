﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeBox.Commands;

namespace ChargeBox
{
    interface IControlBoard
    {
        SerialConnection SerialConnection { get; set; }
        string Name { get; set; }
        void Send(BaseCommand command);
    }
}

﻿using Newtonsoft.Json;

namespace ChargeBox.Events
{
    public class DeviceDisconnectedArgs
    {
        public byte PortID { get; set; }
        [JsonIgnore]
        public string Json { get; set; }

        public DeviceDisconnectedArgs(string json)
        {

        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChargeBox.Events
{
    public class DeviceDisconnectedArgs
    {
        public byte PortID { get; set; }
        [JsonIgnore]
        public string Json { get; set; }

        public DeviceDisconnectedArgs(string json)
        {
            var m_Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            this.PortID = Convert.ToByte(m_Data["PortID"]);

            this.Json = JsonConvert.SerializeObject(this);
        }
    }
}
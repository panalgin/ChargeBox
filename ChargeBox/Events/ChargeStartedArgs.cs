using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChargeBox.Events
{
    public class ChargeStartedArgs
    {
        public byte PortID { get; set; }
        public ushort Period { get; set; }

        [JsonIgnore]
        public string Json { get; set; }

        public ChargeStartedArgs(string json)
        {
            var m_Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            this.PortID = Convert.ToByte(m_Data["PortID"]);
            this.Period = Convert.ToUInt16(m_Data["Period"]);

            this.Json = JsonConvert.SerializeObject(this);
        }
    }
}
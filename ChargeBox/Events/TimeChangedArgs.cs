using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChargeBox.Events
{
    public class TimeChangedArgs
    {
        public ushort[] OutputTimeTable { get; set; }

        [JsonIgnore]
        public string Json { get; set; }
        public TimeChangedArgs(string json)
        {
            var m_Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            this.OutputTimeTable = JsonConvert.DeserializeObject<ushort[]>(m_Data["Table"].ToString());


            if (World.PortStates != null && World.PortStates.Count == this.OutputTimeTable.Length)
            {
                for (byte i = 0; i < this.OutputTimeTable.Length; i++)
                {
                    World.PortStates[i].RemainingChargingTime = this.OutputTimeTable[i];
                }
            }

            this.Json = JsonConvert.SerializeObject(World.PortStates);
        }
    }
}
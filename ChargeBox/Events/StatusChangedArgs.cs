using Newtonsoft.Json;
using System.Collections.Generic;

namespace ChargeBox.Events
{
    public class StatusChangedArgs
    {
        public byte[] Translation { get; set; }
        public ushort InputState { get; set; }
        public ushort OutputState { get; set; }


        [JsonIgnore]
        public string Json { get; set; }
        public StatusChangedArgs(string json)
        {
            var m_Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);



            this.Json = JsonConvert.SerializeObject(this);
        }
    }
}
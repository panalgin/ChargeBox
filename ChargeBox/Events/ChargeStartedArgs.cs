using Newtonsoft.Json;

namespace ChargeBox.Events
{
    public class ChargeStartedArgs
    {
        public byte PortID { get; set; }
        public byte Period { get; set; }

        [JsonIgnore]
        public string Json { get; set; }

        public ChargeStartedArgs(string json)
        {

        }

    }
}
using Newtonsoft.Json;

namespace ChargeBox.Events
{
    public class ChargeFinishedArgs
    {
        public byte PortID { get; set; }

        [JsonIgnore]
        public string Json { get; set; }

        public ChargeFinishedArgs(string json)
        {

        }
    }
}
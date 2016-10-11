using Newtonsoft.Json;

namespace ChargeBox.Events
{
    public class DeviceConnectedArgs
    {
        public byte PortID { get; set; }

        [JsonIgnore]
        public string Json { get; set; }
        public DeviceConnectedArgs(string json)
        {

        }
    }
}
using Newtonsoft.Json;
using System;

namespace ChargeBox.Events
{
    public class AwaitTimeoutArgs
    {
        public byte Surpassed { get; set; }

        [JsonIgnore]
        public string Json { get; set; }
        public AwaitTimeoutArgs(string cmd)
        {
            this.Surpassed = Convert.ToByte(cmd);

            this.Json = JsonConvert.SerializeObject(this);
        }
    }
}
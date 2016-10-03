using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox.Events
{
    public class TokenInsertedArgs
    {
        public byte Slot { get; set; }
        public byte Amount { get; set; }
        public byte Remaining { get; set; }
        public DateTime InsertedAt { get; set; }

        [JsonIgnore]
        public string Json { get; set; }

        public TokenInsertedArgs(string cmd) 
        {
            var m_Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(cmd);

            this.Slot = Convert.ToByte(m_Data["Slot"]);
            this.Amount = Convert.ToByte(m_Data["Amount"]);
            this.Remaining = Convert.ToByte(m_Data["Remaining"]);
            this.InsertedAt = DateTime.Now;

            this.Json = JsonConvert.SerializeObject(this);
        }
    }
}

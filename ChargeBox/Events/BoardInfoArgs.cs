using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox.Events
{
    public class BoardInfoArgs
    {
        public string Serial { get; set; }
        public byte ChargePeriod { get; set; }
        public byte AwaitInterval { get; set; }
        public byte TokenMax1 { get; set; }
        public byte TokenMax2 { get; set; }
        public uint TokenTotal1 { get; set; }
        public uint TokenTotal2 { get; set; }
        public byte Factory { get; set; }
        public bool Mode { get; set; }


        public string Json { get; set; }

        public BoardInfoArgs(string jsonVal)
        {
            try
            {
                var m_Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonVal);

                this.Serial = m_Data["Serial"].ToString();
                this.ChargePeriod = Convert.ToByte(m_Data["ChargePeriod"]);
                this.AwaitInterval = Convert.ToByte(m_Data["AwaitInterval"]);
                this.TokenMax1 = Convert.ToByte(m_Data["TokenMax1"]);
                this.TokenMax2 = Convert.ToByte(m_Data["TokenMax2"]);
                this.TokenTotal1 = Convert.ToUInt32(m_Data["TokenTotal1"]);
                this.TokenTotal2 = Convert.ToUInt32(m_Data["TokenTotal2"]);
                this.Factory = Convert.ToByte(m_Data["Factory"]);
                this.Mode = Convert.ToBoolean(m_Data["Mode"]);

                this.Json = jsonVal;
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
            }
        }
    }
}

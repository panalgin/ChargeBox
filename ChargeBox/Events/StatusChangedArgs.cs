using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ChargeBox.Events
{
    public class StatusChangedArgs
    {
        [JsonIgnore]
        private byte[] _Translation { get; set; }
        [JsonIgnore]
        private byte[] _InputState { get; set; }
        [JsonIgnore]
        private byte[] _OutputState { get; set; }
        [JsonIgnore]
        private ushort[] _OutputTimeTable { get; set; }

        [JsonIgnore]
        public string Json { get; set; }
        public StatusChangedArgs(string json)
        {
            try
            {
                World.PortStates.Clear();

                var m_Data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                _Translation = JsonConvert.DeserializeObject<byte[]>(m_Data["Translation"].ToString());

                BitArray m_TempArray = new BitArray(BitConverter.GetBytes(Convert.ToUInt16(m_Data["InputState"])));
                bool[] m_TempBool = new bool[m_TempArray.Count];
                m_TempArray.CopyTo(m_TempBool, 0);
                _InputState = m_TempBool.Select(q => (byte)(q ? 1 : 0)).ToArray();

                m_TempArray = new BitArray(BitConverter.GetBytes(Convert.ToUInt16(m_Data["OutputState"])));
                m_TempBool = new bool[m_TempArray.Count];
                m_TempArray.CopyTo(m_TempBool, 0);
                _OutputState = m_TempBool.Select(q => (byte)(q ? 1 : 0)).ToArray();

                _OutputTimeTable = JsonConvert.DeserializeObject<ushort[]>(m_Data["OutputTimeTable"].ToString());

                for (byte i = 0; i < 16; i++)
                {
                    PortState m_State = new PortState();
                    m_State.PortID = i;
                    m_State.IsCharging = !Convert.ToBoolean(_OutputState[i]); // already translated
                    m_State.IsConnected = !Convert.ToBoolean(_InputState[_Translation[i]]);
                    m_State.RemainingChargingTime = _OutputTimeTable[i];

                    World.PortStates.Add(m_State);
                }


                this.Json = JsonConvert.SerializeObject(World.PortStates);
            }
            catch(Exception ex)
            {
                Logger.Enqueue(ex);
            }
        }
    }
}
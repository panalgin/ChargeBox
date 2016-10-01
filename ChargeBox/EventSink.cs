using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox
{
    public static class EventSink
    {
        public delegate void OnCommandSent(CommandEventArgs args);
        public delegate void OnCommandFailed(CommandEventArgs args);
        public delegate void OnCommandReceived(CommandEventArgs args);
        public delegate void OnConnected(ControlBoard board);
        public delegate void OnDisconnected(ControlBoard board);
        public delegate void OnBoardInfoChanged(BoardInfoArgs args);

        public static event OnCommandSent CommandSent;
        public static event OnCommandFailed CommandFailed;
        public static event OnCommandReceived CommandReceived;
        public static event OnConnected Connected;
        public static event OnDisconnected Disconnected;
        public static event OnBoardInfoChanged BoardInfoChanged;

        public static void InvokeCommandSent(CommandEventArgs args)
        {
            if (CommandSent != null)
                CommandSent(args);
        }

        public static void InvokeCommandFailed(CommandEventArgs args)
        {
            if (CommandFailed != null)
                CommandFailed(args);
        }

        public static void InvokeCommandReceived(CommandEventArgs args)
        {
            if (CommandReceived != null)
                CommandReceived(args);
        }

        public static void InvokeConnected(ControlBoard board)
        {
            if (Connected != null)
                Connected(board);
        }

        public static void InvokeDisconnected(ControlBoard board)
        {
            if (Disconnected != null)
                Disconnected(board);
        }

        public static void InvokeBoardInfoChanged(BoardInfoArgs args)
        {
            BoardInfoChanged?.Invoke(args);
        }
    }

    public class CommandEventArgs
    {
        public ControlBoard ControlBoard { get; set; }
        public string Command { get; set; }

        public CommandEventArgs(ControlBoard board, string command)
        {
            this.ControlBoard = board;
            this.Command = command;
        }
    }

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

                this.Json = jsonVal;
            }
            catch(Exception ex)
            {
                Logger.Enqueue(ex);
            }
        }
    }
}

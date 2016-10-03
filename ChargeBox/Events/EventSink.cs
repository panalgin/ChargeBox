using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox.Events
{
    public static class EventSink
    {
        public delegate void OnCommandSent(CommandEventArgs args);
        public delegate void OnCommandFailed(CommandEventArgs args);
        public delegate void OnCommandReceived(CommandEventArgs args);
        public delegate void OnConnected(ControlBoard board);
        public delegate void OnDisconnected(ControlBoard board);
        public delegate void OnBoardInfoChanged(BoardInfoArgs args);
        public delegate void OnTokenInserted(TokenInsertedArgs args);

        public static event OnCommandSent CommandSent;
        public static event OnCommandFailed CommandFailed;
        public static event OnCommandReceived CommandReceived;
        public static event OnConnected Connected;
        public static event OnDisconnected Disconnected;
        public static event OnBoardInfoChanged BoardInfoChanged;
        public static event OnTokenInserted TokenInserted;

        public static void InvokeCommandSent(CommandEventArgs args)
        {
            CommandSent?.Invoke(args);
        }

        public static void InvokeCommandFailed(CommandEventArgs args)
        {
            CommandFailed?.Invoke(args);
        }

        public static void InvokeCommandReceived(CommandEventArgs args)
        {
            CommandReceived?.Invoke(args);
        }

        public static void InvokeConnected(ControlBoard board)
        {
            Connected?.Invoke(board);
        }

        public static void InvokeDisconnected(ControlBoard board)
        {
            Disconnected?.Invoke(board);
        }

        public static void InvokeBoardInfoChanged(BoardInfoArgs args)
        {
            BoardInfoChanged?.Invoke(args);
        }

        public static void InvokeTokenInserted(TokenInsertedArgs args)
        {
            TokenInserted?.Invoke(args);
        }
    }
}

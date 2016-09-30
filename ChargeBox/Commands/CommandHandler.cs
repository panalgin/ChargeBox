using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeBox.Commands
{
    public class CommandHandler
    {
        private byte[] inputBuffer = new byte[256];

        public ControlBoard Board { get; private set; }
        public CommandHandler(ControlBoard board)
        {
            this.Board = board;
        }

        private void Send(string command)
        { 
            try
            {
                this.Board.SerialConnection.Write(command);

                CommandEventArgs args = new CommandEventArgs(this.Board, command);
                EventSink.InvokeCommandSent(args);
            }
            catch (Exception ex)
            {
                Logger.Enqueue(ex);
                CommandEventArgs args = new CommandEventArgs(this.Board, command);
                EventSink.InvokeCommandFailed(args);
            }
        }

        public void Send(BaseCommand command)
        {
            if (command is HelloCommand)
                this.Send(command.ToString());
            else
            {
                if (this.Board.IsConnected)
                    this.Send(command.ToString());
            }
        }


        private static string incomingData = "";

        public void Parse(string data)
        {
            incomingData += data;

            if (incomingData.EndsWith(Environment.NewLine) || incomingData.EndsWith("\0"))
            {
                incomingData = incomingData.Replace("\r\n", "").Replace("\n", "").Replace("\0", "");

                EventSink.InvokeCommandReceived(new CommandEventArgs(this.Board, incomingData));

                if (incomingData.Contains(string.Format("Hello: {0}", this.Board.Name)))
                {
                    this.Board.IsConnected = true;
                    EventSink.InvokeConnected(this.Board);
                }

                else if (incomingData.StartsWith("Pos: ")) // Format: Pos: A:5000,B:-500,C:123
                {
                    incomingData = incomingData.Replace("Pos: ", "");

                    string[] parsed = incomingData.Split(',');

                    foreach (string i in parsed)
                    {
                        string[] item = i.Split(':');
                        string axis = item[0];
                        string value = item[1];

                        ulong pos = 0;
                        bool isNumber = ulong.TryParse(value, out pos);

                        if (isNumber)
                            EventSink.InvokePositionChanged(axis, pos);

                    }
                }

                incomingData = "";
            }
        }

        public void Read()
        {
            int length = this.Board.SerialConnection.BytesToRead;
            byte[] buffer = new byte[length];
            this.Board.SerialConnection.Read(buffer, 0, length);

            string data = Encoding.UTF8.GetString(buffer);

            this.Parse(data);
        }
    }
}

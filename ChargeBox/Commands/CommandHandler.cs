using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChargeBox.Events;

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

            if (incomingData.EndsWith(Environment.NewLine))
            {
                incomingData = incomingData.Replace("\r\n", "|");

                string[] m_Commands = incomingData.Split('|');

                if (m_Commands.Length > 0)
                {
                    for(int i = 0; i < m_Commands.Length; i++)
                    {
                        if (m_Commands[i].Length > 0)
                        {
                            string m_Command = m_Commands[i];

                            EventSink.InvokeCommandReceived(new CommandEventArgs(this.Board, m_Command));

                            if (m_Command.Contains(string.Format("Hello: {0}", this.Board.Name)))
                            {
                                this.Board.IsConnected = true;
                                EventSink.InvokeConnected(this.Board);
                            }

                            else if (m_Command.StartsWith("BoardInfo: ")) // Format: Pos: A:5000,B:-500,C:123
                            {
                                m_Command = m_Command.Replace("BoardInfo: ", "");

                                BoardInfoArgs args = new BoardInfoArgs(m_Command);
                                EventSink.InvokeBoardInfoChanged(args);
                            }
                            else if (m_Command.StartsWith("TokenInserted: "))
                            {
                                m_Command = m_Command.Replace("TokenInserted: ", "");

                                TokenInsertedArgs args = new TokenInsertedArgs(m_Command);
                                EventSink.InvokeTokenInserted(args);
                            }
                            else if (m_Command.StartsWith("DeviceConnected: "))
                            {
                                m_Command = m_Command.Replace("DeviceConnected: ", "");
                                DeviceConnectedArgs args = new DeviceConnectedArgs(m_Command);
                                EventSink.InvokeDeviceConnected(args);
                            }
                            else if (m_Command.StartsWith("DeviceDisconnected: "))
                            {
                                m_Command = m_Command.Replace("DeviceDisconnected: ", "");
                                DeviceDisconnectedArgs args = new DeviceDisconnectedArgs(m_Command);
                                EventSink.InvokeDeviceDisconnected(args);
                            }
                            else if (m_Command.StartsWith("ChargeAuthorized: "))
                            {
                                m_Command = m_Command.Replace("ChargeAuthorized: ", "");
                                ChargeAuthorizedArgs args = new ChargeAuthorizedArgs();
                                EventSink.InvokeChargeAuthorized(args);
                            }
                            else if (m_Command.StartsWith("ChargeStarted: "))
                            {
                                m_Command = m_Command.Replace("ChargeStarted: ", "");
                                ChargeStartedArgs args = new ChargeStartedArgs(m_Command);
                                EventSink.InvokeChargeStarted(args);
                            }
                            else if (m_Command.StartsWith("ChargeFinished: "))
                            {
                                m_Command = m_Command.Replace("ChargeFinished: ", "");
                                ChargeFinishedArgs args = new ChargeFinishedArgs(m_Command);
                                EventSink.InvokeChargeFinished(args);
                            }
                            else if (m_Command.StartsWith("AwaitTimeout: "))
                            {
                                m_Command = m_Command.Replace("AwaitTimeout: ", "");
                                AwaitTimeoutArgs args = new AwaitTimeoutArgs(m_Command);
                                EventSink.InvokeAwaitTimeout(args);
                            }
                        }
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

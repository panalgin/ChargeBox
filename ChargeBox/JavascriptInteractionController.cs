﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows;
using System.Windows.Threading;
using ChargeBox.Commands;
using ChargeBox.Events;

namespace ChargeBox
{
    public class JavascriptInteractionController
    {
        public JavascriptInteractionController()
        {
            EventSink.CommandSent += EventSink_CommandSent;
            EventSink.CommandFailed += EventSink_CommandFailed;
            EventSink.CommandReceived += EventSink_CommandReceived;
            EventSink.Connected += EventSink_Connected;
            EventSink.Disconnected += EventSink_Disconnected;
            EventSink.BoardInfoChanged += EventSink_BoardInfoChanged;
            EventSink.TokenInserted += EventSink_TokenInserted;
            EventSink.ChargeAuthorized += EventSink_ChargeAuthorized;
            EventSink.ChargeStarted += EventSink_ChargeStarted;
            EventSink.ChargeFinished += EventSink_ChargeFinished;
            EventSink.AwaitTimeout += EventSink_AwaitTimeout;
            EventSink.DeviceConnected += EventSink_DeviceConnected;
            EventSink.DeviceDisconnected += EventSink_DeviceDisconnected;
            EventSink.StatusChanged += EventSink_StatusChanged;
            EventSink.TimeChanged += EventSink_TimeChanged;
        }

        private void EventSink_TimeChanged(TimeChangedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.TimeChanged, args.Json);
        }

        private void EventSink_StatusChanged(StatusChangedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.StatusChanged, args.Json);
        }

        private void EventSink_DeviceDisconnected(DeviceDisconnectedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.DeviceDisconnected, args.Json);
        }

        private void EventSink_DeviceConnected(DeviceConnectedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.DeviceConnected, args.Json);
        }

        private void EventSink_AwaitTimeout(AwaitTimeoutArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.AwaitTimeout, args.Json);
        }

        private void EventSink_ChargeFinished(ChargeFinishedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.ChargeFinished, args.Json);
        }

        private void EventSink_ChargeStarted(ChargeStartedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.ChargeStarted, args.Json);
        }

        private void EventSink_ChargeAuthorized(ChargeAuthorizedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.ChargeAuthorized, args.Json);
        }

        private void EventSink_TokenInserted(TokenInsertedArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.TokenInserted, args.Json);
        }

        private void EventSink_BoardInfoChanged(BoardInfoArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.BoardInfoChanged, args.Json);
        }

        public void Exit()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action( delegate ()
            {
                Application.Current.Shutdown();
            }));
        }

        public bool ToggleWindowState()
        {
            bool isMaximized = false;
            Application.Current.Dispatcher.Invoke(new Action(() => {
                if (Application.Current.MainWindow.WindowState == WindowState.Normal)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;

                    isMaximized = true;
                }
                else if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                {
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                    isMaximized = false;
                }

            }), DispatcherPriority.ContextIdle);

            return isMaximized;
        }

        public void MinimizeWindowState()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            }));
        }

        public void OpenDrawer(string id)
        {
            OpenDrawerCommand m_Command = new OpenDrawerCommand(Convert.ToByte(id));
            m_Command.Send();
        }

        public void Connect(string port, int baud)
        {
            if (World.ControlBoard == null)
            {
                SerialConnection serialConnection = new SerialConnection(port, baud);
                ControlBoard m_Control = new ControlBoard(serialConnection);
                m_Control.Connect();

                World.ControlBoard = m_Control;
            }
            else
            {
                if (!World.ControlBoard.IsConnected)
                {
                    World.ControlBoard.SerialConnection.Dispose();

                    SerialConnection serialConnection = new SerialConnection(port, baud);
                    World.ControlBoard.SerialConnection = serialConnection;
                    World.ControlBoard.Connect();
                }
                else
                {
                    //TODO add already connected feature
                }
            }
        }

        public void Disconnect()
        {
            if (World.ControlBoard != null)
                World.ControlBoard.Disconnect();
        }

        public void ApplySettings(Dictionary<string, object> data)
        {
            byte m_TokenMax1 = Convert.ToByte(data["TokenMax1"]);
            byte m_TokenMax2 = Convert.ToByte(data["TokenMax2"]);
            byte m_ChargePeriod = Convert.ToByte(data["ChargePeriod"]);
            byte m_AwaitInterval = Convert.ToByte(data["AwaitInterval"]);
            bool m_Mode = Convert.ToBoolean(data["Mode"]); // false: auto; true: manual
             
            SettingsCommand m_Command = new SettingsCommand(m_TokenMax1, m_TokenMax2, m_ChargePeriod, m_AwaitInterval, m_Mode);
            m_Command.Send();
        }

        #region EventHooks

        private void EventSink_Disconnected(ControlBoard board)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.Disconnected, string.Empty);
        }

        private void EventSink_Connected(ControlBoard board)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.Connected, board.SerialConnection.PortName);
        }

        private void EventSink_CommandReceived(CommandEventArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.CommandReceived, args.Command);
        }

        private void EventSink_CommandFailed(CommandEventArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.CommandFailed, args.Command);
        }

        private void EventSink_CommandSent(CommandEventArgs args)
        {
            JavascriptInjector.Run(JavascriptInjector.ScriptAction.CommandSent, args.Command); // Sent: Hello Default;
        }

        #endregion

        /// <summary>
        /// Gets serial communications port available at current computer
        /// </summary>
        /// <returns>Returns the serial communication port names</returns>
        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }
    }
}

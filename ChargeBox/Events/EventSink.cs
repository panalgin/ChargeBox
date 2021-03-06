﻿using Newtonsoft.Json;
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
        public delegate void OnChargeAuthorized(ChargeAuthorizedArgs args);
        public delegate void OnChargeStarted(ChargeStartedArgs args);
        public delegate void OnChargeFinished(ChargeFinishedArgs args);
    
        public delegate void OnAwaitTimeout(AwaitTimeoutArgs args);
        public delegate void OnDeviceConnected(DeviceConnectedArgs args);
        public delegate void OnDeviceDisconnected(DeviceDisconnectedArgs args);

        public delegate void OnStatusChanged(StatusChangedArgs args);
        public delegate void OnTimeChanged(TimeChangedArgs args);


        public static event OnCommandSent CommandSent;
        public static event OnCommandFailed CommandFailed;
        public static event OnCommandReceived CommandReceived;
        public static event OnConnected Connected;
        public static event OnDisconnected Disconnected;
        public static event OnBoardInfoChanged BoardInfoChanged;
        public static event OnTokenInserted TokenInserted;

        public static event OnChargeAuthorized ChargeAuthorized;
        public static event OnChargeStarted ChargeStarted;
        public static event OnChargeFinished ChargeFinished;

        public static event OnAwaitTimeout AwaitTimeout;
        public static event OnDeviceConnected DeviceConnected;
        public static event OnDeviceDisconnected DeviceDisconnected;

        public static event OnStatusChanged StatusChanged;
        public static event OnTimeChanged TimeChanged;
        

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

        public static void InvokeAwaitTimeout(AwaitTimeoutArgs args)
        {
            AwaitTimeout?.Invoke(args);
        }

        public static void InvokeDeviceConnected(DeviceConnectedArgs args)
        {
            DeviceConnected?.Invoke(args);
        }

        public static void InvokeDeviceDisconnected(DeviceDisconnectedArgs args)
        {
            DeviceDisconnected?.Invoke(args);
        }

        public static void InvokeChargeAuthorized(ChargeAuthorizedArgs args)
        {
            ChargeAuthorized?.Invoke(args);
        }

        public static void InvokeChargeStarted(ChargeStartedArgs args)
        {
            ChargeStarted?.Invoke(args);
        }

        public static void InvokeChargeFinished(ChargeFinishedArgs args)
        {
            ChargeFinished?.Invoke(args);
        }

        public static void InvokeStatusChanged(StatusChangedArgs args)
        {
            StatusChanged?.Invoke(args);
        }

        public static void InvokeTimeChanged(TimeChangedArgs args)
        {
            TimeChanged?.Invoke(args);
        }
    }
}

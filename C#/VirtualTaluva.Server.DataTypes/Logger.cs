﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using VirtualTaluva.Protocol;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.DataTypes.Protocol;
using Com.Ericmas001.Common;

namespace VirtualTaluva.Server.DataTypes
{
    [SuppressMessage("ReSharper", "EventNeverSubscribedTo.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Logger
    {
        public static event EventHandler<EventArgs<string>> VerboseInformationLogged = delegate { };
        public static event EventHandler<EventArgs<string>> DebugInformationLogged = delegate { };
        public static event EventHandler<EventArgs<string>> InformationLogged = delegate { };
        public static event EventHandler<EventArgs<string>> WarningLogged = delegate { };
        public static event EventHandler<EventArgs<string>> ErrorLogged = delegate { };

        public static event EventHandler<EventArgs<string>> MessageLogged = delegate { };

        public static event EventHandler<LogCommandEventArg> CommandSent = delegate { };
        public static event EventHandler<LogCommandEventArg> CommandReceived = delegate { };
        public static event EventHandler<LogTableCreationEventArg> TableCreated = delegate { };
        public static event EventHandler<LogGameEventArg> GameCreated = delegate { };
        public static event EventHandler<LogGameEventArg> GameEnded = delegate { };
        public static event EventHandler<LogClientCreationEventArg> ClientCreated = delegate { };
        public static event EventHandler<LogClientEventArg> ClientIdentified = delegate { };
        public static event EventHandler<LogClientEventArg> ClientAdditionalInfo = delegate { };

        public static void LogVerboseInformation(string message, params object[] args)
        {
            MessageLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
            VerboseInformationLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
        }
        public static void LogDebugInformation(string message, params object[] args)
        {
            MessageLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
            DebugInformationLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
        }
        public static void LogInformation(string message, params object[] args)
        {
            MessageLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
            InformationLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
        }
        public static void LogWarning(string message, params object[] args)
        {
            MessageLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
            WarningLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
        }
        public static void LogError(string message, params object[] args)
        {
            MessageLogged(new StackFrame(1), new EventArgs<string>(string.Format(message, args)));
            ErrorLogged(new StackFrame(1), new EventArgs<string>(string.Format(message,args)));
        }

        public static void LogCommandSent(AbstractCommand cmd, IBluffinClient cli, string commandData)
        {
            CommandSent(new StackFrame(1), new LogCommandEventArg(cmd, commandData, cli));
            VerboseInformationLogged(new StackFrame(1), new EventArgs<string>($"Server SEND to {cli.PlayerName} [{commandData}]"));
            VerboseInformationLogged(new StackFrame(1), new EventArgs<string>("-------------------------------------------"));
        }
        public static void LogCommandReceived(AbstractCommand cmd, IBluffinClient cli, string commandData)
        {
            CommandReceived(new StackFrame(1), new LogCommandEventArg(cmd, commandData, cli ));
            VerboseInformationLogged(new StackFrame(1), new EventArgs<string>($"Server RECV from {cli.PlayerName} [{commandData}]"));
            VerboseInformationLogged(new StackFrame(1), new EventArgs<string>("-------------------------------------------"));
        }
        public static void LogTableCreated(int id, TableParams p)
        {
            TableCreated(new StackFrame(1), new LogTableCreationEventArg(id, p));
        }
        public static void LogGameCreated(int id)
        {
            GameCreated(new StackFrame(1), new LogGameEventArg(id));
        }
        public static void LogGameEnded(int id)
        {
            GameEnded(new StackFrame(1), new LogGameEventArg(id));
        }
        public static void LogClientCreated(TcpClient endpoint, IBluffinClient client)
        {
            ClientCreated(new StackFrame(1), new LogClientCreationEventArg(endpoint, client));
        }
        public static void LogClientIdentified(IBluffinClient client)
        {
            ClientIdentified(new StackFrame(1), new LogClientEventArg(client));
        }
        public static void LogClientAdditionalInfo(IBluffinClient client)
        {
            ClientAdditionalInfo(new StackFrame(1), new LogClientEventArg(client));
        }
    }
}

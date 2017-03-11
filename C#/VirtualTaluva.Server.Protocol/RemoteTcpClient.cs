﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using VirtualTaluva.Protocol;
using VirtualTaluva.Protocol.Enums;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Protocol;
using Com.Ericmas001.Communication;

namespace VirtualTaluva.Server.Protocol
{
    public class RemoteTcpClient : RemoteTcpEntity, IBluffinClient
    {
        private readonly IBluffinServer m_BluffinServer;

        private readonly Dictionary<int, RemotePlayer> m_GamePlayers = new Dictionary<int, RemotePlayer>(); 

        public string PlayerName { get; set; }
        public string ClientIdentification { get; set; }
        public Version SupportedProtocol { get; set; }

        public Dictionary<int, RemotePlayer> GamePlayers => m_GamePlayers;

        public RemoteTcpClient(TcpClient remoteEntity, IBluffinServer bluffinServer)
            : base(remoteEntity)
        {
            m_BluffinServer = bluffinServer;
            Logger.LogClientCreated(remoteEntity, this);
        }

        protected override void OnDataReceived(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                var command = AbstractCommand.DeserializeCommand(data);
                Logger.LogCommandReceived(command, this, data);
                switch (command.CommandType)
                {
                    case TaluvaCommandEnum.General:
                        m_BluffinServer.LobbyCommands.Add(new CommandEntry() { Client = this, Command = command });
                        lock (m_GamePlayers)
                        {
                            foreach(RemotePlayer p in m_GamePlayers.Values)
                                m_BluffinServer.GameCommands.Add(new GameCommandEntry() { Client = this, Command = command, Player = p });
                        }
                        break;
                    case TaluvaCommandEnum.Lobby:
                        m_BluffinServer.LobbyCommands.Add(new CommandEntry() { Client = this, Command = command });
                        break;
                    case TaluvaCommandEnum.Game:
                        var gc = (AbstractGameCommand) command;
                        lock (m_GamePlayers)
                        {
                            if (m_GamePlayers.ContainsKey(gc.TableId))
                                m_BluffinServer.GameCommands.Add(new GameCommandEntry() {Client = this, Command = command, Player = m_GamePlayers[gc.TableId]});
                        }
                        break;
                }
            }
        }

        protected override void OnDataSent(string data)
        {
        }

        public void OnConnectionLost()
        {
            OnDataReceived(new DisconnectCommand().Encode());
        }

        public void SendCommand(AbstractCommand command)
        {
            var line = command.Encode();
            Logger.LogCommandSent(command, this, line);
            Send(line);
        }

        public void AddPlayer(IPokerPlayer p)
        {
            lock (m_GamePlayers)
            {
                m_GamePlayers.Add(p.TableId,(RemotePlayer)p);
            }
        }

        public void RemovePlayer(IPokerPlayer p)
        {
            lock (m_GamePlayers)
            {
                if (m_GamePlayers.ContainsKey(p.TableId))
                {
                     m_GamePlayers[p.TableId].EndPokerObserver();
                    m_GamePlayers.Remove(p.TableId);
                }
            }
        }
    }
}

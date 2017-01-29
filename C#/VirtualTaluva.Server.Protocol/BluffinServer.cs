﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Protocol.Lobby;
using VirtualTaluva.Server.Protocol.Workers;
using System.Linq;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Protocol;
using VirtualTaluva.Server.Logic;
using VirtualTaluva.Server.Logic.Extensions;

namespace VirtualTaluva.Server.Protocol
{
    public class BluffinServer : IBluffinServer, IBluffinLobby
    {
        public BlockingCollection<CommandEntry> LobbyCommands { get; }
        public BlockingCollection<GameCommandEntry> GameCommands { get; }

        private readonly LocalTcpServer m_TcpServer;

        private readonly List<string> m_UsedNames = new List<string>();
        private readonly Dictionary<int, PokerGame> m_Games = new Dictionary<int, PokerGame>();

        private int m_LastUsedId;

        public IPokerGame GetGame(int id)
        {
            if (!m_Games.ContainsKey(id))
                return null;
            return m_Games[id];
        }

        public BluffinServer(int port)
        {
            m_TcpServer = new LocalTcpServer(port, this);
            LobbyCommands = new BlockingCollection<CommandEntry>();
            GameCommands = new BlockingCollection<GameCommandEntry>();
        }

        public bool IsNameUsed(string name)
        {
            return m_UsedNames.Any(s => s.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public void AddName(string name)
        {
            m_UsedNames.Add(name);
        }

        public void RemoveName(string name)
        {
            m_UsedNames.Remove(name);
        }

        public void Start()
        {
            Logger.LogInformation("Server started on port {0} !", m_TcpServer.Port);
            Task.Factory.StartNew(new BluffinLobbyWorker(this, this).Start);
            Task.Factory.StartNew(new BluffinGameWorker(this).Start);
            m_TcpServer.Run().Wait();
        }

        public int CreateTable(CreateTableCommand c)
        {
            ListTables();

            m_LastUsedId++;
            while (m_Games.ContainsKey(m_LastUsedId))
                m_LastUsedId++;

            var game = new PokerGame(new PokerTable(c.Params));

            m_Games.Add(m_LastUsedId, game);

            var p = game.Table.Params;
            Logger.LogTableCreated(m_LastUsedId, p);
            Logger.LogGameCreated(m_LastUsedId);
            game.Start();

            return m_LastUsedId;
        }

        public List<TupleTable> ListTables(params LobbyTypeEnum[] lobbyTypes)
        {
            // Remove non-running tables
            m_Games.Where(kvp => !kvp.Value.IsRunning).Select(kvp => kvp.Key).ToList().ForEach(i => m_Games.Remove(i));

            //List Tables
            return (from kvp in m_Games.Where(kvp => kvp.Value.IsRunning)
                let t = kvp.Value.Table
                where lobbyTypes.Length == 0 || lobbyTypes.Contains(t.Params.Lobby.OptionType)
                select new TupleTable()
                {
                    IdTable = kvp.Key, 
                    Params = t.Params, 
                    NbPlayers = t.Seats.Players().Count(), 
                    PossibleAction = LobbyActionEnum.None,
                }).ToList();
        }
    }
}

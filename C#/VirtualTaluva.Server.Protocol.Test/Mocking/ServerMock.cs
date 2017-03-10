using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualTaluva.Protocol;
using VirtualTaluva.Server.Logic;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Protocol.Lobby;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Protocol;
using VirtualTaluva.Server.Protocol.Workers;

namespace VirtualTaluva.Server.Protocol.Test.Mocking
{
    public class ServerMock : IBluffinServer, IBluffinLobby
    {
        private readonly ClientMock m_Client;
        private readonly BluffinLobbyWorker m_Worker;
        public ServerMock()
        {
            GameCommands = new BlockingCollection<GameCommandEntry>();
            LobbyCommands = new BlockingCollection<CommandEntry>();
            ServerSendedCommands = new BlockingCollection<CommandEntry>();
            m_Client = new ClientMock(this);
            m_Worker = new BluffinLobbyWorker(this, this);
            Task.Factory.StartNew(StartWorker);
        }

        private void StartWorker()
        {
            try
            {
                m_Worker.Start();
            }
            finally
            {
                ServerSendedCommands.CompleteAdding();
            }
        }

        public void Send(AbstractCommand c)
        {
            LobbyCommands.Add(new CommandEntry(){Client = m_Client,Command = c});
        }

        public BlockingCollection<CommandEntry> LobbyCommands { get; }
        public BlockingCollection<GameCommandEntry> GameCommands { get; }

        public BlockingCollection<CommandEntry> ServerSendedCommands { get; }

        public bool IsNameUsed(string name)
        {
            return true;
        }

        public void AddName(string name)
        {
            
        }

        public void RemoveName(string name)
        {
        }

        public IPokerGame GetGame(int id)
        {
            return new PokerGame(new PokerTable());
        }

        public List<TupleTable> ListTables(params LobbyTypeEnum[] lobbyTypes)
        {
            return new List<TupleTable>();
        }

        public int CreateTable(CreateTableCommand c)
        {
            return 42;
        }

        public string Identification => GetType().Assembly.FullName;
    }
}

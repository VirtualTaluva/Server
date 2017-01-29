using System;
using VirtualTaluva.Protocol;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Protocol;

namespace VirtualTaluva.Server.Protocol.Test.Mocking
{
    public class ClientMock : IBluffinClient
    {
        private readonly ServerMock m_Server;
        public ClientMock(ServerMock server)
        {
            m_Server = server;
            PlayerName = "SpongeBob";
        }

        public string PlayerName { get; set; }
        public string ClientIdentification { get; set; }
        public Version SupportedProtocol { get; set; }
        public void SendCommand(AbstractCommand command)
        {
            m_Server.ServerSendedCommands.Add(new CommandEntry() { Client = this, Command = command });
        }

        public void AddPlayer(IPokerPlayer p)
        {
            throw new NotImplementedException();
        }

        public void RemovePlayer(IPokerPlayer p)
        {
            throw new NotImplementedException();
        }
    }
}

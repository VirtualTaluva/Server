using System;
using VirtualTaluva.Protocol;

namespace VirtualTaluva.Server.DataTypes.Protocol
{
    public interface IBluffinClient
    {
        string PlayerName { get; set; }
        string ClientIdentification { get; set; }
        Version SupportedProtocol { get; set; }

        void SendCommand(AbstractCommand command);

        void AddPlayer(IPokerPlayer p);
        void RemovePlayer(IPokerPlayer p);
    }
}

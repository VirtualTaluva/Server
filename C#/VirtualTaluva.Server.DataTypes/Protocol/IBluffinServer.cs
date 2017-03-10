using System.Collections.Concurrent;

namespace VirtualTaluva.Server.DataTypes.Protocol
{
    public interface IBluffinServer
    {
        string Identification { get; }
        BlockingCollection<CommandEntry> LobbyCommands { get; }
        BlockingCollection<GameCommandEntry> GameCommands { get; }
    }
}

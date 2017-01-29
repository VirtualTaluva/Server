using System.Collections.Concurrent;

namespace VirtualTaluva.Server.DataTypes.Protocol
{
    public interface IBluffinServer
    {
        BlockingCollection<CommandEntry> LobbyCommands { get; }
        BlockingCollection<GameCommandEntry> GameCommands { get; }
    }
}

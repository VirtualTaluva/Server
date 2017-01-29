using System.Collections.Generic;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Protocol.Lobby;

namespace VirtualTaluva.Server.DataTypes.Protocol
{
    public interface IBluffinLobby
    {
        bool IsNameUsed(string name);
        void AddName(string name);
        void RemoveName(string name);
        IPokerGame GetGame(int id);
        List<TupleTable> ListTables(params LobbyTypeEnum[] lobbyTypes);
        int CreateTable(CreateTableCommand c);
    }
}

using System.Collections.Generic;
using VirtualTaluva.Protocol.DataTypes;

namespace VirtualTaluva.Server.DataTypes
{
    public class PlayerCardHolder : IStringCardsHolder
    {
        public PlayerInfo Player { get; }
        public IEnumerable<string> PlayerCards => Player.Cards;
        public IEnumerable<string> CommunityCards { get; }

        public PlayerCardHolder(PlayerInfo p, IEnumerable<string> communityCards)
        {
            Player = p;
            CommunityCards = communityCards;
        }
    }
}

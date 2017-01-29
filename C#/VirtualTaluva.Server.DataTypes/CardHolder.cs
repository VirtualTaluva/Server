using System.Collections.Generic;
using VirtualTaluva.Protocol.DataTypes;

namespace VirtualTaluva.Server.DataTypes
{
    public interface IStringCardsHolder
    {
        
    }
    public class CardHolder : IStringCardsHolder
    {
        public PlayerInfo Player { get; }
        public IEnumerable<string> PlayerCards { get; }
        public IEnumerable<string> CommunityCards { get; }

        public CardHolder(PlayerInfo p, IEnumerable<string> playerCards, IEnumerable<string> communityCards)
        {
            Player = p;
            PlayerCards = playerCards;
            CommunityCards = communityCards;
        }
    }
}

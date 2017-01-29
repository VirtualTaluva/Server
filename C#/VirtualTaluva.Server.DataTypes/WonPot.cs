using System.Collections.Generic;

namespace VirtualTaluva.Server.DataTypes
{
    public class EvaluatedCardHolder<T> where T : IStringCardsHolder
    {
        
    }
    public class WonPot
    {
        public WonPot(int potId, int totalPotAmount, IEnumerable<KeyValuePair<EvaluatedCardHolder<PlayerCardHolder>, int>> winners)
        {
            PotId = potId;
            TotalPotAmount = totalPotAmount;
            Winners = winners;
        }

        public int PotId { get; }
        public int TotalPotAmount { get; }

        public IEnumerable<KeyValuePair<EvaluatedCardHolder<PlayerCardHolder>, int>> Winners { get; } 
    }
}

using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common;

namespace VirtualTaluva.Server.DataTypes
{
    public class PlayingCard
    {
        public NominalValueEnum V { get; }
        public SuitEnum S { get; }

        public PlayingCard(NominalValueEnum v, SuitEnum s)
        {
            V = v;
            S = s;
        }
    }
    public enum NominalValueEnum
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
    }
    public enum SuitEnum
    {
        Clubs, Diamonds, Hearts, Spades
    }
    public abstract class AbstractDealer
    {
        private Stack<PlayingCard> Deck { get; set; }
        
        public PlayingCard[] DealCards(int nbCards)
        {
            var set = new PlayingCard[nbCards];
            for (int i = 0; i < nbCards; ++i)
                set[i] = Deck.Pop();
            return set;
        }

        public void FreshDeck()
        {
            Deck = GetShuffledDeck();
        }

        public virtual IEnumerable<NominalValueEnum> UsedValues => new[] { NominalValueEnum.Two, NominalValueEnum.Three, NominalValueEnum.Four, NominalValueEnum.Five, NominalValueEnum.Six, NominalValueEnum.Seven, NominalValueEnum.Eight, NominalValueEnum.Nine, NominalValueEnum.Ten, NominalValueEnum.Jack, NominalValueEnum.Queen, NominalValueEnum.King, NominalValueEnum.Ace };
        private IEnumerable<SuitEnum> UsedSuits => new[] { SuitEnum.Clubs, SuitEnum.Diamonds, SuitEnum.Hearts, SuitEnum.Spades };

        private Stack<PlayingCard> GetShuffledDeck()
        {
            var deck = new Stack<PlayingCard>();
            var restantes = GetSortedDeck();
            while (restantes.Count > 0)
            {
                var id = RandomUtil.RandomWithMax(restantes.Count - 1);
                deck.Push(restantes[id]);
                restantes.RemoveAt(id);
            }
            return deck;
        }

        private List<PlayingCard> GetSortedDeck()
        {
            return (from s in UsedSuits from v in UsedValues select new PlayingCard(v, s)).ToList();
        }
    }
}

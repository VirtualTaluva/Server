using System.Linq;
using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public class DealCardsToBoardModule : AbstractGameModule
    {
        private int NbCards { get; }
        public DealCardsToBoardModule(PokerGameObserver o, PokerTable table, int nbCards)
            : base(o, table)
        {
            NbCards = nbCards;
        }

        public override GameStateEnum GameState => GameStateEnum.Playing;

        public override void InitModule()
        {
            if (Table.NoMoreRoundsNeeded)
            {
                RaiseCompleted();
                return;
            }
            
            Table.AddCards(Table.Variant.Dealer.DealCards(NbCards).Select(x => x.ToString()).ToArray());
            RaiseCompleted();
        }
    }
}

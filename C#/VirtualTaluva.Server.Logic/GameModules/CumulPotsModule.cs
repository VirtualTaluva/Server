using System.Linq;
using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.Extensions;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public class CumulPotsModule : AbstractGameModule
    {
        public CumulPotsModule(PokerGameObserver o, PokerTable table)
            : base(o, table)
        {
        }

        public override GameStateEnum GameState => GameStateEnum.Playing;

        public override void InitModule()
        {
            if (Table.NoMoreRoundsNeeded)
            {
                RaiseCompleted();
                return;
            }

            Table.Bank.DepositMoneyInPlay();
            Table.HigherBet = 0;

            Observer.RaiseGameBettingRoundEnded();

            if (Table.Seats.PlayingAndAllInPlayers().Count() <= 1)
                Table.NoMoreRoundsNeeded = true;

            RaiseCompleted();
        }
    }
}

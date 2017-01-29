using System.Linq;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.Extensions;

namespace VirtualTaluva.Server.Logic.GameModules
{
    public class DistributeMoneyModule : AbstractGameModule
    {
        public DistributeMoneyModule(PokerGameObserver o, PokerTable table)
            : base(o, table)
        {
        }

        public override GameStateEnum GameState => GameStateEnum.DistributeMoney;

        public override void InitModule()
        {
            //foreach (var pot in Table.Bank.DistributeMoney(HandEvaluators.Evaluate(Table.Seats.PlayingAndAllInPlayers().Select(x => new PlayerCardHolder(x, Table.Cards)), Table.Variant.EvaluationParms).SelectMany(x => x)))
            //{
            //    foreach (var winner in pot.Winners)
            //    {
            //        Observer.RaisePlayerWonPot(winner.Key, winner.Value, pot.PotId, pot.TotalPotAmount);
            //        WaitALittle(Table.Params.WaitingTimes.AfterPotWon);
            //    }
            //}

            Table.Seats.ClearAllAttributes();
            RaiseCompleted();
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Attributes;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.GameModules;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    [GameVariant(GameSubTypeEnum.FiveCardsDraw)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class FiveCardsDrawVariant : AbstractGameVariant
    {
        protected override int NbCardsInHand => 5;

        public override EvaluationParams EvaluationParms => new EvaluationParams
        {
            //Selector = new OnlyHoleCardsSelector()
        };

        public override IEnumerable<IGameModule> GetModules(PokerGameObserver o, PokerTable t)
        {
            yield return new DealMissingCardsToPlayersModule(o, t, NbCardsInHand);
            yield return new FirstBettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            yield return new DiscardRoundModule(o, t, 0, 5);

            yield return new DealMissingCardsToPlayersModule(o, t, NbCardsInHand);
            yield return new BettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);
        }
    }
}

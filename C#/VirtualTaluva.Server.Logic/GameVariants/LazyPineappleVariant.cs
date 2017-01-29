using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Attributes;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.GameModules;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    [GameVariant(GameSubTypeEnum.LazyPineapple)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class LazyPineappleVariant : AbstractGameVariant
    {
        protected override int NbCardsInHand => 3;

        public override IEnumerable<IGameModule> GetModules(PokerGameObserver o, PokerTable t)
        {
            //Preflop
            yield return new DealMissingCardsToPlayersModule(o, t, NbCardsInHand);
            yield return new FirstBettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            //Flop
            yield return new DealCardsToBoardModule(o, t, 3);
            yield return new BettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            //Turn
            yield return new DealCardsToBoardModule(o, t, 1);
            yield return new BettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            //River
            yield return new DealCardsToBoardModule(o, t, 1);
            yield return new BettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            //Discard 1 to go back to 2 hole cards
            yield return new DiscardRoundModule(o, t, 1, 1);
        }
    }
}

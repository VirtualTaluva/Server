using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Attributes;
using VirtualTaluva.Server.DataTypes.EventHandling;
using VirtualTaluva.Server.Logic.GameModules;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    [GameVariant(GameSubTypeEnum.FiveCardsStud)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class FiveCardsStudVariant : AbstractStudGameVariant
    {
        protected override int NbCardsInHand => 5;

        public override IEnumerable<IGameModule> GetModules(PokerGameObserver o, PokerTable t)
        {
            yield return new DealCardsToPlayersModule(o, t, 1, 1);
            yield return new StudFirstBettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            yield return new DealCardsToPlayersModule(o, t, 0, 1);
            yield return new BettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            yield return new DealCardsToPlayersModule(o, t, 0, 1);
            yield return new BettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);

            yield return new DealCardsToPlayersModule(o, t, 0, 1);
            yield return new BettingRoundModule(o, t);
            yield return new CumulPotsModule(o, t);
        }
    }
}

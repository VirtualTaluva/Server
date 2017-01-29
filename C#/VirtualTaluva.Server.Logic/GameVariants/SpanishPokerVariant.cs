using System.Diagnostics.CodeAnalysis;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes;
using VirtualTaluva.Server.DataTypes.Attributes;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    [GameVariant(GameSubTypeEnum.SpanishPoker)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class SpanishPokerVariant : AbstractLongFlopHoldemGameVariant
    {
        public override EvaluationParams EvaluationParms => new EvaluationParams
        {
            //HandRanker = new FlushBeatsFullHouseHandRanker(),
            //Selector = new Use2Player3CommunitySelector(),
            //UsedCardValues = Dealer.UsedValues.ToArray()
        };

        protected override AbstractDealer GenerateDealer()
        {
            return new Shuffled28HighCardsDealer();
        }
    }
}

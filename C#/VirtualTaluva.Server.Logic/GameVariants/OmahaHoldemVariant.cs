using System.Diagnostics.CodeAnalysis;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.Attributes;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    [GameVariant(GameSubTypeEnum.OmahaHoldem)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class OmahaHoldemVariant : AbstractHoldemGameVariant
    {
        protected override int NbCardsInHand => 4;

        public override EvaluationParams EvaluationParms => new EvaluationParams
        {
            //Selector = new Use2Player3CommunitySelector()
        };
    }
}

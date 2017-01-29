using System.Diagnostics.CodeAnalysis;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.Attributes;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    [GameVariant(GameSubTypeEnum.ThreeCardsHoldem)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ThreeCardsHoldemVariant : AbstractHoldemGameVariant
    {
        protected override int NbCardsInHand => 3;
    }
}

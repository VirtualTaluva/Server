using System.Diagnostics.CodeAnalysis;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Server.DataTypes.Attributes;

namespace VirtualTaluva.Server.Logic.GameVariants
{
    [GameVariant(GameSubTypeEnum.TexasHoldem)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class TexasHoldemVariant : AbstractHoldemGameVariant
    {
      
    }
}

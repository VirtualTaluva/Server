using System.Collections.Generic;
using VirtualTaluva.Server.DataTypes;
using static VirtualTaluva.Server.DataTypes.NominalValueEnum;

namespace VirtualTaluva.Server.Logic
{
    public class Shuffled28HighCardsDealer : AbstractDealer
    {
        public override IEnumerable<NominalValueEnum> UsedValues => new[] { Eight, Nine, Ten, Jack, Queen, King, Ace };
    }
}

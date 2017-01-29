using System;
using VirtualTaluva.Protocol.DataTypes.Enums;

namespace VirtualTaluva.Server.DataTypes.Attributes
{
    public class GameVariantAttribute : Attribute
    {
        public GameSubTypeEnum Variant { get; private set; }

        public GameVariantAttribute(GameSubTypeEnum variant)
        {
            Variant = variant;
        }
    }
}

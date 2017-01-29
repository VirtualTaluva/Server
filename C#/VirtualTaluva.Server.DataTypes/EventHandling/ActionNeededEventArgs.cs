﻿using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.EventHandling;

namespace VirtualTaluva.Server.DataTypes.EventHandling
{
    public class ActionNeededEventArgs : PlayerInfoEventArgs
    {
        public int AmountNeeded { get;}
        public bool CanFold { get; }
        public int MinimumRaiseAmount { get;}
        public int MaximumRaiseAmount { get;}

        public ActionNeededEventArgs(PlayerInfo player, int amountNeeded, bool canFold, int minimumRaiseAmount, int maximumRaiseAmount) : base(player)
        {
            AmountNeeded = amountNeeded;
            CanFold = canFold;
            MinimumRaiseAmount = minimumRaiseAmount;
            MaximumRaiseAmount = maximumRaiseAmount;
        }
    }
}

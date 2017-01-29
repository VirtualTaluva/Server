using System;

namespace VirtualTaluva.Server.DataTypes.EventHandling
{
    public class SuccessEventArg : EventArgs
    {
        public bool Success { get; set; }
    }
}

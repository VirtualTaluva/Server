using System;

namespace VirtualTaluva.Server.DataTypes.EventHandling
{
    public class ModuleEventArg : EventArgs
    {
        public IGameModule Module { get; set; }
    }
}

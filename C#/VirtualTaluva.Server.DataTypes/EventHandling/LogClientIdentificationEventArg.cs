using System;
using VirtualTaluva.Server.DataTypes.Protocol;

namespace VirtualTaluva.Server.DataTypes.EventHandling
{
    public class LogClientEventArg : EventArgs
    {
        public LogClientEventArg(IBluffinClient client)
        {
            Client = client;
        }

        public IBluffinClient Client { get; }
    }
}

﻿using VirtualTaluva.Protocol.DataTypes;

namespace VirtualTaluva.Server.DataTypes.EventHandling
{
    public class LogTableCreationEventArg : LogGameEventArg
    {
        public LogTableCreationEventArg(int id, TableParams p) : base(id)
        {
            Params = p;
        }

        public TableParams Params { get; }
    }
}

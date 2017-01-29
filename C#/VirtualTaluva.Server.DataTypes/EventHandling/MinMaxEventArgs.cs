using System;

namespace VirtualTaluva.Server.DataTypes.EventHandling
{
    public class MinMaxEventArgs : EventArgs
    {
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        public MinMaxEventArgs(int min, int max)
        {
            Minimum = min;
            Maximum = max;
        }
    }
}

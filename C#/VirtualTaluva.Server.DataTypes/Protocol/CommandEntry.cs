using VirtualTaluva.Protocol;

namespace VirtualTaluva.Server.DataTypes.Protocol
{
    public class CommandEntry
    {
        public AbstractCommand Command { get; set; }
        public IBluffinClient Client { get; set; }
    }
}

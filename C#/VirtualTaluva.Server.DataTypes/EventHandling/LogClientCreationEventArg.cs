using System.Net.Sockets;
using VirtualTaluva.Server.DataTypes.Protocol;

namespace VirtualTaluva.Server.DataTypes.EventHandling
{
    public class LogClientCreationEventArg : LogClientEventArg
    {
        public LogClientCreationEventArg(TcpClient endpoint, IBluffinClient client) : base(client)
        {
            Endpoint = endpoint;
        }

        public TcpClient Endpoint { get; }
    }
}

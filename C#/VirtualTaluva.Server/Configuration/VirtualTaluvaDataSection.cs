using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace VirtualTaluva.Server.Configuration
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class VirtualTaluvaDataSection : ConfigurationSection
    {
        public const string NAME = "VirtualTaluva";

        [ConfigurationProperty(LoggingDataSection.NAME, IsRequired = true)]
        public LoggingDataSection Logging => (LoggingDataSection)base[LoggingDataSection.NAME];

        private const string PORT = "port";
        [ConfigurationProperty(PORT, IsRequired = true)]
        public int Port => (int)this[PORT];
    }
}
using System;
using System.Configuration;
using VirtualTaluva.Server.Protocol;
using VirtualTaluva.Server.Configuration;
using VirtualTaluva.Server.Logging;

namespace VirtualTaluva.Server
{
    public static class Program
    {

        private static void Main()
        {
            var config = InitConfiguration();

            ConsoleLogger.Init(config);
            FileLogger.Init(config);
            DbCommandLogger.Init(config);

            StartServer(config);
        }

        private static VirtualTaluvaDataSection InitConfiguration()
        {
            var config = ConfigurationManager.GetSection(VirtualTaluvaDataSection.NAME) as VirtualTaluvaDataSection;
            if (config == null)
                throw new Exception("No configuration found !!!");
            return config;
        }

        private static void StartServer(VirtualTaluvaDataSection config)
        {
            try
            {
                var server = new BluffinServer(config.Port, typeof(Program).Assembly.FullName);
                server.Start();
            }
            catch
            {
                DataTypes.Logger.LogError("Can't start server !!");
            }
        }

    }
}

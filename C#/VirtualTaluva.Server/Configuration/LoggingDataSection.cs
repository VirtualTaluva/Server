﻿using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace VirtualTaluva.Server.Configuration
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class LoggingDataSection : ConfigurationElement
    {
        public const string NAME = "logging";

        [ConfigurationProperty(DbCommandConfigElement.NAME, IsRequired = false, DefaultValue = null)]
        public DbCommandConfigElement DbCommand => (DbCommandConfigElement)base[DbCommandConfigElement.NAME];

        [ConfigurationProperty(ConsoleLoggerConfigElement.NAME, IsRequired = false, DefaultValue = null)]
        public ConsoleLoggerConfigElement Console => (ConsoleLoggerConfigElement)base[ConsoleLoggerConfigElement.NAME];

        [ConfigurationProperty(FileLoggerConfigElement.NAME, IsRequired = false, DefaultValue = null)]
        public FileLoggerConfigElement File => (FileLoggerConfigElement)base[FileLoggerConfigElement.NAME];
    }
}
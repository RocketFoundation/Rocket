﻿using System;
using System.Linq;
using Rocket.API.DependencyInjection;
using Rocket.API.Logging;
using Rocket.Core.ServiceProxies;

namespace Rocket.Core.Logging
{
    public class ProxyLogger : ServiceProxy<ILogger>, ILogger
    {
        public ProxyLogger(IDependencyContainer container) : base(container) { }

        public void Log(string message, LogLevel level = LogLevel.Information, Exception exception = null, ConsoleColor? color = null,
                        params object[] bindings)
        {
            foreach(var service in ProxiedServices)
                service.Log(message, level, exception, color, bindings);
        }

        public bool IsEnabled(LogLevel level)
        {
            return ProxiedServices.Any(c => c.IsEnabled(level));
        }

        public void SetEnabled(LogLevel level, bool enabled)
        {
            throw new NotSupportedException("Not supported on proxy provider.");
        }
    }
}
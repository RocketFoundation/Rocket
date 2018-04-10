using System;
using Rocket.API.Eventing;

namespace Rocket.Core.Events.Plugins
{
    public sealed class PluginsPostLoadedEvent : Event
    {
        internal PluginsPostLoadedEvent(bool global = true) : base(global) { }

        internal PluginsPostLoadedEvent(EventExecutionTargetContext executionTarget = EventExecutionTargetContext.Sync, bool global = true) : base(executionTarget, global) { }

        internal PluginsPostLoadedEvent(string name = null, EventExecutionTargetContext executionTarget = EventExecutionTargetContext.Sync, bool global = true) : base(name, executionTarget, global) { }
    }
}


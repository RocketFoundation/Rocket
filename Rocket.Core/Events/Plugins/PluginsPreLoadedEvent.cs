using System;
using Rocket.API.Eventing;

namespace Rocket.Core.Events.Plugins
{
    public sealed class PluginsPreLoadedEvent : Event
    {
        internal PluginsPreLoadedEvent(bool global = true) : base(global) { }

        internal PluginsPreLoadedEvent(EventExecutionTargetContext executionTarget = EventExecutionTargetContext.Sync, bool global = true) : base(executionTarget, global) { }

        internal PluginsPreLoadedEvent(string name = null, EventExecutionTargetContext executionTarget = EventExecutionTargetContext.Sync, bool global = true) : base(name, executionTarget, global) { }
    }
}

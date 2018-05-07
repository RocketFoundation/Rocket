﻿using Rocket.API.Eventing;
using Rocket.API.Player;

namespace Rocket.Core.Player.Events
{
    public class PlayerDisconnectedEvent : OnlinePlayerEvent
    {
        public PlayerDisconnectedEvent(IOnlinePlayer player) : base(player)
        {
            Reason = null;
        }

        public PlayerDisconnectedEvent(IOnlinePlayer player, string reason = null) : base(player)
        {
            Reason = reason;
        }

        public PlayerDisconnectedEvent(IOnlinePlayer player, string reason = null, bool global = true) : base(player,
            global)
        {
            Reason = reason;
        }

        public PlayerDisconnectedEvent(IOnlinePlayer player, string reason = null,
                                       EventExecutionTargetContext executionTarget = EventExecutionTargetContext.Sync,
                                       bool global = true) : base(player, executionTarget, global)
        {
            Reason = reason;
        }

        public PlayerDisconnectedEvent(IOnlinePlayer player, string reason = null, string name = null,
                                       EventExecutionTargetContext executionTarget = EventExecutionTargetContext.Sync,
                                       bool global = true) : base(player, name, executionTarget, global)
        {
            Reason = reason;
        }

        public string Reason { get; }
    }
}
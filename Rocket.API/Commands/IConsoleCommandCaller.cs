﻿namespace Rocket.API.Commands
{
    /// <summary>
    ///     This <see cref="ICommandCaller">command caller</see> is used when executing commands from console.
    ///     <para>Altough plugins could use it to call commands programatically, it is recommended that they implement their own
    ///     command caller.</para>
    /// </summary>
    public interface IConsoleCommandCaller : ICommandCaller { }
}
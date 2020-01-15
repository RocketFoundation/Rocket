﻿using Rocket.API.User;

namespace Rocket.API.Player
{
    public interface IPlayerUser : IUser
    {
        IPlayer Player { get; }
    }

    public interface IPlayerUser<out TPlayer> : IPlayerUser where TPlayer: IPlayer
    {
        new TPlayer Player { get; }
    }
}
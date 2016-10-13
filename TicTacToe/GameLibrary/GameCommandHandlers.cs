namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Messaging;
    using Styx.Diagnostics;

    /// <summary>
    /// 
    /// </summary>
    public class GameCommandHandlers : IHandler<GameCommands.RegisterPlayer>
    {
        private readonly Game _game;

        public GameCommandHandlers(Game game)
        {
            Argument.ThrowIfNull(game, nameof(game));
            this._game = game;
        }

        public void Handle(GameCommands.RegisterPlayer command)
        {
            this._game.RegisterPlayer(command.Player);
        }
    }

    public static class GameCommands
    {
        public class RegisterPlayer : Command
        {
            public RegisterPlayer(Players.Player player)
            {
                Argument.ThrowIfNull(player, nameof(player));
                Player = player;
            }

            public Players.Player Player { get; }
        }
    }
}

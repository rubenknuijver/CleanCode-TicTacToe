namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GamePlayers;
    using Styx.Diagnostics;

    /// <summary>
    /// We just like to play a Game.
    /// </summary>
    public class Game
    {
        private HashSet<GameLibrary.Players.Player> _players = new HashSet<GameLibrary.Players.Player>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="maxPlayers">Maximum number of Players</param>
        /// <param name="maxRounds">Maximum number of GameRounds</param>
        public Game(int maxPlayers = 2, int maxRounds = 3)
        {
            Argument.Validate(maxPlayers >= 0, nameof(maxPlayers));
            Argument.Validate(maxRounds >= 0, nameof(maxRounds));

            this.MaxRounds = maxRounds;
            this.MaxPlayers = maxPlayers;
        }

        /// <summary>
        /// Gets or sets the currently active GameRound.
        /// </summary>
        public GameRound CurrentGameRound
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets all available players for the game.
        /// </summary>
        public IReadOnlyCollection<GameLibrary.Players.Player> Players
        {
            get { return this._players; }
        }

        /// <summary>
        /// Gets the maximum number of GameRounds the game is played in.
        /// </summary>
        public int MaxRounds { get; }

        /// <summary>
        /// Gets the maximum number of Players that cab\n play the game.
        /// </summary>
        public int MaxPlayers { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanRegisterPlayers() => this._players.Count < this.MaxPlayers;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void RegisterPlayer(GameLibrary.Players.Player player)
        {
            Argument.ThrowIfNull(player, nameof(player));

            if (this.Players.Count == this.MaxPlayers) {
                throw ExceptionFactory.PlayerMaximum(this.MaxPlayers);
            }

            if (this._players.Contains(player)) {
                throw ExceptionFactory.DuplicatePlayer(player);
            }

            this._players.Add(player);
        }

        public void StartNew()
        {
            this.CurrentGameRound = new GameRound(this.Players.ToArray());
        }
    }

    public class RegisterPlayerCommand
    {
        public RegisterPlayerCommand(GameLibrary.Players.Player player)
        {
            Argument.ThrowIfNull(player, nameof(player));
            Player = player;
        }

        public GameLibrary.Players.Player Player { get; }
    }

    public class PlayerTakesTurnCommand
    {
        public PlayerTakesTurnCommand(GameLibrary.Players.Player player, Board.BoardCoordinate coordinate )
        {
            Argument.ThrowIfNull(player, nameof(player));

            Coordinate = coordinate;
            Player = player;
        }

        public GameLibrary.Players.Player Player { get; }
        public Board.BoardCoordinate Coordinate { get;  }
    }

    public class PlayerWithdrawTurnCommand
    {
        public PlayerWithdrawTurnCommand(GameLibrary.Players.Player player)
        {
            Argument.ThrowIfNull(player, nameof(player));

            Player = player;
        }

        public GameLibrary.Players.Player Player { get; }
    }
}

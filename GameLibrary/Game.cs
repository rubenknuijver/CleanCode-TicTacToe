namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Board;
    using Styx.Diagnostics;
    using Utils;

    /// <summary>
    /// We just like to play a Game.
    /// </summary>
    public class Game
    {
        private BindingList<Players.Player> _players = new BindingList<Players.Player>();
        private BindingList<GameRound> _previousRounds = new BindingList<GameRound>();
        private HashSet<GameRule> _gameRules = new HashSet<GameRule>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="board">To play the game we need a Board <see cref="GameBoard"/></param>
        /// <param name="maxPlayers">Maximum number of Players</param>
        /// <param name="maxRounds">Maximum number of GameRounds</param>
        public Game(IBus bus, GameBoard board, int maxPlayers = 2, int maxRounds = 3)
        {
            Argument.ThrowIfNull(bus, nameof(bus));
            Argument.Validate(maxPlayers >= 0, nameof(maxPlayers));
            Argument.Validate(maxRounds >= 0, nameof(maxRounds));

            this.Bus = bus;
            this.MaxRounds = maxRounds;
            this.MaxPlayers = maxPlayers;
            this.Board = board;
        }

        public IBus Bus { get; }

        public GameBoard Board { get; }

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
        public BindingList<Players.Player> Players
        {
            get { return this._players; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BindingList<GameRound> PreviousRounds
        {
            get { return this._previousRounds; }
        }

        public ICollection<GameRule> Rules => this._gameRules;

        /// <summary>
        /// Gets or sets the maximum number of GameRounds the game is played in.
        /// </summary>
        public int MaxRounds { get; set; }

        /// <summary>
        /// Gets the maximum number of Players that cab\n play the game.
        /// </summary>
        public int MaxPlayers { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadyForAction => !this.CanRegisterPlayers || this.CurrentGameRound != null;

        /// <summary>
        /// Gets a value indicating whether 
        /// </summary>
        /// <returns></returns>
        public bool CanRegisterPlayers => this._players.Count < this.MaxPlayers;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void RegisterPlayer(Players.Player player)
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

        /// <summary>
        /// Resets the game back to initial state
        /// </summary>
        /// <param name="all">to include players and round history</param>
        public void Reset(bool all)
        {
            if (all) {
                this._players.Clear();
                this._previousRounds.Clear();
            }

            this.CurrentGameRound = null;
            this.Board.Clear();
        }

        /// <summary>
        /// Prepare a GameRound with players end the board
        /// </summary>
        /// <returns>false if the game isn't ready to get played</returns>
        public bool PrepareGameRound()
        {
            if (this.CurrentGameRound != null && this.CurrentGameRound.IsCompleted) {
                this.PreviousRounds.Add(this.CurrentGameRound);
            }

            this.Reset(false);

            if (this.IsReadyForAction) {
                this.CurrentGameRound = new GameRound(this.Bus, this.Board, this.Players);
                return true;
            }

            return false;
        }

        public void ProcessRules()
        {
            foreach (var rule in this.Rules) {
                rule.Handle(this.Board, this.CurrentGameRound);
            }
        }
    }

    /* Maybe later
     * 
    public class RegisterPlayerCommand
    {
        public RegisterPlayerCommand(Players.Player player)
        {
            Argument.ThrowIfNull(player, nameof(player));
            Player = player;
        }

        public Players.Player Player { get; }
    }

    public class PlayerTakesTurnCommand
    {
        public PlayerTakesTurnCommand(Players.Player player, Board.BoardCoordinate coordinate )
        {
            Argument.ThrowIfNull(player, nameof(player));

            Coordinate = coordinate;
            Player = player;
        }

        public Players.Player Player { get; }
        public Board.BoardCoordinate Coordinate { get;  }
    }

    public class PlayerWithdrawTurnCommand
    {
        public PlayerWithdrawTurnCommand(Players.Player player)
        {
            Argument.ThrowIfNull(player, nameof(player));

            Player = player;
        }

        public Players.Player Player { get; }
    }
    */
}

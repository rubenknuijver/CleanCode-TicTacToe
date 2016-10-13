namespace GameLibrary.Rounds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;
    using Players;
    using Styx.Diagnostics;
    using Utils;

    /// <summary>
    /// Game is played in rounds
    /// </summary>
    public class GameRound
    {
        private readonly GameBoard _board;
        private readonly Messaging.IBus _bus;
        private readonly RoundRobinList<Player> _players;

        private IPlayerTurn _currentTurn;
        private bool _isCompleted;
        private Player _winner;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRound"/> class.
        /// </summary>
        /// <param name="bus">Event Message Bus</param>
        /// <param name="board">The board we play on</param>
        /// <param name="players">Selected player for this round</param>
        public GameRound(Messaging.IBus bus, GameBoard board, params Player[] players)
            : this(bus, board, players.AsEnumerable())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRound"/> class.
        /// </summary>
        /// <param name="bus">Event Message Bus</param>
        /// <param name="board">The board we play on</param>
        /// <param name="players">Selected player for this round</param>
        public GameRound(Messaging.IBus bus, GameBoard board, IEnumerable<Player> players)
        {
            Argument.ThrowIfNull(bus, nameof(bus));
            Argument.ThrowIfNull(board, nameof(board));
            Argument.Validate(players.Count() > 1, nameof(players));

            this._bus = bus;
            this._board = board;
            this._players = new RoundRobinList<Player>(players);
        }

        /// <summary>
        /// 
        /// </summary>
        public void End()
        {
            if (this.HasStarted) {
                this.IsCompleted = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool NextTurn()
        {
            if (this.CurrentTurn.IsDone && !this.IsCompleted) {
                this.CurrentTurn = new PlayerTurn(this._players.First());
                return true;
            }

            return false;
        }

        public void SetWinner(Player player)
        {
            if ((this.HasStarted || this.IsCompleted) && this.Winner == null) {
                this.Winner = player;
            }
        }

        public void Start()
        {
            this.CurrentTurn = new PlayerTurn(this._players.First());
        }

        public IPlayerTurn TakeTurn(BoardCoordinate coordinate)
        {
            var turn = this.CurrentTurn;

            if (this.HasStarted && !this.IsCompleted) {
                this._board.OccupyCell(turn.Player, coordinate);
                this.CurrentTurn.Complete(coordinate);
            }

            return turn;
        }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public IPlayerTurn CurrentTurn
        {
            get
            {
                return this._currentTurn;
            }

            protected set
            {
                if (this._currentTurn == value) {
                    return;
                }

                this._currentTurn = value;
                this._bus.RaiseEvent(new Messaging.Events.GameRoundTurnChanged(this));
            }
        }

        public bool HasStarted => this.CurrentTurn != null;

        public bool IsCompleted
        {
            get
            {
                return this._isCompleted;
            }

            protected set
            {
                if (this._isCompleted == value) {
                    return;
                }

                this._isCompleted = value;
                this._bus.RaiseEvent(new Messaging.Events.GameRoundCompleted(this));
            }
        }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public Player Winner
        {
            get
            {
                return this._winner;
            }

            protected set
            {
                if (this._winner == value) {
                    return;
                }

                this._winner = value;
                this._bus.RaiseEvent(new Messaging.Events.GameRoundWinnerAnnounced(this));
                this.End();
            }
        }
    }
}

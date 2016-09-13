namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GamePlayers;
    using Utils;

    /// <summary>
    /// Game is played in rounds
    /// </summary>
    public class GameRound
    {
        private readonly RoundRobinList<Player> _players;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRound"/> class.
        /// </summary>
        /// <param name="players">Selected player for this round</param>
        public GameRound(Player[] players)
        {
            this._players = new RoundRobinList<Player>(players);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRound"/> class.
        /// </summary>
        /// <param name="players">Selected player for this round</param>
        public GameRound(IEnumerable<Player> players)
        {
            this._players = new RoundRobinList<Player>(players);
        }

        public CommandManager TurnStack { get; } = new CommandManager();

        public IPlayerTurn CurrentTurn
        {
            get;
            protected set;
        }

        public Player Winner
        {
            get;
            protected set;
        }

        public void Start()
        {
            this.CurrentTurn = new PlayerTurn(this._players.First());
        }

        public void Update()
        {
        }
    }
}

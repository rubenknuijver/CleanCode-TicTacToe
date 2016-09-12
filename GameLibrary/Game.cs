namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GamePlayers;

    public class Game
    {
        private HashSet<Player> _players = new HashSet<Player>();

        public Game(int maxPlayers = 2)
        {
            this.MaxPlayers = maxPlayers;
        }

        public GameRound CurrentRound
        {
            get;
            protected set;
        }

        public IReadOnlyCollection<Player> Players
        {
            get { return this._players; }
        }

        public int MaxPlayers { get; }

        public void RegisterPlayer(Player player)
        {
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
            this.CurrentRound = new GameRound(this.Players.ToArray());
        }
    }
}

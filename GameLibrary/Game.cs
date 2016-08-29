using GameLibrary.GamePlayers;
using GameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Game
    {
        private HashSet<Player> _players = new HashSet<Player>();

        public GameRound CurrentRound
        {
            get;
            protected set;
        }

        public IReadOnlyCollection<Player> Players
        {
            get { return _players; }
        }

        public int MaxPlayers { get; }

        public Game(int maxPlayers = 2)
        {
            this.MaxPlayers = maxPlayers;
        }

        public void RegisterPlayer(Player player)
        {
            if (Players.Count == MaxPlayers)
                throw ExceptionFactory.PlayerMaximum(MaxPlayers);

            if (_players.Contains(player))
                throw ExceptionFactory.DuplicatePlayer(player);

            _players.Add(player);
        }

        public void StartNew()
        {
            CurrentRound = new GameRound(Players.ToArray());
        }
    }
}

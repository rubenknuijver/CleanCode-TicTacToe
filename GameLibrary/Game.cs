using GameLibrary.Gamer;
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

        public Gameround CurrentRound
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
                throw new PlayerMaximumException(MaxPlayers);

            if (_players.Contains(player))
                throw new DuplicatePlayerException(player);

            _players.Add(player);
        }

        public void StartNew()
        {
            CurrentRound = new Gameround(Players.ToArray());
        }
    }
}

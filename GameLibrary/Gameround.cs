using GameLibrary.Gamer;
using GameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary
{
    public class Gameround
    {
        private readonly RoundRobinList<Player> _players;

        public CommandManager TurnStack { get; } = new CommandManager();

        public IPlayerTurn CurrentPlayer
        {
            get;
            protected set;
        }

        public Player Winner
        {
            get;
            protected set;
        }

        public Gameround(Player[] players)
        {
            _players = new RoundRobinList<Player>(players);
        }

        public Gameround(IEnumerable<Player> players)
        {
            _players = new RoundRobinList<Player>(players);
        }

        public void Start()
        {
            CurrentPlayer = new PlayerTurn(_players.First());
        }
    }
}

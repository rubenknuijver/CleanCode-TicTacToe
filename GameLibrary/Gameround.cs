using GameLibrary.Gamer;
using GameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary
{
    public class GameRound
    {
        private readonly RoundRobinList<Player> _players;

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

        public GameRound(Player[] players)
        {
            _players = new RoundRobinList<Player>(players);
        }

        public GameRound(IEnumerable<Player> players)
        {
            _players = new RoundRobinList<Player>(players);
        }

        public void Start()
        {
            CurrentTurn = new PlayerTurn(_players.First());
        }

        public void Update()
        {
            
        }
    }
}

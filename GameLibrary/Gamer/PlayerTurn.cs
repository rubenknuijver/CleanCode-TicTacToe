using GameLibrary.Gamer;
using GameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Gamer
{
    public class PlayerTurn : ICommand, IPlayerTurn
    {
        public DateTime Start
        {
            get;
            private set;
        }

        public Player Player
        {
            get;
            private set;
        }

        public PlayerTurn(Player player)
            : this(player, DateTime.Now)
        {

        }
        public PlayerTurn(Player player, DateTime start)
        {
            Player = player;
            Start = start;
        }

        public void Execute()
        {

        }

        public void Undo()
        {

        }
    }
}

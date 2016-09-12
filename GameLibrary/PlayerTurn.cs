namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GamePlayers;
    using Utils;

    public class PlayerTurn : ICommand, IPlayerTurn
    {
        public PlayerTurn(Player player)
            : this(player, DateTime.Now)
        {
        }

        public PlayerTurn(Player player, DateTime start)
        {
            this.Player = player;
            this.Start = start;
        }

        /// <inheritdoc/>
        public DateTime Start
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public Player Player
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            this.Take();
        }

        /// <inheritdoc/>
        public void Undo()
        {
        }

        /// <inheritdoc/>
        public void Take()
        {
        }
    }
}

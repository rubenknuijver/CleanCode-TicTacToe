namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Players;
    using Utils;

    /// <summary>
    /// The Game rounds are played in turns
    /// </summary>
    public class PlayerTurn : ICommand, IPlayerTurn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerTurn"/> class.
        /// </summary>
        /// <param name="player">The player taking the turn</param>
        public PlayerTurn(Player player)
            : this(player, DateTime.Now)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerTurn"/> class.
        /// </summary>
        /// <param name="player">The player taking the turn</param>
        /// <param name="start">Timestamp override</param>
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

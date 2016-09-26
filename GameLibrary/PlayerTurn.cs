namespace GameLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Players;
    using Utils;
    using Board;

    /// <summary>
    /// The Game rounds are played in turns
    /// </summary>
    public class PlayerTurn : IPlayerTurn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerTurn"/> class.
        /// </summary>
        /// <param name="player">The player taking the turn</param>
        public PlayerTurn(Player player)
        {
            this.Player = player;
        }

        /// <inheritdoc/>
        public Player Player
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public bool IsDone
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public bool IsWaiting => !this.IsDone;

        public BoardCoordinate Coordinate
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        public bool Complete(BoardCoordinate coordinate)
        {
            this.Coordinate = coordinate;
            return this.IsDone = true;
        }
    }
}

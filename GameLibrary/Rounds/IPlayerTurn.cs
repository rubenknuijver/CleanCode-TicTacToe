namespace GameLibrary.Rounds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;

    public interface IPlayerTurn
    {
        /// <summary>
        /// Gets a value indicating whether the Turn has Completed
        /// </summary>
        bool IsDone { get; }

        /// <summary>
        /// Gets a value indicating whether Turn is Waiting on player action
        /// </summary>
        bool IsWaiting { get; }

        /// <summary>
        /// Gets the Player taking this Turn
        /// </summary>
        Players.Player Player { get; }

        /// <summary>
        /// 
        /// </summary>
        BoardCoordinate Coordinate { get; }

        /// <summary>
        /// Stop the timer
        /// </summary>
        bool Complete(BoardCoordinate coordinate);
    }
}

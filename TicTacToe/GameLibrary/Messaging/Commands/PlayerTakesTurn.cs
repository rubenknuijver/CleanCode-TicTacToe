namespace GameLibrary.Messaging.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;

    public class PlayerTakesTurn : Command
    {
        public PlayerTakesTurn(BoardCoordinate coordinate)
        {
            this.Coordinate = coordinate;
        }

        public BoardCoordinate Coordinate { get; }
    }
}

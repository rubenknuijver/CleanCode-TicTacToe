namespace GameLibrary.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Messaging;
    using Styx.Diagnostics;

    public class GameBoardCommandHandlers
    {
        private readonly GameBoard _board;

        public GameBoardCommandHandlers(GameBoard board)
        {
            this._board = board;
        }

    }

    public class PlayerTakesTurnCommand
    {
        public PlayerTakesTurnCommand(Players.Player player, Board.BoardCoordinate coordinate)
        {
            Argument.ThrowIfNull(player, nameof(player));

            Coordinate = coordinate;
            Player = player;
        }

        public Players.Player Player { get; }
        public Board.BoardCoordinate Coordinate { get; }
    }

    public class PlayerWithdrawTurnCommand
    {
        public PlayerWithdrawTurnCommand(Players.Player player)
        {
            Argument.ThrowIfNull(player, nameof(player));

            Player = player;
        }

        public Players.Player Player { get; }
    }

}

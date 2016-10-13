namespace GameLibrary.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;
    using Rounds;

    public class TicTacToe_WinningMoveRule : GameRule
    {
        public override void Handle(GameBoard board, GameRound round)
        {
            round.SetWinner(TicTacToe.DoWeHaveAWinner(board.ToArray()));
        }
    }
}

namespace GameLibrary.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;
    using Rounds;

    public class TicTacToe_CanStillTakeTurnsRule : GameRule
    {
        public override void Handle(GameBoard board, GameRound round)
        {
            if (board.All(p => !p.IsEmpty)) {
                round.End();
            }
        }
    }
}

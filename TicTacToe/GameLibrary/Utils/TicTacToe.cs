namespace GameLibrary.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;

    public static class TicTacToe
    {
        private static readonly int[,] _matches = {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        private static int[][][] _goodStart = {
            new int[][] { new int[] { 4 }, new int[] { 0, 2, 6, 8 } },
            new int[][] { new int[] { 1 }, new int[] { 6, 8 }, new int[] { 0, 2 } },
            new int[][] { new int[] { 7 }, new int[] { 0, 2 }, new int[] { 6, 8 } },
            new int[][] { new int[] { 0 }, new int[] { 4, 8, 6, 2 } }
        };

        /// <summary>
        /// When all possible combinations to win are taken, the game is over.
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        public static bool CheckForGameOver(Cell[] cells)
        {
            var player = DoWeHaveAWinner(cells);
            if (player != null) {
                return true;
            }

            return cells.All(p => !p.IsEmpty);
        }

        public static Players.Player DoWeHaveAWinner(Cell[] cells)
        {
            for (int i = 0; i < cells.Length - 1; i++) {
                int a = _matches[i, 0],
                    b = _matches[i, 1],
                    c = _matches[i, 2];

                Cell b1 = cells[a],
                    b2 = cells[b],
                    b3 = cells[c];

                if (b1.IsEmpty || b2.IsEmpty || b3.IsEmpty) { // if one if blank
                    continue;    // try another -- no need to go further
                }

                if (b1.Occupant == b2.Occupant && b2.Occupant == b3.Occupant) {
                    return b1.Occupant;
                }
            }

            return default(Players.Player);
        }
    }

    public abstract class GameRule
    {
        public abstract void Handle(GameBoard board, GameLibrary.Rounds.GameRound round);
    }

    public class TicTacToe_CanStillTakeTurnsRule : GameRule
    {
        public override void Handle(GameBoard board, GameLibrary.Rounds.GameRound round)
        {
            if (board.All(p => !p.IsEmpty)) {
                round.End();
            }
        }
    }

    public class TicTacToe_WinningMoveRule : GameRule
    {
        public override void Handle(GameBoard board, GameLibrary.Rounds.GameRound round)
        {
            round.SetWinner(TicTacToe.DoWeHaveAWinner(board.ToArray()));
        }
    }
}

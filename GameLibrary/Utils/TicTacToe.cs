namespace GameLibrary.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Board;
    using GamePlayers;

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
        /// When all posible combinations to win are taken, the game is over.
        /// </summary>
        /// <param name="cells"></param>
        /// <returns></returns>
        public static bool CheckForGameover(Cell[] cells)
        {
            int count = 0;
            for (int i = 0; i < cells.Length; i++) {
                var cell = cells[i];
                if (!cell.IsEmpty) {
                    ++count;
                }
            }

            if (!(count < cells.Length - 1)) {
                return true;
            }

            var player = DoWeHaveAWinner(cells);
            if (player != null) {
                return true;
            }

            return false;
        }

        public static Player DoWeHaveAWinner(Cell[] cells)
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

                if (b1.Owner == b2.Owner && b2.Owner == b3.Owner) {
                    return b1.Owner;
                }
            }

            return default(Player);
        }
    }
}

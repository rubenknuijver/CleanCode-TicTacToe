using GameLibrary.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Utils
{
    public class TicTacToeUtils
    {
        static int[,] _matches = new int[,] {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };

        static int[][][] _goodStart = new int[][][] {
            new int[][]  {new int[]{4} ,new int[]{0,2,6,8}},
            new int[][]  {new int[]{1} ,new int[]{6,8} ,new int[]{0,2}},
            new int[][]  {new int[]{7} ,new int[]{0,2} ,new int[]{6,8}},
            new int[][]  {new int[]{0} ,new int[]{4,8,6,2}}
        };

        public static bool CheckForGameover(Cell[] cells)
        {
            bool gameOver = false;
            for (int i = 0; i < 8; i++) {
                int a = _matches[i, 0],
                    b = _matches[i, 1],
                    c = _matches[i, 2];

                Cell b1 = cells[a],
                    b2 = cells[b],
                    b3 = cells[c];

                if (b1.Owner == null || b2.Owner == null || b3.Owner == null) // if one if blank
                    continue;    // try another -- no need to go further

                if (b1.Owner == b2.Owner && b2.Owner == b3.Owner) {
                    gameOver = true;
                    break;  // don't bother to continue
                }
            }
            return gameOver;
        }
    }
}

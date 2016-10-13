namespace GameLibrary.Board
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Styx.Diagnostics;

    public class BoardSize
    {
        public BoardSize(int rows, int columns)
        {
            Enforce.ArgumentGreaterThanZero(rows, "BoardSize can't have less than 1 row");
            Enforce.ArgumentGreaterThanZero(columns, "BoardSize can't have less than 1 column");
            //Argument.Validate(columns >= 0, nameof(columns));
            //Argument.Validate(rows >= 0, nameof(rows));

            this.Columns = columns;
            this.Rows = rows;
        }

        /// <summary>
        /// Gets the Row boundary size
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Gets the Column boundary size
        /// </summary>
        public int Columns { get; }

        public static implicit operator int(BoardSize size)
        {
            return size.Rows * size.Columns;
        }
    }
}

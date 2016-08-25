using GameLibrary.Board;
using GameLibrary.Gamer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Tests
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void Can_Tell_If_All_Cells_Are_Empty()
        {
            GameBoard board = new GameBoard(3, 3);
            board.Initialize();

            int cellsThatAreNotTaken = board.AsEnumerable()
                .Empty()
                .Count();

            Assert.IsTrue(board.AsEnumerable().Count() == cellsThatAreNotTaken);
        }

        [TestMethod]
        public void Should_Exclude_Spaces_Taken_From_EmptyCells()
        {
            GameBoard board = new GameBoard(3, 3);
            board.Initialize();

            board[new BoardCoordinate(2, 2)].Owner = new HumanPlayer("John Dow");

            int cellsThatAreNotTaken = board.AsEnumerable()
                .Empty()
                .Count();

            int expectedCount = board.AsEnumerable().Count() - 1;

            Assert.IsTrue(expectedCount == cellsThatAreNotTaken);
        }

        [TestMethod]
        public void Coordinate_Should_Away_be_on_the_board()
        {
            GameBoard board = new GameBoard(3, 3);
            board.Initialize();

            GameLibrary.Tests.ExtendedAssert.Throws<ArgumentOutOfRangeException>(() => {
                board.OccupyCell(new HumanPlayer("Donnie"), new BoardCoordinate(10, 10));
            });
        }
    }
}

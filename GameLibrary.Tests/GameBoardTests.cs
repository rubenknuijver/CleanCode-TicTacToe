using GameLibrary.Board;
using GameLibrary.GamePlayers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Tests;
using GameLibrary.Utils;

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

            ExtendedAssert.Throws<ArgumentOutOfRangeException>(() => {
                board.OccupyCell(new HumanPlayer("Donnie"), new BoardCoordinate(10, 10));
            });
        }

        [TestMethod]
        public void GameOver_if_no_empty_cells_are_left()
        {
            GameBoard board = new GameBoard(3, 3);
            //board.LoadFromHistory();

            board.Initialize();

            for (int i = 0; i < 7; i++) {
                var player = new ArtificialIntelligencePlayer();

                var pos = BoardCoordinate.FromBoardIndex(board, i);
                board.OccupyCell(player, pos);

                var cells = board.ToArray();
                var state = TicTacToe.CheckForGameover(cells);

                Assert.IsFalse(state);
            }

            {
                var player = new ArtificialIntelligencePlayer();
                var pos = BoardCoordinate.FromBoardIndex(board, 8);
                board.OccupyCell(player, pos);

                var cells = board.ToArray();
                var state = TicTacToe.CheckForGameover(cells);

                Assert.IsTrue(state);
            }
        }

        [TestMethod]
        public void GameOver_if_all_winning_combination_are_taken()
        {
            var player = new HumanPlayer("Donnie");

            GameBoard board = new GameBoard(3, 3);
            //board.LoadFromHistory();

            foreach (var winner in WinningSets()) {
                board.Initialize();

                foreach (var index in winner) {
                    var pos = BoardCoordinate.FromBoardIndex(board, index);
                    board.OccupyCell(player, pos);
                }
                var cells = board.ToArray();
                var state = TicTacToe.CheckForGameover(cells);

                Assert.IsTrue(state);
            }
        }

        [TestMethod]
        public void And_the_winner_is()
        {
            var player = new HumanPlayer("Donnie");

            GameBoard board = new GameBoard(3, 3);
            //board.LoadFromHistory();

            foreach (var winningCombination in WinningSets()) {
                board.Initialize();

                foreach (var index in winningCombination) {
                    var pos = BoardCoordinate.FromBoardIndex(board, index);
                    board.OccupyCell(player, pos);
                }

                var cells = board.ToArray();
                var winner = TicTacToe.DoWeHaveAWinner(cells);

                Assert.IsNotNull(winner);
            }
        }

        public static IEnumerable<int[]> WinningSets()
        {
            yield return new[] { 0, 1, 2 };
            yield return new[] { 3, 4, 5 };
            yield return new[] { 6, 7, 8 };
            yield return new[] { 0, 3, 6 };
            yield return new[] { 1, 4, 7 };
            yield return new[] { 2, 5, 8 };
            yield return new[] { 0, 4, 8 };
            yield return new[] { 2, 4, 6 };
        }
    }
}

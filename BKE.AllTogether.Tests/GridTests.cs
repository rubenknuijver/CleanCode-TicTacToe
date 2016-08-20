using GameLibrary.Board;
using GameLibrary.Gamer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKE.AllTogether.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void Can_Tell_If_All_Cells_Are_Empty()
        {
            Grid grid = new Grid(3, 3);
            grid.Initialize();

            int cellsThatAreNotTaken = grid.AsEnumerable()
                .AllEmpty()
                .Count();

            Assert.IsTrue(grid.AsEnumerable().Count() == cellsThatAreNotTaken);
        }

        [TestMethod]
        public void Should_Exclude_Spaces_Taken_From_EmptyCells()
        {
            Grid grid = new Grid(3, 3);
            grid.Initialize();

            grid[2, 2].Owner = new HumanPlayer("John Dow");

            int cellsThatAreNotTaken = grid.AsEnumerable()
                .AllEmpty()
                .Count();

            int expectedCount = grid.AsEnumerable().Count() - 1;

            Assert.IsTrue(expectedCount == cellsThatAreNotTaken);
        }
    }
}

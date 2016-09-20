using GameLibrary.GamePlayers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Tests
{
    [TestClass]
    public class HumanPlayerTests : PlayerBaseTests
    {
        protected override Players.Player CreatePlayer(string name)
        {
            return new Players.HumanPlayer(name);
        }

        [TestMethod]
        public void Should_Equal_By_Reference_Only_If_Names_Are_Equal()
        {
            var player1 = new Players.HumanPlayer("Donnie");
            var player2 = new Players.HumanPlayer("Donnie");

            Assert.AreEqual(player1, player2);
        }
    }
}

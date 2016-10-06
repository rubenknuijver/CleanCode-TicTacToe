using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Tests
{
    [TestClass]
    public class ArtificialIntelligencePlayerTests : PlayerBaseTests
    {
        protected override Players.Player CreatePlayer(string name)
        {
            return new Players.ArtificialIntelligencePlayer();
        }

        [TestMethod]
        public void Should_Have_Different_Name_On_NewInstances()
        {
            var player1 = new Players.ArtificialIntelligencePlayer();
            var player2 = new Players.ArtificialIntelligencePlayer();

            Assert.AreNotEqual(player1, player2);
            Assert.AreNotSame(player1, player2);
        }
    }
}

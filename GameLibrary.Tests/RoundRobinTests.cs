using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLibrary.Utils;
using GameLibrary.Players;
using System.Linq;

namespace GameLibrary.Tests
{
    [TestClass]
    public class RoundRobinTests
    {
        [TestMethod]
        public void First_Is_Always_the_next_Player()
        {
            var list = new RoundRobinList<Player>(
                new ArtificialIntelligencePlayer(),
                new ArtificialIntelligencePlayer(),
                new ArtificialIntelligencePlayer()
                );

            var p1 = list.First();
            var p2 = list.First();

            Assert.AreNotSame(p1, p2);
        }

        [TestMethod]
        public void First_Is_Always_the_next_Player2()
        {
            var list = new RoundRobinList<Player>(
                new HumanPlayer("Jesus"),
                new HumanPlayer("Donny"),
                new HumanPlayer("Dude")
                );

            var p1 = list.First();
            var p2 = list.First();

            Assert.AreEqual("Jesus", p1.Name);
            Assert.AreEqual("Donny", p2.Name);
        }
    }
}

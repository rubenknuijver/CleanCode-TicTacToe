using GameLibrary;
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
    public class GameTests
    {
        [TestMethod]
        public void Can_Register_Player()
        {
            Game game = new Game(2);

            game.RegisterPlayer(new HumanPlayer("John Dow"));
            game.RegisterPlayer(new ArtificialIntelligencePlayer());

            Assert.IsNull(game.CurrentRound);
        }

        [TestMethod]
        [ExpectedException(typeof(PlayerMaximumException))]
        public void Register_Player_Thows_On_PlayerMaximum()
        {
            Game game = new Game(2);

            game.RegisterPlayer(new HumanPlayer("John Dow"));
            game.RegisterPlayer(new ArtificialIntelligencePlayer());
            game.RegisterPlayer(new ArtificialIntelligencePlayer());
        }
    }
}

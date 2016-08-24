using GameLibrary;
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
        //[ExpectedException(typeof(PlayerMaximumException))]
        public void Register_Player_Thows_On_PlayerMaximum()
        {
            Game game = new Game(2);

            game.RegisterPlayer(new HumanPlayer("John Dow"));
            game.RegisterPlayer(new ArtificialIntelligencePlayer());

            GameLibrary.Tests.ExtendedAssert.Throws<PlayerMaximumException>(() => {
                game.RegisterPlayer(new ArtificialIntelligencePlayer());
            });
        }

        [TestMethod]
        //[ExpectedException(typeof(DuplicatePlayerException))]
        public void Register_Player_Thows_On_DuplicatePlayer()
        {
            Game game = new Game(2);

            game.RegisterPlayer(new HumanPlayer("John Dow"));

            GameLibrary.Tests.ExtendedAssert.Throws<DuplicatePlayerException>(() => {
                game.RegisterPlayer(new HumanPlayer("John Dow"));
            });
            }

            [TestMethod]
        public void Retrieves_Player_Added_To_Location()
        {

        }
    }
}

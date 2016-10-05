using GameLibrary;
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
            var board = new Board.GameBoard(3, 3);
            Game game = new Game(new GameLibrary.Messaging.InMemoryBus(),board, 2);

            game.RegisterPlayer(new Players.HumanPlayer("John Dow"));
            game.RegisterPlayer(new Players.ArtificialIntelligencePlayer());

            Assert.IsNull(game.CurrentGameRound);
        }

        [TestMethod]
        //[ExpectedException(typeof(PlayerMaximumException))]
        public void Register_Player_Throws_On_PlayerMaximum()
        {
            var board = new Board.GameBoard(3, 3);
            Game game = new Game(new GameLibrary.Messaging.InMemoryBus(), board, 2);

            game.RegisterPlayer(new Players.HumanPlayer("John Dow"));
            game.RegisterPlayer(new Players.ArtificialIntelligencePlayer());

            ExtendedAssert.Throws<PlayerMaximumExcededException>(() => {
                game.RegisterPlayer(new Players.ArtificialIntelligencePlayer());
            });
        }

        [TestMethod]
        //[ExpectedException(typeof(DuplicatePlayerException))]
        public void Register_Player_Throws_On_DuplicatePlayer()
        {
            var board = new Board.GameBoard(3, 3);
            Game game = new Game(new GameLibrary.Messaging.InMemoryBus(), board, 2);

            game.RegisterPlayer(new Players.HumanPlayer("John Dow"));

            ExtendedAssert.Throws<DuplicatePlayerException>(() => {
                game.RegisterPlayer(new Players.HumanPlayer("John Dow"));
            });
        }

        [TestMethod]
        public void Retrieves_Player_Added_To_Location()
        {

        }
    }
}

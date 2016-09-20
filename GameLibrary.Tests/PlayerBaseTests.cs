using GameLibrary.GamePlayers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Tests
{
    [TestClass]
    public abstract class PlayerBaseTests
    {
        protected abstract Players.Player CreatePlayer(string name);

        [TestMethod]
        public void Can_Be_Wrapped_As_FirstPlayer()
        {
            Players.Player player = CreatePlayer("Fisrt PLayer");
            player = PlayerWrapping.Wrap(player).AsFirst();
        }
    }

    public interface IPlayerWrapper
    {
        Players.Player Player { get; }
        Players.Player AsFirst();
    }

    public class WrappedPLayer : Players.Player, IPlayerWrapper
    {
        public Players.Player AsFirst()
        {
            throw new NotImplementedException();
        }
        public WrappedPLayer(Players.Player player)
                    : base(player.Name)
        {
            this.Player = player;
        }

        public Players.Player Player
        {
            get;
        }
    }

    public class PlayerWrapping : IPlayerWrapper
    {
        public Players.Player Player { get; }

        public Players.Player AsFirst()
        {
            return new WrappedPLayer(Player);
        }
        protected PlayerWrapping(Players.Player player)
        {
            this.Player = player;
        }
        public static IPlayerWrapper Wrap(Players.Player player)
        {
            return new PlayerWrapping(player);
        }
    }
}

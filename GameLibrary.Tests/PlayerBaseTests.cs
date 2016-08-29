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
        protected abstract Player CreatePlayer(string name);

        [TestMethod]
        public void Can_Be_Wrapped_As_FirstPlayer()
        {
            Player player = CreatePlayer("Fisrt PLayer");
            player = PlayerWrapping.Wrap(player).AsFirst();
        }
    }

    public interface IPlayerWrapper
    {
        Player Player { get; }
        Player AsFirst();
    }

    public class WrappedPLayer : Player, IPlayerWrapper
    {
        public Player AsFirst()
        {
            throw new NotImplementedException();
        }
        public WrappedPLayer(Player player)
                    : base(player.Name)
        {
            this.Player = player;
        }

        public Player Player
        {
            get;
        }
    }

    public class PlayerWrapping : IPlayerWrapper
    {
        public Player Player { get; }

        public Player AsFirst()
        {
            return new WrappedPLayer(Player);
        }
        protected PlayerWrapping(Player player)
        {
            this.Player = player;
        }
        public static IPlayerWrapper Wrap(Player player)
        {
            return new PlayerWrapping(player);
        }
    }
}

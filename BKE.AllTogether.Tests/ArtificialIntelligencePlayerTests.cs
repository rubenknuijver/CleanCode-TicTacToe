using GameLibrary.Gamer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BKE.AllTogether.Tests
{
    public class ArtificialIntelligencePlayerTests : PlayerBaseTests
    {
        protected override Player CreatePlayer()
        {
            return new ArtificialIntelligencePlayer();
        }
    }
}

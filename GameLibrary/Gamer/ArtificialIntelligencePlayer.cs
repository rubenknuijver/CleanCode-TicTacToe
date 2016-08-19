using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Gamer
{
    public class ArtificialIntelligencePlayer : Player
    {
        public ArtificialIntelligencePlayer(int count = 1)
            : base($"Computer {count}")
        {
        }
    }
}

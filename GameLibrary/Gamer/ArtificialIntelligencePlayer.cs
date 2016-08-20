using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Gamer
{
    public class ArtificialIntelligencePlayer : Player
    {
        private static int _count = 1;

        public ArtificialIntelligencePlayer()
            :this(_count++)
        {
        }
        protected ArtificialIntelligencePlayer(int count)
            : base($"Computer {count}")
        {
        }
    }
}

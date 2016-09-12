namespace GameLibrary.GamePlayers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class ArtificialIntelligencePlayer : Player
    {
        private static int _count = 1;

        public ArtificialIntelligencePlayer()
            : this(_count++)
        {
        }

        protected ArtificialIntelligencePlayer(int count)
            : base($"Computer {count}")
        {
        }
    }
}

using GameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Game
    {
        public Gameround CurrentRound { get; set; }

        public Gamer.Player PlayerA { get; set; }

        public Gamer.Player PlayerB { get; set; }

        public Game()
        {

        }
    }
}

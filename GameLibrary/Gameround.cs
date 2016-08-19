using GameLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary
{
    public class Gameround
    {
        public CommandManager TurnStack { get; set; }

        public Gamer.Player CurrentPlayer { get; set; }

        public Gamer.Player Winner { get; set; }
    }
}

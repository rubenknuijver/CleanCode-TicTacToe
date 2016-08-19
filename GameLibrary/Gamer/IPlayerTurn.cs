using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibrary.Gamer
{
    public interface IPlayerTurn
    {
        DateTime Start { get; }

        Player Player { get; }
    }
}

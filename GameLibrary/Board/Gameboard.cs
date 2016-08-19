using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Board
{
    public class Gameboard
    {
        public Grid Grid { get; } = new Grid(3, 3);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Utils
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}

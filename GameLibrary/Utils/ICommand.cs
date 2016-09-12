namespace GameLibrary.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}

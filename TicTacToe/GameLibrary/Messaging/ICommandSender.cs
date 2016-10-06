namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICommandSender
    {
        void Send<T>(T command)
            where T : ICommand;
    }
}

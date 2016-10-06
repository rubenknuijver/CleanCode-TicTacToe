namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Event : IMessage
    {
        int Version { get; }
    }
}

namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IHandler<T>
            where T : IMessage
    {
        /// <summary>
        /// Handle the Event
        /// </summary>
        /// <param name="@event"></param>
        void Handle(T @event);
    }
}

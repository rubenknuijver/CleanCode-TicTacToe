namespace GameLibrary.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBus : IEventRaiser, ICommandSender
    {
        /// <summary>
        /// Register Handlers for a specific Event
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RegisterHandler<T>();

        /// <summary>
        /// Register Single instance Handler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        void RegisterHandler<T>(T handler);
    }
}

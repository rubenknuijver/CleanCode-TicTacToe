using GameLibrary.Gamer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace GameLibrary
{
    public class DuplicatePlayerException : Exception, ISerializable
    {
        public Player Player
        {
            get;
        }

        public DuplicatePlayerException(Player player)
        {
            Player = player;
        }

        protected DuplicatePlayerException(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                return;

            Player = (Player)info.GetValue("Player", typeof(Player));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                return;

            info.AddValue("Player", Player);
        }
    }
}

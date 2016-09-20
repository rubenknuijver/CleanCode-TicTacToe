namespace GameLibrary.GamePlayers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class MarkType : Styx.Enumeration
    {
        public static readonly MarkType Empty = new EmptyMarkType();

        public static readonly MarkType X = new XMarkType();

        public static readonly MarkType O = new OMarkType();

        protected MarkType(int value, string displayName)
            : base(value, displayName)
        {
        }

        private class EmptyMarkType : MarkType
        {
            public EmptyMarkType()
                : base(0, "Empty")
            {
            }
        }

        private class XMarkType : MarkType
        {
            public XMarkType()
                : base(1, "X")
            {
            }
        }

        private class OMarkType : MarkType
        {
            public OMarkType()
                : base(2, "O")
            {
            }
        }
    }
}

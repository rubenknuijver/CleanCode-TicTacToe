using GameLibrary.Gamer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BKE.AllTogether.Tests
{
    [TestClass]
    public abstract class PlayerBaseTests
    {
        protected virtual Player CreatePlayer(string name)
        {
            return null;
        }
    }
}

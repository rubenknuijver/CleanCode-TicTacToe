using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameLibrary.Tests
{
    public static class ExtendedAssert
    {
        
        public static void Throws<TException>(Action assertion) where TException : Exception
        {
            try {
                assertion();
            }
            catch (TException exception) {
                Assert.IsTrue(exception.GetType() == typeof(TException), $"Expected exception of type {typeof(TException)} but got {exception.GetType()}.");
                return;
            }
            Assert.Fail($"The expected exception of type {typeof(TException)} was not thrown.");
        }
    }
}

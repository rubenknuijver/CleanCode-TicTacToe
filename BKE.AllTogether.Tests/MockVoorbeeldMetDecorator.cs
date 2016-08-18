using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BKE.AllTogether.Tests
{
    /// <summary>
    /// Summary description for MockVoorbeeld
    /// </summary>
    [TestClass]
    public class MockVoorbeeldMetDecorator
    {
        [TestMethod]      
        public void MockVoorbeeld1()
        {
            int helloCount = 0;

            var iSayHelloMock = new Mock<ISayHello>(MockBehavior.Loose);

            iSayHelloMock.Setup(x => x.SayHello()).Callback(() => helloCount++);

            var theDecorator = new SayHelloDecorator(
                new SayHelloDecorator(
                    new SayHelloDecorator(
                        new SayHelloDecorator(iSayHelloMock.Object)
                        )));

            theDecorator.SayHello();

            Assert.AreEqual(1, helloCount);
        }

        public class SayHelloDecorator : ISayHello
        {
            public SayHelloDecorator(ISayHello decorated)
            {
                _decorated = decorated;
            }

            private ISayHello _decorated;

            public void SayHello()
            {
                _decorated.SayHello();
            }            
        }
                
        public interface ISayHello
        {
            void SayHello();
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests
{
    [TestClass]
    public class ProxyTest : TestBase
    {
        [TestMethod]
        public void GetSetDatabase()
        {
            // Setup
            var mock = new Mock<IDatabase>();

            // Act
            var proxy = new Proxy
            {
                Database = mock.Object
            };
            
            // Asset
            Assert.AreEqual(proxy.Database, mock.Object);
        }

        [TestMethod]
        public void GetService()
        {
            // Setup
            var moqDb = new Mock<IDatabase>();
            var proxy = new Proxy
            {
                Database = moqDb.Object
            };
            
            // Act
            var service = new Service(moqDb.Object);
            
            // Assert
            Assert.AreEqual(proxy.GetService().GetType().FullName, service.GetType().FullName);
        }
    }
}

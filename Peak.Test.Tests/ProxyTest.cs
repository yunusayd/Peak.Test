﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests
{
    [TestClass]
    public class ProxyTest
    {
        [TestMethod]
        public void GetSetDatabase()
        {
            var mock = new Mock<IDatabase>();

            var proxy = new Proxy();
            proxy.Database = mock.Object;
            Assert.AreEqual(proxy.Database, mock.Object);
        }

        [TestMethod]
        public void GetService()
        {
            var moqService = new Mock<IService>();
            var moqDB = new Mock<IDatabase>();
            var proxy = new Proxy();
            Assert.AreEqual(proxy.GetService().GetType().FullName, new Service(moqDB.Object).GetType().FullName);
        }
    }
}

using AutoFixture;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests
{
    [TestClass]
    public class ClientTest : TestBase
    {
        private Client GetClient(Dto moqDto)
        {
            var moqRsp = new ResponseMessage();
            moqRsp.Add(moqDto);

            var moqService = new Mock<IService>();
            moqService.Setup(x => x.InsertReport(It.IsAny<RequestMessage>())).Returns(moqRsp);

            var moqProxy = new Mock<IProxy>();
            moqProxy.Setup(x => x.GetService()).Returns(moqService.Object);

            var client = new Client(moqProxy.Object);
            return client;
        }

        [TestMethod]
        public void ExecuteWithParamsShouldWork()
        {
            // Setup
            var str = Fixture.Create<string>();
            var intProp = Fixture.Create<int>();
            var now = Fixture.Create<DateTime>();
            var moqDto = new Dto(str, intProp,now);
            var client = GetClient(moqDto);
            
            // Act
            client.Execute(moqDto.PropInt, moqDto.PropDateTime, moqDto.PropStr);
            
            // Assert
            Assert.AreEqual(client.PropInt, moqDto.PropInt);
            Assert.AreEqual(client.PropStr, moqDto.PropStr);
            Assert.AreEqual(client.PropDateTime, moqDto.PropDateTime);
        }
    }
}
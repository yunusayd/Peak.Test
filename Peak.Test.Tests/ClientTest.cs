using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests
{
    [TestClass]
    public class ClientTest
    {
        public Client GetClient(DTO moqDTO)
        {
            var moqRsp = new ResponseMessage();
            moqRsp.Add(moqDTO);
            
            var moqService = new Mock<IService>();
            moqService.Setup(x => x.InsertReport(It.IsAny<RequestMessage>())).Returns(moqRsp);

            var moqProxy = new Mock<IProxy>();
            moqProxy.Setup(x => x.GetService()).Returns(moqService.Object);

            var client = new Client(moqProxy.Object);
            return client;
        }
        [TestMethod]
        public void ExecuteWithParamsTest()
        {
            var moqDTO = new DTO("yoda", 42, DateTime.Now);
            var client = GetClient(moqDTO);
            client.Execute(moqDTO.PropInt, moqDTO.PropDateTime, moqDTO.PropStr);
            Assert.AreEqual(client.PropInt, moqDTO.PropInt);
            Assert.AreEqual(client.PropStr, moqDTO.PropStr);
            Assert.AreEqual(client.PropDateTime, moqDTO.PropDateTime);
        }
    }
}

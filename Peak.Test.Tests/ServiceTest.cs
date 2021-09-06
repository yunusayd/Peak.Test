using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests
{
    [TestClass]
    public class ServiceTest
    {
        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
        }

        [TestMethod]
        public void ServiceCtorTest()
        {
            var moqDB = new Mock<IDatabase>();
            var service = new Service(moqDB.Object);
            Assert.AreEqual(service.Database, moqDB.Object);
        }

        [TestMethod]
        public void ServiceInsertTest()
        {
            var moqDB = new Mock<IDatabase>();
            moqDB.Setup(x => x.ExecuteNonQuery(It.IsAny<SqlCommand>())).Returns(1);
            var service = new Service(moqDB.Object);

            var req = new RequestMessage();
            var reqDTO = new DTO("yoda", 42, DateTime.Now);
            req.Add(reqDTO);

            var rspDTO = (DTO)reqDTO.Clone();
            rspDTO.RowId = 5;
            
            var rsp = new ResponseMessage();
            rsp.Add(rspDTO);

            var response = service.InsertReport(req);
            Assert.AreEqual(response.Get<DTO>(), req.Get<DTO>());
        }
    }
}

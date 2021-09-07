using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Peak.Test.Interfaces;
using Peak.Test.Tests.Mocks;

namespace Peak.Test.Tests
{
    [TestClass]
    public class ServiceTest : TestBase
    {
        private readonly DatabaseMock _databaseMock;
        private readonly Service _service;
        public ServiceTest()
        {
            _databaseMock = new DatabaseMock();
            _service = new Service(_databaseMock.Object);
        }
        
        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
        }

        [TestMethod]
        public void ServiceCtorTest()
        {
            Assert.AreEqual(_service.Database, _databaseMock.Object);
        }

        [TestMethod]
        public void ServiceInsertTest()
        {
            _databaseMock.ReturnValueOnExecuteNonQuery(1);
            var req = new RequestMessage();
            var reqDto = Fixture.Create<DTO>();
            req.Add(reqDto);

            var rspDTO = (DTO)reqDto.Clone();
            rspDTO.RowId = 5;
            
            var rsp = new ResponseMessage();
            rsp.Add(rspDTO);

            var response = _service.InsertReport(req);
            Assert.AreEqual(response.Get<DTO>(), req.Get<DTO>());
        }
    }
}

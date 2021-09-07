using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void ServiceCtorTest()
        {
            Assert.AreEqual(_service.Database, _databaseMock.Object);
        }

        [TestMethod]
        public void ServiceInsertTest()
        {
            // Setup
            _databaseMock.ReturnValueOnExecuteNonQuery(1);
            var req = new RequestMessage();
            var reqDto = Fixture.Create<Dto>();
            req.Add(reqDto);

            // Act
            var response = _service.InsertReport(req);
            var rowId = response.Get<Dto>().RowId = Fixture.Create<int>();

            // Assert
            Assert.AreEqual(response.Get<Dto>(), req.Get<Dto>());
            Assert.AreEqual(response.Get<Dto>().RowId, rowId);
        }
    }
}
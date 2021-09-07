using AutoFixture;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Peak.Test.Tests
{
    [TestClass]
    public class DtoTest : TestBase
    {
        [TestMethod]
        public void GetSetTest()
        {
            // Setup
            var str = Fixture.Create<string>();
            var now = Fixture.Create<DateTime>();
            var intTest = Fixture.Create<int>();
            var rowId = Fixture.Create<int>();

            // Act
            var dto = new Dto(str, intTest, now);
            var dtoResp = new Dto(str, intTest, now, rowId);
            
            // Assert
            Assert.AreEqual(dto.PropStr, str);
            Assert.AreEqual(dto.PropInt, intTest);
            Assert.AreEqual(dto.PropDateTime, now);
            Assert.AreEqual(dtoResp.RowId, rowId);
        }
    }
}

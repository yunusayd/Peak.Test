using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Peak.Test.Tests
{
    [TestClass]
    public class DTOTest
    {

        [TestMethod]
        public void GetSetTest()
        {
            var str = "Test";
            var now = DateTime.Now;
            var intTest = 42;
            var rowId = 5;

            var dto = new DTO(str, intTest, now);
            var dtoResp = new DTO(str, intTest, now, rowId);
            
            Assert.AreEqual(dto.PropStr, str);
            Assert.AreEqual(dto.PropInt, intTest);
            Assert.AreEqual(dto.PropDateTime, now);
            Assert.AreEqual(dtoResp.RowId, rowId);
        }
    }
}

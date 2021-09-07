using System;
using System.Data;
using System.Data.SqlClient;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Peak.Test.Tests.Mocks;

namespace Peak.Test.Tests
{
    [TestClass]
    public class ERecordTest : TestBase
    {
        private readonly DatabaseMock _databaseMock;
        private readonly ERecord _record;
        
        public ERecordTest()
        {
            _databaseMock = new DatabaseMock();
            _record = new ERecord(_databaseMock.Object);
        }
        
        [TestMethod]
        public void ERecordCtorInsertShouldWork()
        {
            // Setup
            var str = Fixture.Create<string>();
            var intVal = Fixture.Create<int>();
            var dtVal = Fixture.Create<DateTime>();
            _databaseMock.ReturnValueOnExecuteNonQuery(1);
            var dto = new Dto(str, intVal, dtVal);
            
            // Act
            var res = _record.Insert(dto);
            
            //Asset
            Assert.AreEqual(res.PropInt, intVal);
            Assert.AreEqual(res.PropStr, str);
            Assert.AreEqual(res.PropDateTime, dtVal);
        }

        [TestMethod]
        public void ERecordListShouldWork()
        {
            //Setup
            var str = Fixture.Create<string>();
            var intVal = Fixture.Create<int>();
            var dtVal = Fixture.Create<DateTime>();
            _databaseMock.ReturnValueOnExecuteDataSet(SampleDataSet(str, intVal, dtVal));
            
            //Act
            var list = _record.GetAll("TEST");

            //Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].PropStr, str);
            Assert.AreEqual(list[0].PropInt, intVal);
            Assert.AreEqual(list[0].PropDateTime, dtVal);
            
            _databaseMock.Mock.Verify(a => a.ExecuteDataSet(It.IsAny<SqlCommand>()), Times.Once()); 
            _databaseMock.Mock.Verify(a => a.ExecuteDataSet(It.Is<SqlCommand>(sqlCommand => sqlCommand.CommandText == "DATA_I_ROW")), Times.Once()); 
        }

        private static DataSet SampleDataSet(string str, int intVal, DateTime dtVal)
        {
            var ds = new DataSet();
            var tb = new DataTable("main");
            ds.Tables.Add(tb);

            tb.Columns.Add("CSTR", typeof(string));
            tb.Columns.Add("CINT", typeof(int));
            tb.Columns.Add("CDATETIME", typeof(DateTime));

            DataRow AddRow(string rcstr, int rcint, DateTime rcDateTime)
            {
                var row = tb.NewRow();
                row["CSTR"] = rcstr;
                row["CINT"] = rcint;
                row["CDATETIME"] = rcDateTime;
                return row;
            }

            tb.Rows.Add(AddRow(str, intVal, dtVal));
            return ds;
        }


    }
}

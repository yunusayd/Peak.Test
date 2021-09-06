using System;
using System.Collections.Generic;
using System.Data;
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
    public class ERecordTest
    {
        [TestMethod]
        public void ERecordCtorInsertTest()
        {
            var moqDB = new Mock<IDatabase>();
            var str = "ID";
            var intVal = 100;
            var dtVal = DateTime.Now;

            moqDB.Setup(x => 
                x.ExecuteNonQuery(It.IsAny<IDbCommand>())
                ).Returns(1);
            var dto = new DTO(str, intVal, dtVal);

            var rec = new ERecord(moqDB.Object);
            var ds = rec.Insert(dto);
        }

        [TestMethod]
        public void ERecordListTest()
        {
            var moqDB = new Mock<IDatabase>();
            var str = "ID";
            var intVal = 100;
            var dtVal = DateTime.Now;

            moqDB.Setup(x => x.ExecuteDataSet(It.IsAny<IDbCommand>())).Returns(sampleDataSet(str, intVal, dtVal));
            var rec = new ERecord(moqDB.Object);
            var list = rec.GetAll("TEST");

            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].PropStr, str);
            Assert.AreEqual(list[0].PropInt, intVal);
            Assert.AreEqual(list[0].PropDateTime, dtVal);
        }

        DataSet sampleDataSet(string str, int intVal, DateTime dtVal)
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

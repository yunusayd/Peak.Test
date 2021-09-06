using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void ExecuteNonQueryTest()
        {
            IDatabase database = new Database();
            var moqSQLCommand = new Mock<IDbCommand>();
            moqSQLCommand.Setup(x => x.ExecuteNonQuery()).Returns(1);
            
            Assert.ThrowsException<ArgumentNullException>(() => database.ExecuteNonQuery(null));
            Assert.AreEqual(database.ExecuteNonQuery(new SqlCommand()), 1);
        }

        [TestMethod]
        public void ExecuteDataSetTest()
        {
            IDatabase database = new Database();
            //null test
            Assert.ThrowsException<ArgumentNullException>(() => database.ExecuteDataSet(null));
            
            // var mockedDataReader = new Mock<IDataReader>();
            // bool readFlag = true;
            //
            // // bir satır dönecek, ikinci cagirmada read false olmalı
            // mockedDataReader.Setup(x => x.Read()).Returns(() => readFlag).Callback(() => readFlag = false);
            // mockedDataReader.Setup(x => x["PropInt"]).Returns(42);  
            // mockedDataReader.Setup(x => x["PropStr"]).Returns("Smith");  
            // mockedDataReader.Setup(x => x["ProdDateTime"]).Returns(DateTime.Now);
            //
            // var moqSQLCommand = new Mock<IDbCommand>();
            // moqSQLCommand.Setup(x => x.ExecuteReader()).Returns(mockedDataReader.Object);
            // var ds = database.ExecuteDataSet(moqSQLCommand.Object);
            //
            // Assert.IsNotNull(ds);

        }
    }
}
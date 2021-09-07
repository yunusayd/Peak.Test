using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Moq;
using Peak.Test.Interfaces;
using Peak.Test.Tests.Mocks;

namespace Peak.Test.Tests
{
    [TestClass]
    public class DatabaseTest : TestBase
    {
        private Database _database;
        private DbCommandMock _dbCommandMock;
        
        public DatabaseTest()
        {
            _dbCommandMock = new DbCommandMock();
            _database = new Database();
        }
        
        [TestMethod]
        public void ExecuteNonQueryShouldThrowOnNullInput()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _database.ExecuteNonQuery(null));
        }
        
        [TestMethod]
        public void ExecuteNonQueryTest()
        {
            //Burda setup, act ve assertleri ayırdım.
            //Bu şekilde daha sonradan daha okunabilir oluyor.
            //Diğerlerinde de yapılabilir.
            
            //Setup
            _dbCommandMock.ReturnValueOnExecuteNonQuery(1);
            
            //Act
            var result = _database.ExecuteNonQuery(new SqlCommand());
            
            //Assert
            Assert.AreEqual(result, 1);
        }

        /// <summary>
        /// Abi bu iki ayrı test, biri throw exception testi, diğeri doğru data donme testi.
        /// </summary>
        [TestMethod]
        public void ExecuteDataSetThrowsExceptionOnNullInput()
        {
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => _database.ExecuteDataSet(null));
            _dbCommandMock.Mock.Verify(a => a.ExecuteReader(), Times.Never); // ExecuteReader hiç çağırılmamış olması lazım bu durumda
        }
        
        /// <summary>
        /// Burdaki olayı tam anlayamadım :'(
        /// </summary>
        [TestMethod]
        public void ExecuteDataSetShouldReturnCorrectData()
        {
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
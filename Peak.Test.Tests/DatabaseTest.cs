using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace Peak.Test.Tests
{
    [TestClass]
    public class DatabaseTest : TestBase
    {
        [TestMethod]
        public void ExecuteNonQueryShouldThrowOnNullInput()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() => Database.ExecuteNonQuery(null));
        }
        
        [TestMethod]
        public void ExecuteNonQueryShouldWork()
        {
            //Setup
            DbCommandMock.ReturnValueOnExecuteNonQuery(1);
            
            //Act
            var result = Database.ExecuteNonQuery(DbCommandMock.Object);
            
            //Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void ExecuteDataSetThrowsExceptionOnNullInput()
        {
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => Database.ExecuteDataSet(null));
            DbCommandMock.Mock.Verify(a => a.ExecuteReader(), Times.Never);
        }
    }
}
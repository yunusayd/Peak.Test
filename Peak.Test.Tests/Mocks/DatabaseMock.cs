using System.Data;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests.Mocks
{
    public class DatabaseMock : MockBase<IDatabase>
    {
        public void ReturnValueOnExecuteNonQuery(int value)
        {
            Mock.Setup(x => 
                x.ExecuteNonQuery(It.IsAny<IDbCommand>())
            ).Returns(value);
        }
        
        public void ReturnValueOnExecuteDataSet(DataSet ds)
        {
            Mock.Setup(x => 
                x.ExecuteDataSet(It.IsAny<IDbCommand>())
            ).Returns(ds);
        }
    }
}
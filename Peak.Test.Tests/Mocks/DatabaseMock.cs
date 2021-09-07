using System.Data;
using Moq;
using Peak.Test.Interfaces;

namespace Peak.Test.Tests.Mocks
{
    /// <summary>
    /// Mocku ortak bi class yaptım. İçerde sürekli setupla uğraşma. Burda bi kere setup yap, içerde istediğin kadar kullan.
    /// </summary>
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
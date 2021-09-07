using System.Data;

namespace Peak.Test.Tests.Mocks
{
    public class DbCommandMock : MockBase<IDbCommand>
    {
        public void ReturnValueOnExecuteNonQuery(int value)
        {
            Mock.Setup(x => 
                x.ExecuteNonQuery()
            ).Returns(value);
        }
        
    }
}
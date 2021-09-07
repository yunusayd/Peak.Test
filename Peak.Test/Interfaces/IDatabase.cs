using System.Data;

namespace Peak.Test.Interfaces
{
    public interface IDatabase
    {
        int ExecuteNonQuery(IDbCommand cmd);
        DataSet ExecuteDataSet(IDbCommand cmd);
    }
}
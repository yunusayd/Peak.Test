using System;
using System.Data;
using System.Data.SqlClient;
using Peak.Test.Interfaces;

namespace Peak.Test
{
    public class Database : IDatabase
    {
        public int ExecuteNonQuery(IDbCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            // ...
            return 1;
        }

        public DataSet ExecuteDataSet(IDbCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));

            using (var reader = cmd.ExecuteReader())
            {
                using (var adaptor = new SqlDataAdapter((SqlCommand)cmd))
                {
                    var ds = new DataSet();
                    adaptor.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
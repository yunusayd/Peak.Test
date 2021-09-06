using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Peak.App.DataAccess;
using Peak.App.DataAccess.Projection;
using Peak.App.Entity;
using Peak.Test.Interfaces;

namespace Peak.Test
{
    public class ERecord : IBaseEntity
    {
        public IDatabase Database { get; }

        public ERecord(IDatabase database)
        {
            this.Database = database;
        }

        public DTO Insert(DTO dto)
        {
            var sqlCommand = new SqlCommand("DATA_I_ROW");
            var result = Database.ExecuteNonQuery(sqlCommand);
            if (result <= 0)
                throw new InvalidOperationException();

            return dto;
        }

        public List<DTO> GetAll(string moduleCode)
        {
            var sqlCommand = new SqlCommand("DATA_I_ROW");
            var ds = Database.ExecuteDataSet(sqlCommand);

            if (ds.Tables[0].Rows.Count < 1)
                throw new InvalidOperationException();

            var result = new List<DTO>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var cstr = row["CSTR"] != DBNull.Value ? row["CSTR"].ToString() : null;
                var cint = row["CINT"] != DBNull.Value ? Convert.ToInt32(row["CINT"]) : 0;
                var cdatetime = row["CDATETIME"] != DBNull.Value ? Convert.ToDateTime(row["CDATETIME"]) : DateTime.MinValue;
                result.Add(new DTO(cstr, cint, cdatetime));
            }
            return result;
        }
    }
}

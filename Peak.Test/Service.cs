using Peak.Test.Interfaces;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Peak.Test
{
    public class Service : IService
    {
        public IDatabase Database { get; }
        public Service(IDatabase db)
        {
            this.Database = db;
        }

        public ResponseMessage InsertReport(RequestMessage requestMessage)
        {
            var eReport = new ERecord(this.Database);
            var reqReport = requestMessage.Get<Dto>();
            var dtoReport = eReport.Insert(reqReport);
            var responseMessage = new ResponseMessage();
            responseMessage.Add(dtoReport);

            return responseMessage;
        }
    }
}

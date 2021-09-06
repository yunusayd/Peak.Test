using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peak.Test.Interfaces;

namespace Peak.Test
{
    public class Client
    {
        public IProxy Proxy { get; set; }

        public Client(IProxy proxy)
        {
            this.Proxy = proxy;
        }
        public void Execute(int val, DateTime dt, string str)
        {
            if (dt == DateTime.MinValue)
                throw new ArgumentException(nameof(dt));

            if (val <= 0)
                throw new ArgumentException(nameof(val));

            if (string.IsNullOrEmpty(str))
                throw new ArgumentException(nameof(str));
            
            var service = this.Proxy.GetService();
            var reqMessage = new RequestMessage();
            reqMessage.Add(new DTO(str, val, dt));
            var response = service.InsertReport(new RequestMessage());
            PropInt = response.Get<DTO>().PropInt;
            PropStr = response.Get<DTO>().PropStr;
            PropDateTime = response.Get<DTO>().PropDateTime;
        }

        public DateTime PropDateTime { get; set; }
        public string PropStr { get; set; }
        public int PropInt { get; set; }
    }
}

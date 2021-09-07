using System;
using Peak.Test.Interfaces;

namespace Peak.Test
{
    public class Client
    {
        private IProxy Proxy { get; set; }

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
            reqMessage.Add(new Dto(str, val, dt));
            var response = service.InsertReport(new RequestMessage());
            PropInt = response.Get<Dto>().PropInt;
            PropStr = response.Get<Dto>().PropStr;
            PropDateTime = response.Get<Dto>().PropDateTime;
        }

        public DateTime PropDateTime { get; private set; }
        public string PropStr { get; private set; }
        public int PropInt { get; private set; }
    }
}

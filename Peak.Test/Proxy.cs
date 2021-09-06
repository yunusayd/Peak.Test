using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peak.Test.Interfaces;

namespace Peak.Test
{
    public class Proxy : IProxy
    {
        public IDatabase Database { get; set; }
        public IService GetService()
        {
            return new Service(Database);
        }
    }
}

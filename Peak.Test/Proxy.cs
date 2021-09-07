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

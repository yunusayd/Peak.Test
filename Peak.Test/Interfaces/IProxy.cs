namespace Peak.Test.Interfaces
{
    public interface IProxy
    {
        IDatabase Database { get; set; }
        IService GetService();
    }
}
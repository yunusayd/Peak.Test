namespace Peak.Test.Interfaces
{
    public interface IService
    {
        IDatabase Database { get; }
        ResponseMessage InsertReport(RequestMessage requestMessage);
    }
}
using AutoFixture;
using Peak.Test.Interfaces;
using Peak.Test.Tests.Mocks;

namespace Peak.Test.Tests
{
    public class TestBase
    {
        private IFixture _fixture;
        private Database _database;
        private DbCommandMock _dbCommandMock;
        protected IFixture Fixture => _fixture ??= new Fixture();
        protected IDatabase Database => _database ??= new Database();
        protected DbCommandMock DbCommandMock => _dbCommandMock ??= new DbCommandMock();

        protected TestBase()
        {
            _database = new Database();
            _dbCommandMock = new DbCommandMock();
        }
    }
}
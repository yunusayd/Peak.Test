using AutoFixture;

namespace Peak.Test.Tests
{
    public class TestBase
    {
        private IFixture _fixture;

        protected IFixture Fixture => _fixture ??= new Fixture();
    }
}
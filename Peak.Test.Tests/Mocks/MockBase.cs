using AutoFixture;
using Moq;

namespace Peak.Test.Tests.Mocks
{
    public class MockBase<T> where T : class
    {
        public Mock<T> Mock { get; }

        public T Object => Mock.Object;

        public IFixture Fixture { get; }

        public MockBase()
        {
            Mock = new Mock<T>();
            Fixture = new Fixture();
        }

        public MockBase(Mock<T> mock)
        {
            Mock = mock;
        }
    }
}
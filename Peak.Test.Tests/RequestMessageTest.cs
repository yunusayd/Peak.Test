using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoFixture;

namespace Peak.Test.Tests
{
    [TestClass]
    public class RequestMessageTest:TestBase
    {
        [TestMethod]
        public void RequestMessagePropTest()
        {
            // Setup
            var prop1 = Fixture.Create<int>();
            var prop2 = Fixture.Create<string>();
            var now = Fixture.Create<DateTime>();
            
            var req = new RequestMessage
            {
                Prop1 = prop1,
                Prop2 = prop2,
                Prop3 = now
            };

            var str = Fixture.Create<string>();
            var intProp = Fixture.Create<int>();

            // Act
            var dto = new Dto(str, intProp, now);
            req.Add(dto);
            
            // Assert
            Assert.AreEqual(req.Prop1, prop1);
            Assert.AreEqual(req.Prop2, prop2);
            Assert.AreEqual(req.Prop3, now);
            Assert.AreEqual(req.Get<Dto>(), dto);
            Assert.AreEqual(dto.PropInt, intProp);
            Assert.AreEqual(dto.PropStr, str);
            Assert.AreEqual(dto.PropDateTime, now);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Peak.Test.Tests
{
    [TestClass]
    public class RequestMessageTest
    {
        [TestMethod]
        public void RequestMessagePropTest()
        {
            var req = new RequestMessage();
            req.Prop1 = 1;
            req.Prop2 = "A";
            var now = req.Prop3 = DateTime.Now;
            var dto = new DTO("Str", 42, now);
            req.Add(dto);
            
            
            Assert.AreEqual(req.Prop1, 1);
            Assert.AreEqual(req.Prop2, "A");
            Assert.AreEqual(req.Prop3, now);
            
            Assert.AreEqual(req.Get<DTO>(), dto);
        }
        
    }
}
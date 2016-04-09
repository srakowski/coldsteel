using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class ControlTests
    {
        [TestMethod]
        public void KeyProvidedIsAccessibleViaKeyProperty()
        {
            var control = new MockControl("testkey");
            Assert.AreEqual("testkey", control.Key);
        }
    }
}

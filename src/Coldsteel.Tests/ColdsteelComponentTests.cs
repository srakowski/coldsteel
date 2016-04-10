using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class ColdsteelComponentTests
    {
        [TestMethod]
        public void InitializeControlsIsInvoked()
        {
            var initializer = new MockColdsteelInitializer();
            var coldsteelComponent = new ColdsteelComponent(null, initializer);
            coldsteelComponent.Initialize();
            Assert.IsTrue(initializer.InitializeControlsWasInvoked);
            Assert.IsNotNull(initializer.ProvidedInputObject);
        }
    }
}

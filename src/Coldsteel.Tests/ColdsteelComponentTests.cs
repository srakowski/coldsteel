using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;
using Microsoft.Xna.Framework;

namespace Coldsteel.Tests
{
    [TestClass]
    public class ColdsteelComponentTests
    {
        [TestMethod]
        public void InitializeControlsOnColdsteelInitializerIsInvokedWhenComponentIsInitialized()
        {
            var initializer = new MockColdsteelInitializer();
            var coldsteelComponent = new ColdsteelComponent(new Game(), initializer);
            coldsteelComponent.Initialize();
            Assert.IsTrue(initializer.InitializeControlsWasInvoked);
        }

        [TestMethod]
        public void InitializeControlsOnColdsteelInitializerIsProvidedWithInputObject()
        {
            var initializer = new MockColdsteelInitializer();
            var coldsteelComponent = new ColdsteelComponent(new Game(), initializer);
            coldsteelComponent.Initialize();
            Assert.IsNotNull(initializer.ProvidedInputObject);
        }

        [TestMethod]
        public void RegisterStagesOnColdsteelInitializerIsInvokedWhenComponentIsInitialized()
        {
            var initializer = new MockColdsteelInitializer();
            var coldsteelComponent = new ColdsteelComponent(new Game(), initializer);
            coldsteelComponent.Initialize();
            Assert.IsTrue(initializer.RegisterStagesWasInvoked);
        }

        [TestMethod]
        public void AStageIsLoadedWhenInitializeIsComplete()
        {
            var initializer = new MockColdsteelInitializer();
            var coldsteelComponent = new ColdsteelComponent(new Game(), initializer);
            coldsteelComponent.Initialize();
            var mgr = coldsteelComponent.GameStageManager;
            Assert.IsNotNull(mgr.CurrentGameStage);
        }

        [TestMethod]
        public void GameStageManagerHasAccessToColdsteelComponentAfterInitialization()
        {
            var initializer = new MockColdsteelInitializer();
            var coldsteelComponent = new ColdsteelComponent(new Game(), initializer);
            coldsteelComponent.Initialize();
            var mgr = coldsteelComponent.GameStageManager;
            Assert.AreSame(mgr.ColdsteelComponent, coldsteelComponent);
        }
    }
}

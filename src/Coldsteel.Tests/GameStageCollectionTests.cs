using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class GameStageCollectionTests
    {
        [TestMethod]
        public void CanRegisterStages()
        {
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>("stage1");
            Assert.AreEqual(typeof(MockGameStage), stageCollection["stage1"]);
            stageCollection.RegisterStage<DummyStage>("stage2");
            Assert.AreEqual(typeof(DummyStage), stageCollection["stage2"]);
        }
    }
}

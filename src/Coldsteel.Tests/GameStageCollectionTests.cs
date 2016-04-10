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
            stageCollection.RegisterStage<DummyGameStage>("stage2");
            Assert.AreEqual(typeof(DummyGameStage), stageCollection["stage2"]);
        }

        [TestMethod]
        public void UsesTypeNameAsKeyIfNoKeyIsProvided()
        {
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            Assert.AreEqual(typeof(MockGameStage), stageCollection["MockGameStage"]);
        }

        [TestMethod]
        public void FirstAddedIsSetAsDefault()
        {
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            stageCollection.RegisterStage<DummyGameStage>();
            Assert.AreEqual(stageCollection.Default, typeof(MockGameStage));
        }
    }
}

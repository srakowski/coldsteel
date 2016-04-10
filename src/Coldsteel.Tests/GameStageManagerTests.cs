using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class GameStageManagerTests
    {
        [TestMethod]
        public void LoadsFirstStageInCollectionByDefault()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            stageCollection.RegisterStage<DummyGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize();
            Assert.IsInstanceOfType(gameStageMgr.CurrentGameStage, typeof(MockGameStage));
        }

        [TestMethod]
        public void LoadContentIsInvokedOnGameStageWhenLoadedDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize();
            var stage = gameStageMgr.CurrentGameStage as MockGameStage;
            Assert.IsTrue(stage.LoadContentWasInvoked);
        }

        [TestMethod]
        public void InitializeIsInvokedOnGameStageWhenLoadedDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize();
            var stage = gameStageMgr.CurrentGameStage as MockGameStage;
            Assert.IsTrue(stage.InitializeWasInvoked);
        }
    }
}

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
            var stageCollection = new GameStageRegistry();
            stageCollection.RegisterStage<MockGameStage>();
            stageCollection.RegisterStage<DummyGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize(new MockGameResourceFactory());
            Assert.IsInstanceOfType(gameStageMgr.ActiveGameStage, typeof(MockGameStage));
        }

        [TestMethod]
        public void LoadContentIsInvokedOnGameStageWhenLoadedDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageRegistry();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize(new MockGameResourceFactory());
            var stage = gameStageMgr.ActiveGameStage as MockGameStage;
            Assert.IsTrue(stage.LoadContentWasInvoked);
        }

        [TestMethod]
        public void InitializeIsInvokedOnGameStageWhenLoadedDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageRegistry();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize(new MockGameResourceFactory());
            var stage = gameStageMgr.ActiveGameStage as MockGameStage;
            Assert.IsTrue(stage.InitializeWasInvoked);
        }

        [TestMethod]
        public void GameStageManagerIsAssignedToGameStageDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageRegistry();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize(new MockGameResourceFactory());
            Assert.AreSame(gameStageMgr.ActiveGameStage.GameStageManager, gameStageMgr);
        }
    }
}

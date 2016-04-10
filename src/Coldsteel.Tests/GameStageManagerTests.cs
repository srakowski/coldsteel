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
            gameStageMgr.Initialize(new MockGameResourceFactory());
            Assert.IsInstanceOfType(gameStageMgr.CurrentGameStage, typeof(MockGameStage));
        }

        [TestMethod]
        public void LoadContentIsInvokedOnGameStageWhenLoadedDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize(new MockGameResourceFactory());
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
            gameStageMgr.Initialize(new MockGameResourceFactory());
            var stage = gameStageMgr.CurrentGameStage as MockGameStage;
            Assert.IsTrue(stage.InitializeWasInvoked);
        }

        [TestMethod]
        public void GameStageManagerIsAssignedToGameStageDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize(new MockGameResourceFactory());
            Assert.AreSame(gameStageMgr.CurrentGameStage.GameStageManager, gameStageMgr);
        }

        [TestMethod]
        public void GameResourceFactoryIsAssignedToGameStageDuringInitialize()
        {
            var dummyInput = new Input();
            var stageCollection = new GameStageCollection();
            stageCollection.RegisterStage<MockGameStage>();
            var gameStageMgr = new GameStageManager(dummyInput, stageCollection);
            gameStageMgr.Initialize(new MockGameResourceFactory());
            var stage = gameStageMgr.CurrentGameStage as MockGameStage;
            Assert.IsNotNull(stage.GameResourceFactory);
        }
    }
}

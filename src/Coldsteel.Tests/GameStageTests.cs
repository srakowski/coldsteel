using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class GameStageTests
    {
        [TestMethod]
        public void CanAddGameObjectsToStage()
        {
            var gameStage = new MockGameStage();
            var gameObject = new GameObject();
            gameStage.AddGameObject(gameObject);            
            Assert.IsTrue(gameStage.GameObjects.Contains(gameObject));
            var gameObject2 = new GameObject();
            gameStage.AddGameObject(gameObject2);
            Assert.IsTrue(gameStage.GameObjects.Contains(gameObject2));
        }

        [TestMethod]
        public void GameStageIsAssignedToTheGameObjectWhenAddedToTheStage()
        {
            var gameStage = new MockGameStage();
            var gameObject = new GameObject();
            gameStage.AddGameObject(gameObject);
            Assert.AreSame(gameStage, gameObject.GameStage);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LoadingContentDependsOnGameResourceFactoryBeingAssigned()
        {
            var gameStage = new MockGameStage();
            gameStage.LoadContent<DummyContent>("dumypath");
        }

        [TestMethod]
        public void CanLoadContent()
        {
            var gameStage = new MockGameStage();
            var mockResourceFactory = new MockGameResourceFactory();
            mockResourceFactory.MockContentManager = new MockContentManager();
            gameStage.GameResourceFactory = mockResourceFactory;
            gameStage.LoadContent<DummyContent>("dummypath");
            var result = gameStage.GetContent<DummyContent>("dummypath");
            Assert.AreSame(mockResourceFactory.MockContentManager.DummyContentLoaded, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotAccessContentIfNotLoaded()
        {
            var gameStage = new MockGameStage();
            var mockContentManager = new MockContentManager();
            gameStage.GameResourceFactory = new MockGameResourceFactory();
            var result = gameStage.GetContent<DummyContent>("noresult");
        }

        [TestMethod]
        public void ADefaultLayerIsAvailable()
        {
            var gameStage = new MockGameStage();
            gameStage.GameResourceFactory = new MockGameResourceFactory();
            Assert.IsNotNull(gameStage.DefaultLayer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DefaultLayerDependsOnGameResourceFactoryBeingAssigned()
        {
            var gameStage = new MockGameStage();
            var defaultLayer = gameStage.DefaultLayer;
        }
    }
}

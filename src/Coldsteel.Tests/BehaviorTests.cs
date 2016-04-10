using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class BehaviorTests
    {
        [TestMethod]
        public void CanAddGameObjectDirectlyToGameStageThroughAddGameObject()
        {
            var gameStage = new MockGameStage();
            var gameObject = new GameObject();
            var behavior = new MockBehavior();
            gameObject.AddComponent(behavior);
            gameStage.AddGameObject(gameObject);

            var gameObjectToAdd = new GameObject();
            behavior.AddGameObject(gameObjectToAdd);

            Assert.IsTrue(gameStage.GameObjects.Contains(gameObjectToAdd));
        }

        [TestMethod]
        public void CanAccessLoadedContent()
        {
            var gameStage = new MockGameStage();
            var mockGameResourceFactory = new MockGameResourceFactory();
            mockGameResourceFactory.MockContentManager = new MockContentManager();
            gameStage.GameResourceFactory = mockGameResourceFactory;
            gameStage.LoadContent<DummyContent>("test");

            var gameObject = new GameObject();
            var behavior = new MockBehavior();
            gameObject.AddComponent(behavior);
            gameStage.AddGameObject(gameObject);

            var content = behavior.MockGetContent<DummyContent>("test");
            Assert.AreSame(mockGameResourceFactory.MockContentManager.DummyContentLoaded, content);
        }

        [TestMethod]
        public void CanAccessDefaultLayer()
        {
            var gameStage = new MockGameStage();
            var mockGameResourceFactory = new MockGameResourceFactory();
            mockGameResourceFactory.MockContentManager = new MockContentManager();
            gameStage.GameResourceFactory = mockGameResourceFactory;
            var gameObject = new GameObject();
            var behavior = new MockBehavior();
            gameObject.AddComponent(behavior);
            gameStage.AddGameObject(gameObject);
            Assert.IsNotNull(behavior.MockGetDefaultLayer());
        }

        [TestMethod]
        public void CanRemoveObjectFromStageUsingDestroy()
        {
            var gameStage = new MockGameStage();
            var gameObject = new GameObject();
            var behavior = new MockBehavior();
            gameObject.AddComponent(behavior);
            gameStage.AddGameObject(gameObject);
            behavior.MockDestroy();
            Assert.IsFalse(gameStage.GameObjects.Contains(gameObject));
        }
    }
}

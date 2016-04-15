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

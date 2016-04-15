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
        public void CanRemoveGameObjectsFromStage()
        {
            var gameStage = new MockGameStage();
            var gameObject = new GameObject();
            gameStage.AddGameObject(gameObject);
            gameStage.RemoveGameObject(gameObject);
            Assert.IsFalse(gameStage.GameObjects.Contains(gameObject));
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void DefaultLayerDependsOnGameResourceFactoryBeingAssigned()
        {
            var gameStage = new MockGameStage();
            var defaultLayer = gameStage.DefaultLayer;
        }
    }
}

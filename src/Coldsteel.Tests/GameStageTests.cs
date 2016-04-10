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
        public void CannotLoadAPieceOfContentIfContentManagerHasBeenSet()
        {
            var gameStage = new MockGameStage();
            gameStage.AttemptToLoadContent = true;
            gameStage.LoadContent();
        }
    }
}

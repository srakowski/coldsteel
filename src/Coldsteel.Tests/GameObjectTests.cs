using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;
using Microsoft.Xna.Framework;

namespace Coldsteel.Tests
{
    [TestClass]
    public class GameObjectTests
    {
        #region Composite Functionality Tests

        [TestMethod]
        public void CanSetParentGameObject()
        {
            var parent = new GameObject();
            var child = new GameObject();
            child.SetParent(parent);
            Assert.AreSame(child.Parent, parent);
        }

        [TestMethod]
        public void CanAddChildGameObject()
        {
            var parent = new GameObject();
            var child = new GameObject();
            parent.AddChild(child);
            var hasDescendant = parent.IsAncestorOf(child);
            Assert.IsTrue(hasDescendant);
            Assert.AreSame(child.Parent, parent);
        }

        [TestMethod]
        public void MayChainAddChildGameObject()
        {
            var parent = new GameObject();
            var child = new GameObject();
            var child2 = new GameObject();
            Assert.AreSame(parent.AddChild(child)
                .AddChild(child2), parent);
        }

        [TestMethod]
        public void CanRemoveChildGameObject()
        {
            var parent = new GameObject();
            var child = new GameObject();
            parent.AddChild(child);
            parent.RemoveChild(child);
            var hasDescendant = parent.IsAncestorOf(child);
            Assert.IsFalse(hasDescendant);
            Assert.IsNull(child.Parent);
        }

        [TestMethod]
        public void IsAncestorOfIsRecursive()
        {
            var parent = new GameObject();
            var child = new GameObject();
            parent.AddChild(child);
            var grandChild = new GameObject();
            child.AddChild(grandChild);
            Assert.IsTrue(parent.IsAncestorOf(grandChild));
        }

        [TestMethod]
        public void IsDescendantOfIsRecursive()
        {
            var child = new GameObject();
            var parent = new GameObject();
            child.SetParent(parent);
            Assert.IsTrue(child.IsDescendantOf(parent));
            var grandParent = new GameObject();
            parent.SetParent(grandParent);
            Assert.IsTrue(child.IsDescendantOf(grandParent));

        }

        [TestMethod]
        public void WhenParentIsSetObjectIsAddedAsChild()
        {
            var parent = new GameObject();
            var child = new GameObject();
            child.SetParent(parent);
            Assert.IsTrue(parent.IsAncestorOf(child));
        }


        [TestMethod]
        public void WhenAChildIsProvidedANewParentTheChildIsRemovedFromTheOldParent()
        {
            var oldParent = new GameObject();
            var child = new GameObject();
            oldParent.AddChild(child);
            var newParent = new GameObject();
            child.SetParent(newParent);
            Assert.IsFalse(oldParent.IsAncestorOf(child));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotBeAChildOfItself()
        {
            var gameObject = new GameObject();
            gameObject.AddChild(gameObject);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotAddAsChildIfTargetIsDescendantOfChild()
        {
            var parent = new GameObject();
            var child = new GameObject();
            child.AddChild(parent);
            parent.AddChild(child);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotBeAParentOfItself()
        {
            var parent = new GameObject();
            var child = new GameObject();
            child.AddChild(parent);
            child.SetParent(parent);
        }

        [TestMethod]
        public void ChildrenGameObjectsHaveAccessToGameStage()
        {
            var parent = new GameObject();
            var child = new GameObject();
            parent.AddChild(child);

            var gameStage = new MockGameStage();
            gameStage.AddGameObject(parent);

            Assert.AreSame(gameStage, child.GameStage);
        }

        #endregion

        #region Component Management Tests

        [TestMethod]
        public void CanAddGameComponents()
        {
            var gameObject = new GameObject();
            var mockComponent = new MockGameObjectComponent();
            gameObject.AddComponent(mockComponent);
            Assert.AreSame(gameObject.GetComponent<MockGameObjectComponent>(), mockComponent);
            var mockComponent2 = new MockGameObjectComponent();
            gameObject.AddComponent(mockComponent2);
            var components = gameObject.GetComponents<MockGameObjectComponent>();
            Assert.IsTrue(components.Contains(mockComponent));
            Assert.IsTrue(components.Contains(mockComponent2));
        }

        [TestMethod]
        public void WhenDoesNotHaveComponentGetComponentReturnsNull()
        {
            var gameObject = new GameObject();
            Assert.IsNull(gameObject.GetComponent<MockGameObjectComponent>());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void WhenHasMultipleOfSameComponentGetComponentThrowsException()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent(new MockGameObjectComponent());
            gameObject.AddComponent(new MockGameObjectComponent());
            gameObject.GetComponent<MockGameObjectComponent>();
        }

        [TestMethod]
        public void CanRemoveComponents()
        {
            var gameObject = new GameObject();
            var mock = new MockGameObjectComponent();
            gameObject.AddComponent(mock);
            gameObject.RemoveComponent(mock);
            Assert.IsNull(gameObject.GetComponent<MockGameObjectComponent>());
        }

        [TestMethod]
        public void AddComponentMayBeChained()
        {
            var gameObject = new GameObject();
            var mock = new MockGameObjectComponent();
            var mock2 = new MockGameObjectComponent();
            Assert.AreSame(gameObject.AddComponent(mock)
                .AddComponent(mock2), gameObject);
        }

        [TestMethod]
        public void ComponentHasGameObjectWhenAdded()
        {
            var gameObject = new GameObject();
            var mock = new MockGameObjectComponent();
            gameObject.AddComponent(mock);
            Assert.AreSame(gameObject, mock.GameObject);
        }

        [TestMethod]
        public void ComponentNoLongerHasGameObjectWhenRemoved()
        {
            var gameObject = new GameObject();
            var mock = new MockGameObjectComponent();
            gameObject.AddComponent(mock);
            gameObject.RemoveComponent(mock);
            Assert.IsNull(mock.GameObject);
        }

        [TestMethod]
        public void InvokesUpdateOnGameObjectComponentsWhenUpdateIsInvoked()
        {
            var gameObject = new GameObject();
            var mockComponent = new MockGameObjectComponent();
            gameObject.AddComponent(mockComponent);
            var mockComponent2 = new MockGameObjectComponent();
            gameObject.AddComponent(mockComponent2);
            gameObject.Update(new DummyGameTime());
            Assert.IsTrue(mockComponent.UpdateWasInvoked);
            Assert.IsTrue(mockComponent2.UpdateWasInvoked);
        }

        [TestMethod]
        public void GameComponentMayBeRemovedDuringUpdate()
        {
            var gameObject = new GameObject();
            var mockComponent = new MockGameObjectComponent();
            gameObject.AddComponent(mockComponent);
            var mockComponent2 = new MockGameObjectComponent();
            mockComponent2.RemoveFromGameObjectDuringUpdate = true;
            gameObject.AddComponent(mockComponent2);
            gameObject.Update(new DummyGameTime());
            // must not throw exception
        }

        [TestMethod]
        public void GameObjectHasTransformByDefault()
        {
            var gameObject = new GameObject();
            Assert.IsNotNull(gameObject.GetComponent<Transform>());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GameObjectMayNotHaveMoreThanOneTransform()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent(new Transform());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GameObjectMayNotHaveMoreThanOneRenderer()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent(new MockRenderer());
            gameObject.AddComponent(new MockRenderer());
        }

        [TestMethod]
        public void InvokesRenderOnRendererWhenRenderIsInvoked()
        {
            var gameObject = new GameObject();
            var mockRenderer = new MockRenderer();
            gameObject.AddComponent(mockRenderer);
            gameObject.Render(new DummyGameTime());
            Assert.IsTrue(mockRenderer.RenderWasInvoked);
        }

        [TestMethod]
        public void InvokesHandleInputOnBehaviorsWhenHandleInputIsInvoked()
        {
            var gameObject = new GameObject();
            var mockBehavior = new MockBehavior();
            gameObject.AddComponent(mockBehavior);
            gameObject.HandleInput(new DummyGameTime(), new Input());
            Assert.IsTrue(mockBehavior.HandleInputWasInvoked);
            var mockBehavior2 = new MockBehavior();
            gameObject.AddComponent(mockBehavior2);
            gameObject.HandleInput(new DummyGameTime(), new Input());
            Assert.IsTrue(mockBehavior.HandleInputWasInvoked);
            Assert.IsTrue(mockBehavior2.HandleInputWasInvoked);
        }

        [TestMethod]
        public void SetPositionHelperInitializesThePositionVectorOfTheTransform()
        {
            var gameObject = new GameObject();
            var newPosition = new Vector2(100, 100);
            gameObject.SetPosition(newPosition);
            var transform = gameObject.GetComponent<Transform>();
            Assert.AreEqual(newPosition, transform.Position);
        }

        [TestMethod]
        public void SetPositionCanBeChained()
        {
            var gameObject = new GameObject();
            var result = gameObject.SetPosition(Vector2.Zero);
            Assert.AreSame(gameObject, result);
        }

        [TestMethod]
        public void SeRotationHelperInitializesTheRotationOfTheTransform()
        {
            var gameObject = new GameObject();
            var rotation = 1f;
            gameObject.SetRotation(rotation);
            var transform = gameObject.GetComponent<Transform>();
            Assert.AreEqual(rotation, transform.Rotation);
        }

        [TestMethod]
        public void SetRotationCanBeChained()
        {
            var gameObject = new GameObject();
            var result = gameObject.SetRotation(1f);
            Assert.AreSame(gameObject, result);            
        }

        #endregion

        [TestMethod]
        public void DestroyRemovesGameObjectFromStage()
        {
            var gameStage = new MockGameStage();
            var gameObject = new GameObject();
            gameStage.AddGameObject(gameObject);
            gameObject.Destroy();
            Assert.IsFalse(gameStage.GameObjects.Contains(gameObject));
        }

        [TestMethod]
        public void DestroyRemovesGameObjectFromParent()
        {
            var gameStage = new MockGameStage();
            var parent = new GameObject();
            gameStage.AddGameObject(parent);
            var child = new GameObject();
            parent.AddChild(child);            
            child.Destroy();
            Assert.IsFalse(parent.Children.Contains(child));
            Assert.IsFalse(gameStage.GameObjects.Contains(child));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class GameObjectComponentTests
    {
        [TestMethod]
        public void CanAccessTransformDirectly()
        {
            var gameObject = new GameObject();
            var transform = gameObject.GetComponent<Transform>();
            var mockGameObjectComponent = new MockGameObjectComponent();
            gameObject.AddComponent(mockGameObjectComponent);
            Assert.IsTrue(mockGameObjectComponent.HasAccessToTransform(transform));
        }
    }
}

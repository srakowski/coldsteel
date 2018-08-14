// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Coldsteel.UnitTests
{
    [TestClass]
    public class EntityTests
    {
        private Mock<Component> _mockComponent;
        private Entity _child;
        private Entity _entity;

        [TestInitialize]
        public void Initialize()
        {
            _mockComponent = new Mock<Component>();
            _child = new Entity();
            _entity = new Entity();
        }

        [TestMethod]
        public void AddComponent()
        {
            _entity.AddComponent(_mockComponent.Object);

            Assert.IsTrue(_entity.Components.Contains(_mockComponent.Object));
        }

        [TestMethod]
        public void AddComponent_SetsTheComponentsEntityProperty()
        {
            Assert.IsFalse(_mockComponent.Object.Entity.HasValue);

            _entity.AddComponent(_mockComponent.Object);

            Assert.IsTrue(_mockComponent.Object.Entity.HasValue);
            Assert.AreSame(_mockComponent.Object.Entity.Value, _entity);
        }

        [TestMethod]
        public void AddComponent_MayBeInvokedWhileIteratingOverComponents()
        {
            Enumerable.Range(0, 3)
                .Select(_ => new Mock<Component>())
                .Select(m => m.Object)
                .ToList()
                .ForEach(c => _entity.AddComponent(c));

            foreach (var component in _entity.Components)
            {
                _entity.AddComponent(new Mock<Component>().Object);
            }

            Assert.AreEqual(6, _entity.Components.Count());
        }

        [TestMethod]
        public void AddComponent_MayBeUsedFluently()
        {
            var entity = _entity.AddComponent(_mockComponent.Object);

            Assert.AreSame(_entity, entity);
        }

        [TestMethod]
        public void AddComponent_SetsTheTransformPropertyWhenItReceivesATransform()
        {
            var entity = new Entity();
            Assert.IsFalse(entity.Transform.HasValue);
            var mockTransform = new Mock<Transform>().Object;

            entity.AddComponent(mockTransform);

            Assert.IsTrue(entity.Transform.HasValue);
            Assert.AreSame(mockTransform, entity.Transform.Value);
        }

        [TestMethod]
        public void RemoveComponent()
        {
            _entity.AddComponent(_mockComponent.Object);
            Assert.IsTrue(_entity.Components.Contains(_mockComponent.Object));

            _entity.RemoveComponent(_mockComponent.Object);

            Assert.IsFalse(_entity.Components.Contains(_mockComponent.Object));
        }

        [TestMethod]
        public void RemoveComponent_MayBeInvokedDuringComponentIteration()
        {
            Enumerable.Range(0, 3)
                            .Select(_ => new Mock<Component>())
                            .Select(m => m.Object)
                            .ToList()
                            .ForEach(c => _entity.AddComponent(c));

            foreach (var component in _entity.Components)
            {
                _entity.RemoveComponent(component);
            }

            Assert.AreEqual(0, _entity.Components.Count());
        }

        [TestMethod]
        public void RemoveComponent_MayBeUsedFluently()
        {
            _entity.AddComponent(_mockComponent.Object);

            var entity = _entity.RemoveComponent(_mockComponent.Object);

            Assert.AreSame(_entity, entity);
        }

        [TestMethod]
        public void AddChild()
        {
            _entity.AddChild(_child);

            Assert.IsTrue(_entity.Children.Contains(_child));
        }

        [TestMethod]
        public void AddChild_SetsTheChildsParentPropertyToItself()
        {
            _entity.AddChild(_child);

            Assert.IsTrue(_child.Parent.HasValue);
            Assert.AreSame(_entity, _child.Parent.Value);
        }

        [TestMethod]
        public void AddChild_MayBeInvokedWhileIteratingOverChildren()
        {
            Enumerable
                .Range(0, 3)
                .Select(_ => new Entity())
                .ToList()
                .ForEach(e => _entity.AddChild(e));

            foreach (var entity in _entity.Children)
            {
                _entity.AddChild(new Entity());
            }

            Assert.AreEqual(6, _entity.Children.Count());
        }

        [TestMethod]
        public void AddChild_MayBeUsedFluently()
        {
            var entity = _entity.AddChild(new Entity());

            Assert.AreSame(_entity, entity);
        }

        [TestMethod]
        public void RemoveChild()
        {
            var child = new Entity();
            _entity.AddChild(child);
            Assert.IsTrue(_entity.Children.Contains(child));

            _entity.RemoveChild(child);

            Assert.IsFalse(_entity.Children.Contains(child));
        }

        [TestMethod]
        public void RemoveChild_SetsTheChildsParentToNone()
        {
            var child = new Entity();
            _entity.AddChild(child);
            Assert.AreSame(_entity, child.Parent.Value);

            _entity.RemoveChild(child);

            Assert.IsFalse(child.Parent.HasValue);
        }

        [TestMethod]
        public void RemoveChild_MayBeUsedFluently()
        {
            var child = new Entity();
            _entity.AddChild(child);

            var entity = _entity.RemoveChild(child);

            Assert.AreSame(_entity, entity);
        }

        [TestMethod]
        public void Parent_HasNoValueByDefault()
        {
            Assert.IsFalse(_entity.Parent.HasValue);
        }
    }
}

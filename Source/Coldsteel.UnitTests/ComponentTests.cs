// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coldsteel.UnitTests
{
    [TestClass]
    public class ComponentTests
    {
        private class TestComponent : Component
        {
            public bool OnActivatedInvoked { get; private set; } = false;

            public bool OnDeactivatedInvoked { get; private set; } = false;

            internal override void OnActivated(GameState _)
            {
                OnActivatedInvoked = true;
            }

            internal override void OnDeactivated(GameState _)
            {
                OnDeactivatedInvoked = true;
            }
        }

        private TestComponent _component;

        [TestInitialize]
        public void Initialize()
        {
            _component = new TestComponent();
        }

        [TestMethod]
        public void ActivationLifecyle()
        {
            Assert.IsFalse(_component.IsActive);

            _component.Activate(new GameState());

            Assert.IsTrue(_component.IsActive);
            Assert.IsTrue(_component.OnActivatedInvoked);

            _component.Deactivate();

            Assert.IsFalse(_component.IsActive);
            Assert.IsTrue(_component.OnDeactivatedInvoked);
        }
    }
}

// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel
{
    public abstract class Component
    {
        private protected Engine Engine { get; private set; }

        protected Scene Scene { get; private set; }

        internal protected Entity Entity { get; private set; }

        private protected virtual void Activated() { }

        private protected virtual void Deactivated() { }

        internal void Activate(Engine engine, Scene scene, Entity entity)
        {
            Engine = engine;
            Scene = scene;
            Entity = entity;
            Activated();
        }

        internal void Deactivate()
        {
            Deactivated();
            Entity = null;
            Scene = null;
            Engine = null;
        }
    }
}
// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel
{
    public abstract class Component
    {
        protected Engine Engine { get; private set; }

        protected Scene Scene { get; private set; }

        protected Entity Entity { get; private set; }

        internal protected virtual void Activated() { }

        internal protected virtual void Deactivated() { }

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
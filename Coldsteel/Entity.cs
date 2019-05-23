// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Coldsteel
{
    public class Entity
    {
        private readonly List<Component> _components = new List<Component>();

        private Engine _engine;

        private Scene _scene;

        public Vector2 Position;

        public float Rotation;

        public float Scale = 1f;

        public Matrix TransformMatrix =>
            Matrix.Identity *
            Matrix.CreateRotationZ(this.Rotation) *
            Matrix.CreateScale(this.Scale) *
            Matrix.CreateTranslation(this.Position.X, this.Position.Y, 0f);

        public IEnumerable<Component> Components => _components;

        public Entity AddComponent(Component component)
        {
            _components.Add(component);
            if (_engine != null)
                component.Activate(_engine, _scene, this);
            return this;
        }

        internal void Activate(Engine engine, Scene scene)
        {
            _engine = engine;
            _scene = scene;
            foreach (var component in _components.ToArray())
                component.Activate(engine, scene, this);
        }

        internal void Deactivate()
        {
            foreach (var component in _components)
                component.Deactivate();
            _scene = null;
            _engine = null;
        }
    }
}

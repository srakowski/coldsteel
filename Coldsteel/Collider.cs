// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public abstract class Collider : Component
    {
        private readonly Polygon _shape;

        private protected Collider(Polygon shape)
        {
            _shape = shape;
            Shape = shape;
        }

        internal Polygon Shape;

        public Rectangle Bounds => Shape.Bounds;

        internal void Update()
        {
            Shape = _shape.Transform(Entity.TransformMatrix);
        }

        private protected override void Activated()
        {
            Engine.CollisionSystem.AddCollider(Scene, this);
        }

        private protected override void Deactivated()
        {
            Engine.CollisionSystem.RemoveCollider(Scene, this);
        }
    }
}

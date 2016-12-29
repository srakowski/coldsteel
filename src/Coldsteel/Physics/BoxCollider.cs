// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class BoxCollider : Collider
    {
        private Vector2 _dim;

        private Vector2 _toCorner;

        public float Width
        {
            get { return _dim.X; }
            set
            {
                _dim.X = value;
                _toCorner = _dim / 2f;
            }
        }

        public float Height
        {
            get { return _dim.Y; }
            set
            {
                _dim.Y = value;
                _toCorner = _dim / 2f;
            }
        }

        public Rectangle Bounds =>
            new Rectangle((int)(Position.X - _toCorner.X),
                (int)(Position.Y - _toCorner.Y),
                (int)_dim.X, (int)_dim.Y);

        public float Top => Position.Y - _toCorner.Y;

        public float Left => Position.X - _toCorner.X;

        public float Right => Position.X + _toCorner.X;

        public float Bottom => Position.Y + Height;

        internal override bool Intersects(Collider c)
        {
            if (c is BoxCollider)
            {
                return this.Bounds.Intersects((c as BoxCollider).Bounds);
            }
            else if (c is CircleCollider)
            {
                return Collider.Intersects(this, c as CircleCollider);
            }

            return false;
        }
    }
}

// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class CircleCollider : Collider
    {
        public int Radius { get; set; }

        public CircleCollider(int radius)
        {
            this.Radius = radius;
        }

        internal override bool Intersects(Collider c)
        {
            if (c is CircleCollider)
            {
                return Vector2.Distance(this.Position, c.Position) <=
                    this.Radius + (c as CircleCollider).Radius;
            }
            else if (c is BoxCollider)
            {
                return Collider.Intersects(this, c as BoxCollider);
            }

            return false;
        }
    }
}

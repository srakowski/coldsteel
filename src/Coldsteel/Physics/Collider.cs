// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public abstract class Collider : PhysicsComponent
    {
        internal Polygon Shape { get; set; }

        internal abstract Vector2[] Vertices { get; }

        internal abstract Vector2[] Edges { get; }

        protected Collider()
        {
            Shape = new Polygon();
        }
    }
}

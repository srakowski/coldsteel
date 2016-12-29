// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Linq;
using System;

namespace Coldsteel.Physics
{
    public abstract class Collider : PhysicsComponent
    {
        /// <summary>
        /// If true collision events will trigger with other objects in
        /// the same world, but will not update a Body if one is present, 
        /// and will not affect other Bodies.
        /// </summary>
        public bool IsTrigger { get; set; }

        /// <summary>
        /// Is true if the GameObject this collider belongs to does not
        /// have a Body attached to it in the same World. It will affect 
        /// other, dyanmic Bodies but will remain stationary. If a Body
        /// is present but belongs to another world then it will be true
        /// and the collider is treated as static.
        /// </summary>
        public bool IsStatic => this.Body is StaticBody;

        /// <summary>
        /// Gets the Body that this Collider may affect.
        /// </summary>
        public Body Body => 
            GameObject?.Components.OfType<Body>().FirstOrDefault(b => b.World == this.World) 
            ?? new StaticBody()
            {
                GameObject = this.GameObject
            };

        /// <summary>
        /// Gets the position of the Collider, i.e. the position of the GameObject
        /// plus any PositionOffset;
        /// </summary>
        public Vector2 Position => 
            (GameObject?.Transform?.Position ?? Vector2.Zero) + PositionOffset;

        /// <summary>
        /// Offsets the Collider Position away from the origin that is the position
        /// of the GameObject itself.
        /// </summary>
        public Vector2 PositionOffset { get; set; }

        internal abstract bool Intersects(Collider c);

        protected static bool Intersects(BoxCollider box, CircleCollider circle) =>
            Intersects(circle, box);

        protected static bool Intersects(CircleCollider circle, BoxCollider box)
        {
            var x = MathHelper.Clamp(circle.Position.X, box.Left, box.Right);
            var y = MathHelper.Clamp(circle.Position.Y, box.Bottom, box.Bottom);

            var dx = (circle.Position.X - x) * (circle.Position.X - x);
            var dy = (circle.Position.Y - y) * (circle.Position.Y - y);

            return (dx + dy) <= (float)Math.Pow(circle.Radius, 2);
        }
    }
}

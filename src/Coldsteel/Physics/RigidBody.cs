// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class RigidBody : Component
    {
        /// <summary>
        /// Gets or sets the velocity of the GameObject.
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// A force acting upon this rigid body.
        /// </summary>
        internal Vector2 Force { get; private set; } = Vector2.Zero;

        internal override void Activate(Context context) => 
            context.PhysicsManager.RegisterRigidBody(this);

        public void ApplyForce(Vector2 force)
        {
            Force += force;
        }

        internal void UpdateVelocity(GameTime gameTime)
        {
            Velocity += Force;
            Force = Vector2.Zero;
        }
    }
}

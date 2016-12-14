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

        internal override void Activate(Context context) =>
            context.PhysicsManager.RegisterRigidBody(this);
    }
}

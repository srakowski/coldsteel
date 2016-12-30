// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class Body : PhysicsComponent
    {
        public bool EnableGravity { get; set; } = true;

        public Vector2 Gravity { get; set; } = Vector2.Zero;

        public Vector2 Position
        {
            get { return Transform.Position; }
            set { Transform.Position = value; }
        }

        public Vector2 Acceleration { get; set; } = Vector2.Zero;

        public Vector2 Velocity { get; set; } = Vector2.Zero;

        public Vector2 Drag { get; set; } = Vector2.Zero;

        public Vector2 MaxVelocity { get; set; } = new Vector2(10000, 10000);

        public float Rotation
        {
            get { return Transform.Rotation; }
            set { Transform.Rotation = value; }
        }

        public float AngularVelocity { get; set; } = 0f;

        public float AngularAcceleration { get; set; } = 0f;

        public float AngularDrag { get; set; } = 0f;

        public float MaxAngularVelocity { get; set; } = 1000f;

        public float Mass { get; set; } = 1f;

        public float Bounce { get; set; } = 0f;
    }
}

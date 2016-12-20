// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class Body : Component
    {
        public Vector2 Acceleration { get; set; }

        public Vector2 Velocity { get; set; }

        public float Drag { get; set; }

        public float MaxVelocity { get; set; }
    }
}

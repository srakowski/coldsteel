// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    public class Body : Component
    {
        /// <summary>
        /// All Scenes have at least 1 world with this name. If a world is 
        /// registered to a scene with the same name that world will be used. If
        /// bodies are added to a Scene without specifying a world name then the
        /// world with this name is used.
        /// </summary>
        public static string DefaultWorldName { get; } = "default";

        /// <summary>
        /// The name of the world this Body belongs to.
        /// </summary>
        public string World { get; set; } = DefaultWorldName;

        public bool EnableGravity { get; set; } = true;

        public Vector2 Gravity { get; set; }

        public Vector2 Position
        {
            get { return Transform.Position; }
            set { Transform.Position = value; }
        }

        public Vector2 Acceleration { get; set; }

        public Vector2 Velocity { get; set; }

        public Vector2 Drag { get; set; }

        public Vector2 MaxVelocity { get; set; }

        public float Rotation
        {
            get { return Transform.Rotation; }
            set { Transform.Rotation = value; }
        }

        public float AngularVelocity { get; set; }

        public float AngularAcceleration { get; set; }

        public float AngularDrag { get; set; }

        public float MaxAngularVelocity { get; set; }
    }
}

// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel.Physics
{
    /// <summary>
    /// Stores information about a collision like the game objects involved,
    /// the world it occurred in, and maybe one day if I grow some math skills
    /// collision points, etc...
    /// </summary>
    public class Collision
    {
        /// <summary>
        /// The world this Collision occurred in.
        /// </summary>
        public World World { get; internal set; }

        /// <summary>
        /// One of the Colliders involved in the Collision;
        /// </summary>
        public Collider Collider1 { get; internal set; }

        /// <summary>
        /// One of the GameObjects involved in the Collision.
        /// </summary>
        public GameObject GameObject1 => Collider1.GameObject;

        /// <summary>
        /// The other Collider involved in the Collision.
        /// </summary>
        public Collider Collider2 { get; set; }

        /// <summary>
        /// The other GameObject involved in the Collision.
        /// </summary>
        public GameObject GameObject2 => Collider2.GameObject;
    }
}

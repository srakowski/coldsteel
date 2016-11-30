using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class Transform
    {
        public Transform Parent { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 LocalPosition { get; set; }

        public float Rotation { get; set; }
    }
}

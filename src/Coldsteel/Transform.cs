using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class Transform : GameObjectComponent
    {
        public Vector2 Position
        {
            get { return LocalPosition + (GameObject?.Parent?.Transform?.Position ?? Vector2.Zero); }
            set { LocalPosition = value - (GameObject?.Parent?.Transform?.Position ?? Vector2.Zero); }
        }

        public Vector2 LocalPosition { get; set; }

        public float Rotation { get; set; }

    }
}

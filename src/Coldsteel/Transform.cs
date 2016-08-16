using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class Transform : GameObjectComponent
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get { return _position + (GameObject?.Parent?.Transform?.Position ?? Vector2.Zero); }
            set { _position = value - (GameObject?.Parent?.Transform?.Position ?? Vector2.Zero); }
        }

        public Vector2 LocalPosition
        {
            get { return _position; }
            set { _position = value; }
        }

        public float Rotation { get; set; }
    }
}

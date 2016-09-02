using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel.Physics;

namespace Coldsteel
{
    public class Transform : GameObjectComponent
    {
        internal IBody Body { get; set; }

        public Vector2 Velocity
        {
            get { return Body.Velocity; }
            set { Body.Velocity = value; }
        }

        public Vector2 Position
        {
            get { return Body.Position + (GameObject?.Parent?.Transform?.Position ?? Vector2.Zero); }
            set { Body.Position = value - (GameObject?.Parent?.Transform?.Position ?? Vector2.Zero); }
        }

        public Vector2 LocalPosition
        {
            get { return Body.Position; }
            set { Body.Position = value; }
        }

        public float Rotation
        {
            get { return Body.Rotation; }
            set { Body.Rotation = value; }
        }

        public override void Initialize()
        {
            Body = Body ?? World.PhysicalWorld.CreateBody(this.GameObject);
        }

        public override void Dispose()
        {
            Body?.Dispose();
            Body = null;
        }
    }
}

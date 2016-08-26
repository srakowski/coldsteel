using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Physics
{
    public class RigidBody : GameObjectComponent
    {
        public Vector2 Velocity
        {
            get { return Transform?.Body?.Velocity ?? Vector2.Zero; }
            set { Transform.Body.Velocity = value; }
        }

        public override void Initialize()
        {
            Transform.Body.IsRigid = true;
        }

        public override void Dispose()
        {
            Transform.Body.IsRigid = false;
        }
    }
}

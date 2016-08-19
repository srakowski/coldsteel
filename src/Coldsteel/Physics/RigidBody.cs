using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Physics
{
    public class RigidBody : GameObjectComponent
    {
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Physics
{
    public abstract class Collider : GameObjectComponent
    {
        internal Body Body => GameObject.Body;

        internal override void Initialize()
        {
            Body?.Initialize();
        }
    }
}

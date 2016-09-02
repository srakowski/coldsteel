using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Physics
{
    public abstract class Collider : GameObjectComponent
    {
        public bool Enabled
        {
            get { return Transform.Body.Enabled; }
            set { Transform.Body.Enabled = value; }
        }
    }
}

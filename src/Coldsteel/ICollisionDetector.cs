using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal interface ICollisionDetector
    {
        void DetectCollisions(
            IEnumerable<Collider> colliders, 
            Action<Collider, Collider> onCollision);
    }
}

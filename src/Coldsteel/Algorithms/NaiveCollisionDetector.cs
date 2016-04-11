using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Algorithms
{
    internal class NaiveCollisionDetector : ICollisionDetector
    {
        public void DetectCollisions(IEnumerable<Collider> colliders, Action<Collider, Collider> onCollision)
        {
        }
    }
}

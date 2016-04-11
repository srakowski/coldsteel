using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Algorithms
{
    internal class NaiveCollisionDetector : ICollisionDetector
    {
        public void DetectCollisions(IEnumerable<Collider> colliders, Action<Collider, Collider> onCollision)
        {
            for (var i = 0; i < colliders.Count() - 1; i++)
                for (var j = i + 1; j < colliders.Count(); j++)
                {
                    var collider1 = colliders.ElementAt(i);
                    var bounds1 = collider1.Bounds;

                    var collider2 = colliders.ElementAt(j);
                    var bounds2 = collider2.Bounds;

                    if (bounds1.Intersects(bounds2))
                        onCollision(collider1, collider2);
                }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Coldsteel.Algorithms
{
    internal class NaiveCollisionDetector : ICollisionDetector
    {
        public void DetectCollisions(IEnumerable<Collider> colliders, Action<Collider, Collider> onCollision)
        {
            var dynamicColliders = colliders.Where(c => c.IsDynamic);
            for (var i = 0; i < dynamicColliders.Count(); i++)
            {
                var collider1 = dynamicColliders.ElementAt(i);
                for (var j = 0; j < colliders.Count(); j++)
                {
                    var collider2 = colliders.ElementAt(j);
                    if (collider1 == collider2)
                        continue;

                    var bounds1 = collider1.Bounds;
                    var bounds2 = collider2.Bounds;
                    if (bounds1.Intersects(bounds2))
                        onCollision(collider1, collider2);
                }
            }
        }
    }
}

// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Physics;
using Coldsteel.Scripting;

namespace Derpfender.Behaviors
{
    class EnemyShipBehavior : Behavior
    {
        public override void OnCollision(Collision collision)
        {
            var with = collision.Entity1 == this.Entity
                ? collision.Entity2
                : collision.Entity1;

            if (!with.Tags.Contains("bullet"))
                return;

            Destroy(Entity);
        }
    }
}

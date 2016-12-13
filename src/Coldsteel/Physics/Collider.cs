// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.using System;

namespace Coldsteel.Physics
{
    public abstract class Collider : Component
    {
        internal override void Activate(Context context) =>
            context.PhysicsManager.RegisterCollider(this);
    }
}

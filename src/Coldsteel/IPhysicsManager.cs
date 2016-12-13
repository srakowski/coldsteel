// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Physics;

namespace Coldsteel
{
    internal interface IPhysicsManager
    {
        void RegisterRigidBody(RigidBody rigidBody);
        void RegisterCollider(Collider collider);
    }
}

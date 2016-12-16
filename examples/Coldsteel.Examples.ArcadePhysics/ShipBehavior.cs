// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Physics;
using Coldsteel.Scripting;
using System.Linq;
using static Coldsteel.Physics.Arcade.World;

namespace Coldsteel.Examples.ArcadePhysics
{
    class ShipBehavior : Behavior
    {
        private Physics.Arcade.Body _body;

        public override void Activate()
        {
            _body = GameObject.Components.OfType<Physics.Arcade.Body>().FirstOrDefault();
        }

        public override void Update()
        {
            if (Input.GetButtonControl("Up").IsDown())
            {
                _body.Acceleration = AccelerationFromRotation(Transform.Rotation, 2.0f);
            }
        }
    }
}

// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;

namespace Coldsteel.Physics.Arcade
{
    public class World : Physics.World
    {

        public static Vector2 AccelerationFromRotation(float rotation, float speed) =>
            new Vector2((float)Math.Cos(rotation) * speed, (float)Math.Sin(rotation) * speed);
    }
}

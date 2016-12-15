﻿// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel.Physics.Arcade
{
    public class Body : Physics.Body
    {
        public float Drag { get; set; }

        public float MaxVelocity { get; set; }
    }
}

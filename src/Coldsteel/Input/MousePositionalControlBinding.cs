// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework;

namespace Coldsteel.Input
{
    public class MousePositionalControlBinding : IPositionalControl
    {
        public string Name => "MousePosition";

        public Vector2 GetPosition(PlayerIndex pIdx = PlayerIndex.One) =>
            InputStates.Mouse.CurrentState.Position.ToVector2();
    }
}

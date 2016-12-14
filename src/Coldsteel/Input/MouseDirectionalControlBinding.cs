// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework;

namespace Coldsteel.Input
{
    public class MouseDirectionalControlBinding : IDirectionalControl
    {
        public string Name => "MouseDirection";

        public Vector2 GetDirection(PlayerIndex pIdx = PlayerIndex.One) =>
            InputStates.Mouse.CurrentState.Position.ToVector2() - InputStates.CenterScreen;
    }
}

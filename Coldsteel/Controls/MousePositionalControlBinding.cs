// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Controls
{
    public class MousePositionalControlBinding : PositionalControlBinding
    {
        public MousePositionalControlBinding(PlayerIndex playerIndex = PlayerIndex.One) : base(playerIndex)
        {
        }

        public override Vector2 GetPosition() =>
            InputManager.Mouse.CurrentState.Position.ToVector2();
    }
}

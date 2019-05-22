// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Controls
{
    public abstract class DirectionalControlBinding : ControlBinding
    {
        protected DirectionalControlBinding(PlayerIndex playerIndex) : base(playerIndex)
        {
        }

        public abstract Vector2 GetDirection();
    }
}
// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Controls
{
    public abstract class ButtonControlBinding : ControlBinding
    {
        public ButtonControlBinding(PlayerIndex playerIndex = PlayerIndex.One) : base(playerIndex)
        {
        }

        public abstract bool IsDown();

        public abstract bool IsUp();

        public abstract bool WasDown();

        public abstract bool WasUp();

        public bool WasPushed() =>
            WasUp() && IsDown();

        public bool WasReleased() =>
            WasDown() && IsUp();
    }
}
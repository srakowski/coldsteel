// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public interface IButtonControl : IControl
    {
        bool IsDown(PlayerIndex pIdx = PlayerIndex.One);
        bool WasDown(PlayerIndex pIdx = PlayerIndex.One);
        bool IsUp(PlayerIndex pIdx = PlayerIndex.One);
        bool WasUp(PlayerIndex pIdx = PlayerIndex.One);
        bool WasPressed(PlayerIndex pIdx = PlayerIndex.One);
    }
}

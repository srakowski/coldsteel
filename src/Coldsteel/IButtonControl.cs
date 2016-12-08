// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public interface IButtonControl : IControl
    {
        bool IsDown(PlayerIndex playerIndex = PlayerIndex.One);
        bool IsUp(PlayerIndex playerIndex = PlayerIndex.One);
    }
}

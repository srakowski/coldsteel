// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Input
{
    public interface IButtonControlBinding
    {
        bool IsDown(PlayerIndex pIdx = PlayerIndex.One);

        bool IsUp(PlayerIndex pIdx = PlayerIndex.One);
    }
}

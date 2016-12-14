// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public interface IDirectionalControl : IControl
    {
        Vector2 GetDirection(PlayerIndex pIdx = PlayerIndex.One);
    }
}

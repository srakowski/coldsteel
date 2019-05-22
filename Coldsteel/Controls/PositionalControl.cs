// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel.Controls
{
    public class PositionalControl : Control<PositionalControlBinding>
    {
        public PositionalControl(string name) : base(name)
        {
        }

        public Vector2 GetPosition(PlayerIndex playerIndex = PlayerIndex.One) =>
            // TODO: resolve if you can have more than one binding for this?
            _bindingsByPlayer[(int)playerIndex].FirstOrDefault()?.GetPosition() ?? Vector2.Zero;

    }
}
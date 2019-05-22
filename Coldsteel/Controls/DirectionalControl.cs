// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel.Controls
{
    public class DirectionalControl : Control<DirectionalControlBinding>
    {
        public DirectionalControl(string name) : base(name)
        {
        }

        public Vector2 GetDirection(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex]
                .Select(b => b.GetDirection())
                .Aggregate(Vector2.Zero, (a, b) => a + b);

    }
}
// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Coldsteel.Input
{
    public class PositionalControl : IPositionalControl
    {
        private List<IPositionalControlBinding>[] _bindingsByPlayer = new[]
        {
            new List<IPositionalControlBinding>(),
            new List<IPositionalControlBinding>(),
            new List<IPositionalControlBinding>(),
            new List<IPositionalControlBinding>()
        };

        public string Name { get; set; }

        public PositionalControl(string name)
        {
            this.Name = name;
        }

        public void AddBinding(IPositionalControlBinding binding)
        {
            // TODO: figure this out for more than one player
            _bindingsByPlayer[(int)PlayerIndex.One].Add(binding);
        }

        public Vector2 GetPosition(PlayerIndex playerIndex = PlayerIndex.One) =>
            // TODO: resolve if you can have more than one binding for this?
            _bindingsByPlayer[(int)playerIndex].FirstOrDefault()?.GetPosition(playerIndex) ?? Vector2.Zero;

    }
}
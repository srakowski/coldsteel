// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Coldsteel.Input
{
    public class DirectionalControl : IDirectionalControl
    {
        private List<IDirectionalControlBinding>[] _bindingsByPlayer = new[]
        {
            new List<IDirectionalControlBinding>(),
            new List<IDirectionalControlBinding>(),
            new List<IDirectionalControlBinding>(),
            new List<IDirectionalControlBinding>()
        };

        public string Name { get; set; }

        public DirectionalControl(string name)
        {
            this.Name = name;
        }

        public void AddBinding(IDirectionalControlBinding binding)
        {
            // TODO: figure this out for more than one player
            _bindingsByPlayer[(int)PlayerIndex.One].Add(binding);
        }

        public Vector2 GetDirection(PlayerIndex playerIndex = PlayerIndex.One) =>
            // TODO: resolve if you can have more than one binding for this?
            _bindingsByPlayer[(int)playerIndex].FirstOrDefault()?.GetDirection(playerIndex) ?? Vector2.Zero;

    }
}
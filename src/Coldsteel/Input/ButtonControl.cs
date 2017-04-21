// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Input
{
    public class ButtonControl : IButtonControl
    {
        private List<IButtonControl>[] _bindingsByPlayer = new[]
        {
            new List<IButtonControl>(),
            new List<IButtonControl>(),
            new List<IButtonControl>(),
            new List<IButtonControl>()
        };

        public string Name { get; set; }

        public ButtonControl(string name)
        {
            this.Name = name;
        }

        public void BindTo(IButtonControl binding)
        {
            // TODO: figure this out for more than one player
            _bindingsByPlayer[(int)PlayerIndex.One].Add(binding);
        }

        public bool IsDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.IsDown(playerIndex));

        public bool IsUp(PlayerIndex playerIndex = PlayerIndex.One) => 
            _bindingsByPlayer[(int)playerIndex].All(b => b.IsUp(playerIndex));

        public bool WasDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.IsDown(playerIndex));

        public bool WasUp(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].All(b => b.WasUp(playerIndex));

        public bool WasPressed(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.WasPressed(playerIndex));
    }
}

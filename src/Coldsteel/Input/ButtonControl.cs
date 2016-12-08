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
        private List<IButtonControlBinding>[] _bindingsByPlayer = new[]
        {
            new List<IButtonControlBinding>(),
            new List<IButtonControlBinding>(),
            new List<IButtonControlBinding>(),
            new List<IButtonControlBinding>()
        };

        public string Name { get; set; }

        public ButtonControl(string name)
        {
            this.Name = name;
        }

        public void AddBinding(IButtonControlBinding binding)
        {
            // TODO: figure this out for more than one player
            _bindingsByPlayer[(int)PlayerIndex.One].Add(binding);
        }

        public bool IsDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.IsDown());

        public bool IsUp(PlayerIndex playerIndex = PlayerIndex.One) => 
            _bindingsByPlayer[(int)playerIndex].Any(b => b.IsUp());
    }
}

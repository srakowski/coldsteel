// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Linq;

namespace Coldsteel.Controls
{
    public class ButtonControl : Control<ButtonControlBinding>
    {
        public ButtonControl(string name) : base(name)
        {
        }

        public bool IsDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.IsDown());

        public bool IsUp(PlayerIndex playerIndex = PlayerIndex.One) => 
            _bindingsByPlayer[(int)playerIndex].All(b => b.IsUp());

        public bool WasDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.IsDown());

        public bool WasUp(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].All(b => b.WasUp());

        public bool WasPushed(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.WasPushed());

        public bool WasReleased(PlayerIndex playerIndex = PlayerIndex.One) =>
            _bindingsByPlayer[(int)playerIndex].Any(b => b.WasReleased());
    }
}

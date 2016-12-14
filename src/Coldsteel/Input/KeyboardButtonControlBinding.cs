// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Input
{
    public struct KeyboardButtonControlBinding : IButtonControl
    {
        public string Name => Key.ToString();

        public Keys Key { get; set; }

        public KeyboardButtonControlBinding(Keys key)
        {
            this.Key = key;
        }

        public bool IsDown(PlayerIndex pIdx = PlayerIndex.One) =>
            InputStates.Keyboard.CurrentState.IsKeyDown(this.Key);

        public bool IsUp(PlayerIndex pIdx = PlayerIndex.One) =>
            InputStates.Keyboard.CurrentState.IsKeyUp(this.Key);

        public bool WasDown(PlayerIndex pIdx = PlayerIndex.One) =>
            InputStates.Keyboard.PreviousState.IsKeyDown(this.Key);

        public bool WasUp(PlayerIndex pIdx = PlayerIndex.One) =>
            InputStates.Keyboard.PreviousState.IsKeyUp(this.Key);

        public bool WasPressed(PlayerIndex pIdx = PlayerIndex.One) =>
            WasDown(pIdx) && IsUp(pIdx);
    }
}

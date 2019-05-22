// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Controls
{
    public class KeyboardButtonControlBinding : ButtonControlBinding
    {
        public KeyboardButtonControlBinding(Keys key, PlayerIndex playerIndex = PlayerIndex.One)
            : base(playerIndex)
        {
            Key = key;
        }

        public Keys Key { get; }

        public override bool IsDown() =>
            InputManager.Keyboard.CurrentState.IsKeyDown(this.Key);

        public override bool IsUp() =>
            InputManager.Keyboard.CurrentState.IsKeyUp(this.Key);

        public override bool WasDown() =>
            InputManager.Keyboard.PreviousState.IsKeyDown(this.Key);

        public override bool WasUp() =>
            InputManager.Keyboard.PreviousState.IsKeyUp(this.Key);
    }
}

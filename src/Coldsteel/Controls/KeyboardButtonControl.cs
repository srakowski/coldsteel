using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Controls
{
    public class KeyboardButtonControl : ButtonControl
    {
        public Keys Key { get; private set; }

        public KeyboardButtonControl(Keys key)
        {
            this.Key = key;
        }

        public override bool IsDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            InputManager.CurrentKeyboardState.IsKeyDown(this.Key);
    }
}

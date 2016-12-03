using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Core.Controls
{
    internal class KeyboardButtonControl : ButtonControl
    {
        public Keys Key { get; private set; }

        public KeyboardButtonControl(Keys key)
        {
            this.Key = key;
        }

        public override bool IsDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            Input.CurrentKeyboardState.IsKeyDown(this.Key);
    }
}

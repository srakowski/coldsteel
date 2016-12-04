using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Core.Controls
{
    public class KeyboardButtonControl : ButtonControl
    {
        public Keys Key { get; set; }

        public override bool IsDown(PlayerIndex playerIndex = PlayerIndex.One) =>
            Input.CurrentKeyboardState.IsKeyDown(this.Key);
    }
}

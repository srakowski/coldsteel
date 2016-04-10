using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public class KeyboardButtonControl : ButtonControl
    {
        public Keys KeyboardKey { get; set; }

        public override bool IsDown()
        {
            return InputDevices.CurrentKeyboardState.IsKeyDown(this.KeyboardKey);
        }

        public KeyboardButtonControl(string controlKey, Keys keyboardKey) : base(controlKey)
        {
            this.KeyboardKey = keyboardKey;
        }
    }
}

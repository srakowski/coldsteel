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

        private bool WasDown()
        {
            return InputDevices.PreviousKeyboardState.IsKeyDown(this.KeyboardKey);
        }

        public override bool IsUp()
        {
            return InputDevices.CurrentKeyboardState.IsKeyUp(this.KeyboardKey);
        }

        public override bool WasPressed()
        {
            return WasDown() && IsUp();            
        }

        public KeyboardButtonControl(Keys keyboardKey)
        {
            this.KeyboardKey = keyboardKey;
        }
    }
}

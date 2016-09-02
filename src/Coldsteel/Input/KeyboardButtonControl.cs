using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Input
{
    internal class KeyboardButtonControl : ButtonControl
    {
        public Keys KeyboardKey { get; set; }

        public KeyboardButtonControl(Keys keyboardKey)
        {
            this.KeyboardKey = keyboardKey;
        }

        internal override bool ButtonIsDown()
        {
            return InputDevices.CurrentKeyboardState.IsKeyDown(this.KeyboardKey);
        }

        internal override bool ButtonIsUp()
        {
            return InputDevices.CurrentKeyboardState.IsKeyUp(this.KeyboardKey);
        }

        internal override bool ButtonWasDown()
        {
            return InputDevices.PreviousKeyboardState.IsKeyDown(this.KeyboardKey) && ButtonIsUp();
        }

        internal override bool ButtonWasUp()
        {
            return InputDevices.PreviousKeyboardState.IsKeyUp(this.KeyboardKey) && ButtonIsDown();
        }
    }
}

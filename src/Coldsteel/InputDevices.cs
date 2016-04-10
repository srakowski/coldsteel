using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal static class InputDevices
    {
        public static KeyboardState PreviousKeyboardState { get; private set; } = new KeyboardState();
        public static KeyboardState CurrentKeyboardState { get; private set; } = new KeyboardState();
        public static void Update()
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
        }
    }
}

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
        public static GamePadState PreviousGamePadState { get; private set; } = new GamePadState();
        public static GamePadState CurrentGamePadState { get; private set; } = new GamePadState();
        public static MouseState CurrentMouseState { get; private set; } = new MouseState();
        public static MouseState PreviousMouseState { get; private set; } = new MouseState();
        public static void Update()
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
            PreviousGamePadState = CurrentGamePadState;
            CurrentGamePadState = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One, GamePadDeadZone.Circular);
            PreviousMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
        }
    }
}

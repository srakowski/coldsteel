using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core.Controls
{
    internal static class Input
    {
        internal static KeyboardState PreviousKeyboardState { get; set; } = new KeyboardState();

        internal static KeyboardState CurrentKeyboardState { get; set; } = new KeyboardState();

        internal static GamePadState PreviousGamePadState { get; set; } = new GamePadState();

        internal static GamePadState CurrentGamePadState { get; set; } = new GamePadState();

        internal static MouseState CurrentMouseState { get; set; } = new MouseState();

        internal static MouseState PreviousMouseState { get; set; } = new MouseState();

        internal static void Update(GameTime gameTime)
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

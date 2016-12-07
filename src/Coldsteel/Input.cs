// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Controls
{
    /// <summary>
    /// Maintains current and previous input device states for the purposes
    /// of evaluating user input. 
    /// </summary>
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

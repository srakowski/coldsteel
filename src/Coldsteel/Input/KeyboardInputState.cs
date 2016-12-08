// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Input
{
    /// <summary>
    /// Maintains Previous and Current keyboard state for control evaluation.
    /// </summary>
    internal class KeyboardInputState : IInputState<KeyboardState>
    {
        public KeyboardState PreviousState { get; private set; } = new KeyboardState();

        public KeyboardState CurrentState { get; private set; } = new KeyboardState();

        public void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Keyboard.GetState();
        }
    }
}

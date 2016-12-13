// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Input
{
    /// <summary>
    /// Maintains Previous and Current Mouse state for control evaluation.
    /// </summary>
    internal class MouseInputState : IInputState<MouseState>
    {
        public MouseState PreviousState { get; private set; } = new MouseState();

        public MouseState CurrentState { get; private set; } = new MouseState();

        public void Update()
        {
            PreviousState = CurrentState;
            CurrentState = Mouse.GetState();
        }
    }
}

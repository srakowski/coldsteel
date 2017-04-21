// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static Coldsteel.Input.MouseButtons;

namespace Coldsteel.Input
{
    public class MouseButton : IButtonControl
    {
        public string Name => $"{_button}Mouse";

        private MouseButtons _button;

        public MouseButton(MouseButtons button)
        {
            _button = button;
        }

        public bool IsDown(PlayerIndex pIdx = PlayerIndex.One) =>
            IsButtonInState(InputStates.Mouse.CurrentState, ButtonState.Pressed);

        public bool IsUp(PlayerIndex pIdx = PlayerIndex.One) =>
            IsButtonInState(InputStates.Mouse.CurrentState, ButtonState.Released);

        public bool WasDown(PlayerIndex pIdx = PlayerIndex.One) =>
            IsButtonInState(InputStates.Mouse.PreviousState, ButtonState.Pressed);

        public bool WasUp(PlayerIndex pIdx = PlayerIndex.One) =>
            IsButtonInState(InputStates.Mouse.PreviousState, ButtonState.Released);

        public bool WasPressed(PlayerIndex pIdx = PlayerIndex.One) => WasDown(pIdx) && IsUp(pIdx);

        private bool IsButtonInState(MouseState mouseState, ButtonState state)
        {
            var isDown = false;

            switch (_button)
            {
                case Left:
                    isDown = mouseState.LeftButton == state;
                    break;

                case Right:
                    isDown = mouseState.RightButton == state;
                    break;

                case Center:
                    isDown = mouseState.MiddleButton == state;
                    break;
            }

            return isDown;
        }
    }
}

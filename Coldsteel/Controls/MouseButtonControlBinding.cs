// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static Coldsteel.Controls.MouseButton;

namespace Coldsteel.Controls
{
    public class MouseButtonControlBinding : ButtonControlBinding
    {
        private MouseButton _button;

        public MouseButtonControlBinding(MouseButton button, PlayerIndex playerIndex = PlayerIndex.One)
            : base(playerIndex)
        {
            _button = button;
        }

        public override bool IsDown() =>
            IsButtonInState(InputManager.Mouse.CurrentState, ButtonState.Pressed);

        public override bool IsUp() =>
            IsButtonInState(InputManager.Mouse.CurrentState, ButtonState.Released);

        public override bool WasDown() =>
            IsButtonInState(InputManager.Mouse.PreviousState, ButtonState.Pressed);

        public override bool WasUp() =>
            IsButtonInState(InputManager.Mouse.PreviousState, ButtonState.Released);

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

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public enum MouseButton
    {
        Left,
        Right,
        Middle
    }

    public class MouseButtonControl : ButtonControl
    {
        public override bool IsDown()
        {
            return _mouseButton == MouseButton.Left ? InputDevices.MouseState.LeftButton == ButtonState.Pressed :
                _mouseButton == MouseButton.Right ? InputDevices.MouseState.RightButton == ButtonState.Pressed :
                _mouseButton == MouseButton.Middle ? InputDevices.MouseState.MiddleButton == ButtonState.Pressed :
                false;
        }

        private MouseButton _mouseButton;

        public MouseButtonControl(MouseButton mouseButton)
        {
            _mouseButton = mouseButton;
        }
    }
}

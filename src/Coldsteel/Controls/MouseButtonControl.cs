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
            return _mouseButton == MouseButton.Left ? InputDevices.CurrentMouseState.LeftButton == ButtonState.Pressed :
                _mouseButton == MouseButton.Right ? InputDevices.CurrentMouseState.RightButton == ButtonState.Pressed :
                _mouseButton == MouseButton.Middle ? InputDevices.CurrentMouseState.MiddleButton == ButtonState.Pressed :
                false;
        }

        private bool WasDown()
        {
            return _mouseButton == MouseButton.Left ? InputDevices.PreviousMouseState.LeftButton == ButtonState.Pressed :
                _mouseButton == MouseButton.Right ? InputDevices.PreviousMouseState.RightButton == ButtonState.Pressed :
                _mouseButton == MouseButton.Middle ? InputDevices.PreviousMouseState.MiddleButton == ButtonState.Pressed :
                false;
        }

        public override bool IsUp()
        {
            return _mouseButton == MouseButton.Left ? InputDevices.CurrentMouseState.LeftButton == ButtonState.Released :
                _mouseButton == MouseButton.Right ? InputDevices.CurrentMouseState.RightButton == ButtonState.Released :
                _mouseButton == MouseButton.Middle ? InputDevices.CurrentMouseState.MiddleButton == ButtonState.Released :
                false;
        }

        public override bool WasPressed()
        {
            return IsUp() && WasDown();
        }

        private MouseButton _mouseButton;

        public MouseButtonControl(MouseButton mouseButton)
        {
            _mouseButton = mouseButton;
        }
    }
}

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public enum GamePadButton
    {
        A,
        B,
        X,
        Y,
        DPadUp,
        DPadDown,
        DPadLeft,
        DPadRight
    }

    public class GamePadButtonControl : ButtonControl
    {
        private GamePadButton _gamePadButton;

        public override bool IsDown()
        {
            return
                _gamePadButton == GamePadButton.A ? InputDevices.CurrentGamePadState.Buttons.A == ButtonState.Pressed :
                _gamePadButton == GamePadButton.B ? InputDevices.CurrentGamePadState.Buttons.B == ButtonState.Pressed :
                _gamePadButton == GamePadButton.X ? InputDevices.CurrentGamePadState.Buttons.X == ButtonState.Pressed :
                _gamePadButton == GamePadButton.Y ? InputDevices.CurrentGamePadState.Buttons.Y == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadUp ? InputDevices.CurrentGamePadState.DPad.Up == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadDown ? InputDevices.CurrentGamePadState.DPad.Down == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadLeft ? InputDevices.CurrentGamePadState.DPad.Left == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadRight ? InputDevices.CurrentGamePadState.DPad.Right == ButtonState.Pressed :
                false;
        }

        public bool WasDown()
        {
            return
                _gamePadButton == GamePadButton.A ? InputDevices.PreviousGamePadState.Buttons.A == ButtonState.Pressed :
                _gamePadButton == GamePadButton.B ? InputDevices.PreviousGamePadState.Buttons.B == ButtonState.Pressed :
                _gamePadButton == GamePadButton.X ? InputDevices.PreviousGamePadState.Buttons.X == ButtonState.Pressed :
                _gamePadButton == GamePadButton.Y ? InputDevices.PreviousGamePadState.Buttons.Y == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadUp ? InputDevices.PreviousGamePadState.DPad.Up == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadDown ? InputDevices.PreviousGamePadState.DPad.Down == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadLeft ? InputDevices.PreviousGamePadState.DPad.Left == ButtonState.Pressed :
                _gamePadButton == GamePadButton.DPadRight ? InputDevices.PreviousGamePadState.DPad.Right == ButtonState.Pressed :
                false;
        }

        public override bool IsUp()
        {
            return
                _gamePadButton == GamePadButton.A ? InputDevices.CurrentGamePadState.Buttons.A == ButtonState.Released :
                _gamePadButton == GamePadButton.B ? InputDevices.CurrentGamePadState.Buttons.B == ButtonState.Released :
                _gamePadButton == GamePadButton.X ? InputDevices.CurrentGamePadState.Buttons.X == ButtonState.Released :
                _gamePadButton == GamePadButton.Y ? InputDevices.CurrentGamePadState.Buttons.Y == ButtonState.Released :
                _gamePadButton == GamePadButton.DPadUp ? InputDevices.CurrentGamePadState.DPad.Up == ButtonState.Released :
                _gamePadButton == GamePadButton.DPadDown ? InputDevices.CurrentGamePadState.DPad.Down == ButtonState.Released :
                _gamePadButton == GamePadButton.DPadLeft ? InputDevices.CurrentGamePadState.DPad.Left == ButtonState.Released :
                _gamePadButton == GamePadButton.DPadRight ? InputDevices.CurrentGamePadState.DPad.Right == ButtonState.Released :
                false;
        }

        public override bool WasPressed()
        {
            return WasDown() && IsUp();
        }

        public GamePadButtonControl(GamePadButton gamePadButton)
        {
            this._gamePadButton = gamePadButton;
        }
    }
}

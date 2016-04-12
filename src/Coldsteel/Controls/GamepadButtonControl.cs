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

        public GamePadButtonControl(string controlKey, GamePadButton gamePadButton) : base(controlKey)
        {
            this._gamePadButton = gamePadButton;
        }
    }
}

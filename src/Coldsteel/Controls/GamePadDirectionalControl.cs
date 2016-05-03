using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel.Controls
{
    public enum DirectionalControlType
    {
        Invalid = 0,
        LeftThumbStick,
        RightThumbStick
    }

    public class GamePadDirectionalControl : DirectionalControl
    {
        private DirectionalControlType _type;

        public GamePadDirectionalControl(DirectionalControlType type)
        {
            this._type = type;
        }

        public override Vector2 Direction()
        {
            if (_type == DirectionalControlType.LeftThumbStick)
                return InputDevices.CurrentGamePadState.ThumbSticks.Left * new Vector2(1, -1);
            if (_type == DirectionalControlType.RightThumbStick)
                return InputDevices.CurrentGamePadState.ThumbSticks.Right * new Vector2(1, -1);

            return Vector2.Zero;
        }
    }
}

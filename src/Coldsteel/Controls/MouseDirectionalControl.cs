using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel.Controls
{
    public class MouseDirectionalControl : DirectionalControl
    {
        public override Vector2 Direction()
        {
            return InputDevices.MouseState.Position.ToVector2() - _screenCenter;
        }

        private Vector2 _screenCenter;

        public MouseDirectionalControl(Vector2 screenCenter)
        {
            _screenCenter = screenCenter;
        }
    }
}

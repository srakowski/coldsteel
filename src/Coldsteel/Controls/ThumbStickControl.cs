using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel.Controls
{
    public class ThumbStickControl : DirectionalControl
    {
        public override Vector2 Direction()
        {
            return InputDevices.CurrentGamePadState.ThumbSticks.Left;
        }
    }
}

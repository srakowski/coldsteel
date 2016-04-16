using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public abstract class PositionalControl : Control
    {
        public Vector2 GetPosition()
        {
            return InputDevices.CurrentMouseState.Position.ToVector2();
        }
    }
}

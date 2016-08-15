using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Input
{
    public class ButtonControl : Control
    {
        public ButtonControl Keyboard(Keys primary, Keys? alt = null)
        {
            return this;
        }
    }
}

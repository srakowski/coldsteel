using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public abstract class ButtonControl : Control
    {
        public bool IsDown(PlayerIndex playerIndex = PlayerIndex.One) => false;
    }
}

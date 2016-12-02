﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public abstract class ButtonControl : Control
    {
        public abstract bool IsDown(PlayerIndex playerIndex = PlayerIndex.One);
    }
}

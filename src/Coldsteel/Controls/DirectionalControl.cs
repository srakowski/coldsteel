using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public abstract class DirectionalControl : Control
    {
        public abstract Vector2 Direction { get; }
    }
}

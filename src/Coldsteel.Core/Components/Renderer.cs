using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Core.Components
{
    internal abstract class Renderer : Component
    {
        public string Layer { get; set; }
        internal abstract void Render(SpriteBatch spriteBatch);
    }
}

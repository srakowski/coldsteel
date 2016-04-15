using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public interface IGraphicsService
    {
        Viewport DefaultViewport { get; }
        void Clear(Color color);
    }
}

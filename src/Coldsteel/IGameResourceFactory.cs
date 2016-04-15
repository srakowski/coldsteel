using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public interface IGameResourceFactory
    {
        IContentManager CreateContentManager();
        IGraphicsService CreateGraphicsService();
        SpriteBatch CreateSpriteBatch();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Renderer : GameObjectComponent
    {
        public abstract void Render(IGameTime gameTime);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Renderer : GameObjectComponent
    {
        public Layer Layer { get; set; }

        public Renderer(Layer layer)
        {
            this.Layer = layer;
        }

        public abstract void Render(IGameTime gameTime);
    }
}

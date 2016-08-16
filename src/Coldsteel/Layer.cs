using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Rendering;

namespace Coldsteel
{
    public class Layer
    {
        private List<Renderer> _renderers = new List<Renderer>();

        internal Layer()
        {
        }

        internal void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _renderers.ForEach(r => r.Render(gameTime, spriteBatch));
        }

        internal void AddRenderer(Renderer renderer)
        {
            if (renderer == null)
                return;

            _renderers.Add(renderer);
        }

        internal void RemoveRenderer(Renderer renderer)
        {
            if (renderer == null)
                return;

            _renderers.Remove(renderer);
        }
    }
}

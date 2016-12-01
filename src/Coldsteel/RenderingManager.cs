using Coldsteel.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coldsteel
{
    class RenderingManager
    {
        private Game _game;

        private SpriteBatch _spriteBatch;

        public RenderingManager(Game game)
        {
            _game = game;
        }

        internal void Initialize() =>
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);

        internal void Render(Scene scene)
        {
            _game.GraphicsDevice.Clear(Color.Black);

            // TODO: don't look this up every frame ok?
            var renderers = scene.GameObjects.SelectMany(go => go.Components.Where(c => c is Renderer).Select(c => c as Renderer));
            foreach (var layer in scene.Layers.OrderBy(l => l.Order))
            {
                var renderersThisLayer = renderers.Where(r => r.Layer == layer.Name || (layer.IsDefault && string.IsNullOrEmpty(r.Layer)));
                layer.Render(_spriteBatch, renderersThisLayer);
            }
        }
    }
}

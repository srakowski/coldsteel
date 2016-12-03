using Coldsteel.Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Coldsteel.Core
{
    public class RenderingManager : DrawableGameComponent
    {
        private SceneManager _sceneManager;

        private SpriteBatch _spriteBatch;

        public RenderingManager(Game game, SceneManager sceneManager)
            : base(game)
        {
            _sceneManager = sceneManager;
        }

        public override void Initialize()
        {
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);

            if (_sceneManager.ActiveScene == null)
                return;

            // TODO: don't look this up every frame ok?
            var renderers = _sceneManager.ActiveScene.GameObjects.SelectMany(go => go.Components.Where(c => c is Renderer).Select(c => c as Renderer));
            foreach (var layer in _sceneManager.ActiveScene.Layers.OrderBy(l => l.Order))
            {
                var renderersThisLayer = renderers.Where(r => r.Layer == layer.Name || (layer.IsDefault && string.IsNullOrEmpty(r.Layer)));
                layer.Render(_spriteBatch, renderersThisLayer);
            }
        }
    }
}

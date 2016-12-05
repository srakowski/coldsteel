using Coldsteel.Core.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System;

namespace Coldsteel.Core
{
    public class RenderingManager : DrawableGameComponent
    {
        private SceneManager _sceneManager;

        private SpriteBatch _spriteBatch;

        private Texture2D _logo;

        public RenderingManager(Game game, SceneManager sceneManager)
            : base(game)
        {
            _sceneManager = sceneManager;
        }

        public override void Initialize()
        {
            base.Initialize();
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        protected override void LoadContent()
        {
            try
            {
                _logo = Game.Content.Load<Texture2D>("gameLogo");
            }
            catch { }
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(new Color(55, 55, 55));

            if (_sceneManager.ActiveScene == null)
            {
                DrawLogo();
                return;
            }

            // TODO: don't look this up every frame ok?
            var renderers = _sceneManager.ActiveScene.GameObjects.SelectMany(go => go.Components.Where(c => c is Renderer).Select(c => c as Renderer));
            foreach (var layer in _sceneManager.ActiveScene.Layers.OrderBy(l => l.Order))
            {
                var renderersThisLayer = renderers.Where(r => r.Layer == layer.Name || (layer.IsDefault && string.IsNullOrEmpty(r.Layer)));
                layer.Render(_spriteBatch, renderersThisLayer);
            }
        }

        private void DrawLogo()
        {
            if (_logo == null)
                return;

            _spriteBatch.Begin();
            _spriteBatch.Draw(_logo,
                color: Color.White,
                position: new Vector2(Game.GraphicsDevice.Viewport.Width * 0.5f, Game.GraphicsDevice.Viewport.Height * 0.5f),
                origin: new Vector2(_logo.Width * 0.5f, _logo.Height * 0.5f));
            _spriteBatch.End();
        }
    }
}

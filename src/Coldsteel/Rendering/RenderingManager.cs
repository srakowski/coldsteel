// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Linq;

namespace Coldsteel.Rendering
{
    /// <summary>
    /// Is responsible for orchestrating the rendering of GameObjects in a Scene
    /// to the Layers that Scene is composed of.
    /// </summary>
    internal class RenderingManager : DrawableGameComponent
    {
        private ISceneManager _sceneManager;

        private SpriteBatch _spriteBatch;

        private Texture2D _logo;

        public RenderingManager(Game game) : base(game) { }

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager = Game.Services.GetService<ISceneManager>();
            _sceneManager.SceneActivated += _sceneManager_SceneActivated;
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
            Game.GraphicsDevice.Clear(_sceneManager?.ActiveScene?.BackgroundColor ?? new Color(55, 55, 55));

            if (_sceneManager.ActiveScene == null)
            {
                DrawLogo();
                return;
            }

            var layers = _sceneManager.ActiveScene.Elements.OfType<Layer>();

            // TODO: don't look this up every frame mmkay?
            var camera = _sceneManager.ActiveScene.GameObjects.SelectMany(go => go.Components.Where(c => c is Camera)).Select(c => c as Camera).FirstOrDefault();

            // TODO: don't look this up every frame ok?
            var renderers = _sceneManager.ActiveScene.GameObjects.SelectMany(go => go.Components.Where(c => c is Renderer).Select(c => c as Renderer));
            foreach (var layer in layers.OrderBy(l => l.Order))
            {
                var renderersThisLayer = renderers.Where(r => r.Layer == layer.Name || (layer.Name == Renderer.DefaultLayerName && string.IsNullOrEmpty(r.Layer)));
                layer.Render(_spriteBatch, renderersThisLayer, camera);
            }
        }

        private void _sceneManager_SceneActivated(object sender, SceneActivatedEventArgs e)
        {
            var existingLayers = e.Scene.Elements.OfType<Layer>();
            if (!existingLayers.Any(l => l.Name == Renderer.DefaultLayerName))
                e.Scene.AddElement(new Layer(Renderer.DefaultLayerName, 0));
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

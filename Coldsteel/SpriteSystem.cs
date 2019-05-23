// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    internal class SpriteSystem : DrawableGameComponent
    {
        private readonly Dictionary<Scene, List<Sprite>> _spritesByScene = new Dictionary<Scene, List<Sprite>>();

        private readonly Dictionary<Scene, List<Camera>> _camerasByScene = new Dictionary<Scene, List<Camera>>();

        private readonly Engine _engine;

        private SpriteBatch _spriteBatch;

        public SpriteSystem(Game game, Engine engine) : base(game)
        {
            _engine = engine;
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            base.Initialize();
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        internal void AddSprite(Scene scene, Sprite sprite)
        {
            var spriteList = GetSpriteListForScene(scene);
            spriteList.Add(sprite);
        }

        internal void RemoveSprite(Scene scene, Sprite sprite)
        {
            var spriteList = GetSpriteListForScene(scene);
            spriteList.Remove(sprite);
        }

        private List<Sprite> GetSpriteListForScene(Scene scene)
        {
            return _spritesByScene.ContainsKey(scene)
                ? _spritesByScene[scene]
                : (_spritesByScene[scene] = new List<Sprite>());
        }

        internal void AddCamera(Scene scene, Camera camera)
        {
            var cameraList = GetCameraListForScene(scene);
            cameraList.Add(camera);
        }

        internal void RemoveCamera(Scene scene, Camera camera)
        {
            var cameraList = GetCameraListForScene(scene);
            cameraList.Remove(camera);
        }

        private List<Camera> GetCameraListForScene(Scene scene)
        {
            return _camerasByScene.ContainsKey(scene)
                ? _camerasByScene[scene]
                : (_camerasByScene[scene] = new List<Camera>());
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);

            var scene = _engine.SceneManager.ActiveScene;
            if (scene == null) return;

            var sprites = GetSpriteListForScene(scene);
            var camera = GetCameraListForScene(scene).FirstOrDefault(c => c.Enabled);
            foreach (var spriteLayer in scene.SpriteLayers.OrderBy(s => s.Depth))
            {
                var spritesThisLayer = sprites.Where(s => s.Enabled && s.SpriteLayerName == spriteLayer.Name);
                spriteLayer.Draw(_spriteBatch, camera, spritesThisLayer);
            }
        }
    }
}

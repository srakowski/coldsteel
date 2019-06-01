// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Coldsteel
{
    internal class UISystem : DrawableGameComponent
    {
        private readonly Dictionary<Scene, List<UIHost>> _uiHostsByScene = new Dictionary<Scene, List<UIHost>>();

        private readonly Engine _engine;

        private SpriteBatch _spriteBatch;

        public UISystem(Game game, Engine engine) : base(game)
        {
            _engine = engine;
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            base.Initialize();
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        internal void AddUIHost(Scene scene, UIHost uiHost)
        {
            var uiHostList = GetUIHostsForScene(scene);
            uiHostList.Add(uiHost);
        }

        internal void RemoveUIHost(Scene scene, UIHost uiHost)
        {
            var uiHostList = GetUIHostsForScene(scene);
            uiHostList.Remove(uiHost);
        }

        private List<UIHost> GetUIHostsForScene(Scene scene)
        {
            return _uiHostsByScene.ContainsKey(scene)
                ? _uiHostsByScene[scene]
                : (_uiHostsByScene[scene] = new List<UIHost>());
        }

        public override void Update(GameTime gameTime)
        {
            var scene = _engine.SceneManager.ActiveScene;
            if (scene == null) return;

            var uiHosts = GetUIHostsForScene(scene);
            foreach (var uiHost in uiHosts.ToArray())
            {
                uiHost.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
        }
    }
}

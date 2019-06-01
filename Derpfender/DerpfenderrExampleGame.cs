// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Derpfender
{
    public class DerpfenderExampleGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly Engine _engine;

        public DerpfenderExampleGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _engine = new Engine(this, new EngineConfig(
                new SceneFactory(),
                Enumerable.Empty<Control>()
            ));
        }

        protected override void Initialize()
        {
            base.Initialize();
            _engine.LoadScene(nameof(Scenes.MainMenu));
        }
    }
}
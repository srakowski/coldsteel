// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class Engine : GameComponent
    {
        public Engine(Game game, EngineConfig config) : base(game)
        {
            Config = config;
            game.Components.Add(this);
            SceneManager = new SceneManager(game, this, config.SceneFactory);
            CollisionSystem = new CollisionSystem(game, this);
            InputManager = new InputManager(game, this);
            BehaviorSystem = new BehaviorSystem(game, this);
            SpriteSystem = new SpriteSystem(game, this);
        }

        internal EngineConfig Config;

        internal SceneManager SceneManager;

        internal CollisionSystem CollisionSystem;

        internal InputManager InputManager;

        internal BehaviorSystem BehaviorSystem;

        internal SpriteSystem SpriteSystem;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Input;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using static Coldsteel.Helpers.TypeHelper;

namespace Coldsteel.Composition
{
    /// <summary>
    /// Bootstraps the Game based on the "game.xml" Configuration.Game content.
    /// </summary>
    public class Bootstrapper : GameComponent
    {
        private SceneManager _sceneManager;

        private InputManager _inputManager;

        private IEnumerator _tasks;

        public Bootstrapper(Game game) : base(game)
        {
            _sceneManager = new SceneManager(game);
            game.Components.Add(_sceneManager);
            game.Components.Add(new PhysicsManager(game));
            _inputManager = new InputManager(game);
            game.Components.Add(_inputManager);
            game.Components.Add(new ScriptingManager(game));
            game.Components.Add(new RenderingManager(game));
        }

        public override void Initialize()
        {
            base.Initialize();
            var gameConfiguration = LoadGameConfiguration();
            Game.Window.Title = gameConfiguration.Title;
            _tasks = LoadGame(gameConfiguration);
        }

        public override void Update(GameTime gameTime)
        {
            if (!_tasks.MoveNext())
                Game.Components.Remove(this);
        }

        private GameConfig LoadGameConfiguration()
        {
            GameConfig config = null;
            try
            {
                config = Game.Content.Load<GameConfig>("game");
            }
            catch
            {
                config = new GameConfig();
            }

            config.GameCompositionMethod =
                config.GameCompositionMethod ??
                CodeBasedGameComposer.GameCompositionMethodKey;

            config.StartupScene = config.StartupScene ?? FindStartupScene();

            return config;
        }

        private string FindStartupScene() =>
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetCustomAttribute(typeof(StartupSceneAttribute)) != null)
                .FirstOrDefault()?.Name;
            
        private IEnumerator LoadGame(GameConfig gameConfig)
        {
            foreach (var reference in gameConfig?.References ?? Enumerable.Empty<string>())
            {
                yield return $"loading assembly {reference}";
                Assembly.LoadFrom(reference);
            }

            yield return "creating game composer";
            var gameComposer = CreateGameComposer(gameConfig.GameCompositionMethod);
            Game.Services.AddService<ISceneFactory>(gameComposer.CreateSceneFactory());

            yield return "configuring input";
            gameComposer.ConfigureInput(_inputManager);

            yield return $"starting scene {gameConfig.StartupScene}";
            _sceneManager.Start(gameConfig.StartupScene);
        }

        private static IGameComposer CreateGameComposer(string compositionMethod)
        {
            if (compositionMethod.Equals(CodeBasedGameComposer.GameCompositionMethodKey, StringComparison.OrdinalIgnoreCase))
                return new CodeBasedGameComposer();

            throw new Exception($"Unrecognized GameCompositionMethod must be one of" + 
                " \"{CodeBasedGameComposer.CompositionMethodKey}\", ...");
        }
    }
}

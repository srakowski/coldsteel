// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Input;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Reflection;

namespace Coldsteel
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
            _inputManager = new InputManager(game);
            game.Components.Add(_inputManager);
            game.Components.Add(new ScriptingManager(game));
            game.Components.Add(new RenderingManager(game));
        }

        public override void Initialize()
        {
            base.Initialize();
            var gameConfiguration = Game.Content.Load<Configuration.Game>("game");
            Game.Window.Title = gameConfiguration.Title;
            _tasks = Begin(gameConfiguration);
        }

        public override void Update(GameTime gameTime)
        {
            if (!_tasks.MoveNext())
                Game.Components.Remove(this);
        }

        private IEnumerator Begin(Configuration.Game gameConfiguration)
        {
            foreach (var reference in gameConfiguration.References)
            {
                yield return $"loading assembly {reference}";
                Assembly.LoadFrom(reference);
            }

            yield return "creating game composer";
            var gameComposerType = TypeHelper.FindType(gameConfiguration.GameComposerType);
            var gameComposer = Activator.CreateInstance(gameComposerType) as IGameComposer;

            yield return "configuring input";
            gameComposer.ConfigureInput(_inputManager);

            yield return "creating scene composer";
            var sceneComposerType = TypeHelper.FindType(gameConfiguration.SceneComposerType);
            var sceneComposer = Activator.CreateInstance(sceneComposerType) as ISceneComposer;
            Game.Services.AddService<ISceneComposer>(sceneComposer);

            yield return $"starting scene {gameConfiguration.StartupScene}";
            _sceneManager.Start(gameConfiguration.StartupScene);
        }
    }
}

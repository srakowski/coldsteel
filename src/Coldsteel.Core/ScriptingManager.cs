using Coldsteel.Core.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coldsteel.Core
{
    public class ScriptingManager : GameComponent
    {
        private SceneManager _sceneManager;

        public ScriptingManager(Game game, SceneManager sceneManager)
            : base(game)
        {
            _sceneManager = sceneManager;
        }

        public override void Update(GameTime gameTime)
        {
            if (_sceneManager.ActiveScene == null)
                return;

            var behaviors = _sceneManager.ActiveScene.GameObjects.SelectMany(go => go.Components.Where(c => c is Behavior).Select(c => c as Behavior));

            foreach (var behavior in behaviors)
            {
                behavior.GameTime = gameTime;
                behavior.Update();
            }

            foreach (var behavior in behaviors)
            {
                behavior.UpdateCoroutines();
            }
        }
    }
}

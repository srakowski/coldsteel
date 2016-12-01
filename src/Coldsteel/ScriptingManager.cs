using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coldsteel
{
    class ScriptingManager
    {
        private Game _game;

        public ScriptingManager(Game game)
        {
            this._game = game;
        }

        internal void Initialize()
        {
        }

        internal void Update(GameTime gameTime, Scene scene)
        {
            var behaviors = scene.GameObjects.SelectMany(go => go.Components.Where(c => c is Behavior).Select(c => c as Behavior));
            foreach (var behavior in behaviors)
            {
                behavior.GameTime = gameTime;
                behavior.Update();
            }
        }
    }
}

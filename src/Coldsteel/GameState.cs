using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel.Input;

namespace Coldsteel
{
    public abstract class GameState
    {
        public ContentManager Load { get; private set; }

        public InputManager Input { get; private set;  }

        public GameStage Stage { get; private set; }

        public GameStateManager State { get; private set; }

        public World World { get; private set; }

        public virtual void Preload() { }

        public virtual void Create() { }

        internal void Update(GameTime gameTime)
        {
        }

        internal void Render(GameTime gameTime)
        {
        }
    }
}

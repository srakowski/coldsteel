using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Coldsteel.Input;

namespace Coldsteel
{
    public abstract class GameState
    {
        public ContentManager Load { get; internal set; }

        public InputManager Input { get; internal set;  }

        public GameStateManager State { get; internal set; }

        public GameStage Stage { get; internal set; }

        public LayerManager Layers { get; internal set; }

        public World World { get; internal set; }

        public Camera Camera { get; internal set; }

        public virtual void Preload() { }

        public virtual void Create() { }

        internal void Update(GameTime gameTime)
        {
            World.Update(gameTime);
        }

        internal void Render(GameTime gameTime)
        {
            Stage.Render(gameTime, Camera, Layers);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public abstract class Scene
    {
        public SceneManager SceneManager { get; internal set; }

        public ContentBundle Content { get; internal set; }

        protected LayerCollection Layers { get; private set; } = new LayerCollection();

        protected GameObjectCollection GameObjects { get; private set; } = new GameObjectCollection();

        public abstract void Configure();

        internal void Initialize()
        {
        }

        internal void Update(GameTime gameTime)
        {
        }

        internal void Render(GameTime gameTime)
        {
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Linq;
using Coldsteel.Components;

namespace Coldsteel
{
    public abstract class Scene
    {
        public SceneManager SceneManager { get; internal set; }

        public ContentBundle Content { get; internal set; }

        public LayerCollection Layers { get; private set; }

        public GameObjectCollection GameObjects { get; private set; }

        public Scene()
        {
            Layers = new LayerCollection();
            GameObjects = new GameObjectCollection(this);
        }

        public abstract void Configure();

        internal void Initialize() =>
            GameObjects.Initialize();
    }
}

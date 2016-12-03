using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Linq;
using Coldsteel.Core.Components;

namespace Coldsteel.Core
{
    public class Scene
    {
        internal SceneManager SceneManager { get; set; }

        internal ContentManager Content { get; set; }

        internal ControlsManager Controls { get; set; }

        internal LayerCollection Layers { get; private set; }

        internal GameObjectCollection GameObjects { get; private set; }

        public Scene()
        {
            Layers = new LayerCollection();
            GameObjects = new GameObjectCollection(this);
        }

        internal void Initialize() =>
            GameObjects.Initialize();
    }
}

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
        internal string Name { get; set; }

        internal ContentCache Content { get; set; }

        internal ControlsManager Controls { get; set; }

        internal LayerCollection Layers { get; set; }

        internal GameObjectCollection GameObjects { get; set; }

        public Scene()
        {
            this.Name = string.Empty;
            this.Content = new ContentCache();
            this.Controls = new ControlsManager();
            this.Layers = new LayerCollection();
            this.GameObjects = new GameObjectCollection(this);
        }

        internal void Initialize() =>
            GameObjects.Initialize();
    }
}

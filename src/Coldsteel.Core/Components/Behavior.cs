using Coldsteel.Core.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core.Components
{
    internal abstract class Behavior : Component
    {
        protected Transform Transform => GameObject?.Transform;

        protected ControlsManager Controls => GameObject?.Scene?.Controls;

        public GameTime GameTime { get; internal set; }

        public float Delta => (float)(GameTime?.ElapsedGameTime.TotalMilliseconds ?? 0f);

        public virtual void Update() { }
    }
}

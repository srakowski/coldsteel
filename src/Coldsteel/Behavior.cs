using Coldsteel.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Behavior : Component
    {
        protected Transform Transform => GameObject?.Transform;

        protected InputManager Input { get; set; }

        public virtual void Initialize() { }

        public virtual void Update() { }
    }
}

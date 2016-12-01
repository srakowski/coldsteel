using Coldsteel.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Component : IComponent
    {
        public GameObject GameObject { get; set; }
        public virtual void Initialize() { }
    }
}

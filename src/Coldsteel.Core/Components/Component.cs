using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core.Components
{
    public abstract class Component : IComponent
    {
        public GameObject GameObject { get; set; }
        public virtual void Initialize() { }
    }
}

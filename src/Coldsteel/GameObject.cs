using Coldsteel.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class GameObject
    {
        private List<IComponent> _components = new List<IComponent>();

        public Transform Transform { get; private set; } = new Transform();

        public void Add(IComponent component)
        {
            component.GameObject = this;
            _components.Add(component);
        }
    }
}

using Coldsteel.Components;
using System.Collections.Generic;

namespace Coldsteel
{
    public class GameObject
    {
        private List<IComponent> _components = new List<IComponent>();

        public IEnumerable<IComponent> Components => _components;

        public Transform Transform { get; private set; } = new Transform();

        public Scene Scene { get; internal set; }

        private bool _isInitialized = false;

        internal void Initialize()
        {
            _components.ForEach(component => component.Initialize());
            _isInitialized = true;
        }

        public void Add(IComponent component)
        {
            component.GameObject = this;
            if (_isInitialized)
                component.Initialize();

            _components.Add(component);
        }
    }
}

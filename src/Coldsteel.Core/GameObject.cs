using Coldsteel.Core.Components;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Core
{
    public class GameObject
    {
        public string Name { get; private set; }

        private List<IComponent> _components = new List<IComponent>();

        public IEnumerable<IComponent> Components => _components;

        // TODO: make this not lookup every time
        public Transform Transform => _components.FirstOrDefault(c => c is Transform) as Transform;

        public Scene Scene { get; internal set; }

        private bool _isInitialized = false;

        public GameObject(string name)
        {
            Name = name;
        }

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

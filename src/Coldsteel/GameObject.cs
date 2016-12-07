// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    /// <summary>
    /// Representative of some object in the game, visual or otherwise. These
    /// are the building blocks on which a Scene is built.
    /// </summary>
    public class GameObject
    {
        private List<Component> _components;

        /// <summary>
        /// The name of this GameObject.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Components that define this GameObject's state, 
        /// behavior, and visual representation.
        /// </summary>
        public IEnumerable<Component> Components => _components;

        /// <summary>
        /// Constructs an empty GameObject with only a Transform component.
        /// </summary>
        public GameObject() : this(Enumerable.Empty<Component>()) { }

        /// <summary>
        /// Constructs a GameObject with the provided components. If no
        /// Transform component is provided then one will be added.
        /// </summary>
        /// <param name="components"></param>
        public GameObject(IEnumerable<Component> components)
        {
            _components = new List<Component>(components);
            if (!_components.OfType<Transform>().Any())
                _components.Add(new Transform());
        }
    }
}

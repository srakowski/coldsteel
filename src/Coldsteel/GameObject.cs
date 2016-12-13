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
    public class GameObject : ISceneElement
    {
        private List<Component> _components;

        private bool _activated = false;

        private Context _context;

        /// <summary>
        /// The name of this GameObject.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tags used to identify this GameObject in various contexts.
        /// </summary>
        public List<string> Tags { get; } = new List<string>();

        /// <summary>
        /// Gets the Components that define this GameObject's state, 
        /// behavior, and visual representation.
        /// </summary>
        public IEnumerable<Component> Components => _components;

        /// <summary>
        /// Gets the transform component of this GameObject.
        /// </summary>
        public Transform Transform => _components.OfType<Transform>().First();

        /// <summary>
        /// Whether or not this GameObject is destroyed.
        /// </summary>
        public bool IsDestroyed { get; private set; }

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

        /// <summary>
        /// Adds a component to this GameObject.
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(Component component)
        {
            _components.Add(component);
            if (_activated)
            {
                component.GameObject = this;
                component.Activate(_context);
            }
        }

        /// <summary>
        /// The GameObject is created and composed, but there is work that
        /// may need to be done to get it ready for gameplay. This is done
        /// in the activation step.
        /// </summary>
        internal void Activate(Context context)
        {
            _context = context;
            _activated = true;
            _components.ForEach(c =>
            {
                c.GameObject = this;
                c.Activate(context);
            });
        }

        /// <summary>
        /// Destroys the GameObject.
        /// </summary>
        internal void Destroy()
        {
            this.IsDestroyed = true;
        }
    }
}

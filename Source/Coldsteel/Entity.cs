// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    /// <summary>
    /// Represents some object in a Game.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Gets the components that make up this Entity.
        /// </summary>
        public IEnumerable<Component> Components { get; private set; } = Enumerable.Empty<Component>();

        /// <summary>
        /// Adds a component (set of properties tied to a system) to this Entity.
        /// </summary>
        /// <param name="component"></param>
        /// <returns>this Entity</returns>
        public Entity AddComponent(Component component)
        {
            component.Entity = this;
            Components = Components.Append(component).ToArray();
            return this;
        }

        /// <summary>
        /// Removes a Component from this Entity.
        /// </summary>
        /// <param name="object"></param>
        /// <returns>this Entity</returns>
        public Entity RemoveComponent(Component component)
        {
            Components = Components.Exclude(component).ToArray();
            return this;
        }

        /// <summary>
        /// Get's this Entity's parent, if any.
        /// </summary>
        public Maybe<Entity> Parent { get; private set; }

        /// <summary>
        /// Get's this Entity's children.
        /// </summary>
        public IEnumerable<Entity> Children { get; private set; } = Enumerable.Empty<Entity>();

        /// <summary>
        /// Adds a child to this Entity.
        /// </summary>
        /// <param name="child"></param>
        /// <returns>this Entity</returns>
        public Entity AddChild(Entity child)
        {
            child.Parent = this;
            Children = Children.Append(child).ToArray();
            return this;
        }

        /// <summary>
        /// Removes a child from this Entity.
        /// </summary>
        /// <param name="child"></param>
        /// <returns>this Entity</returns>
        public Entity RemoveChild(Entity child)
        {
            child.Parent = Maybe.None<Entity>();
            Children = Children.Exclude(child).ToArray();
            return this;
        }
    }
}

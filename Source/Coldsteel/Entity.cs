﻿// MIT License - Copyright (C) Shawn Rakowski
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
        /// Gets the Transform for this Entity, if any.
        /// </summary>
        /// <remarks>Many systems rely on Transforms, including transforms. Here for fast lookup.</remarks>
        public Maybe<Transform> Transform { get; private set; }

        /// <summary>
        /// Gets the components that make up this Entity.
        /// </summary>
        public IEnumerable<Component> Components { get; private set; } = Enumerable.Empty<Component>();

        /// <summary>
        /// Is this Entity active?
        /// </summary>
        internal bool IsActive { get; private set; }

        /// <summary>
        /// Activates this Entity.
        /// </summary>
        internal void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// Deactivates this Entity;
        /// </summary>
        internal void Deactivate()
        {
            IsActive = false;
        }

        /// <summary>
        /// Adds a component (set of properties tied to a system) to this Entity.
        /// </summary>
        /// <param name="component"></param>
        /// <returns>this Entity</returns>
        public Entity AddComponent(Component component)
        {
            component.Entity = this;

            if (IsActive && !component.IsActive)
            {
                component.Activate();
            }

            Components = Components.Append(component).ToArray();
            Transform = component is Transform t ? t : Transform;
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
            component.Deactivate();
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

            if (IsActive && !child.IsActive)
            {
                child.Activate();
            }

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
            child.Deactivate();
            return this;
        }
    }
}

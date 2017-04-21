// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    /// <summary>
    /// Representative of some object in the game, visual or otherwise. These
    /// are the building blocks on which a Scene is built.
    /// </summary>
    public class Entity : SceneElement
    {
        private List<Component> _components;

        private bool _isActivated = false;

        private bool _isDestroyed = false;

        private Context _context;

        /// <summary>
        /// The name of this Entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tags used to identify this Entity in various contexts.
        /// </summary>
        public List<string> Tags { get; } = new List<string>();

        /// <summary>
        /// Gets the Components that define this Entity's state, 
        /// behavior, and visual representation.
        /// </summary>
        public IEnumerable<Component> Components => _components;

        /// <summary>
        /// Gets the transform component of this Entity.
        /// </summary>
        public Transform Transform => _components.OfType<Transform>().First();

        /// <summary>
        /// Whether or not this Entity is destroyed.
        /// </summary>
        public override bool IsDestroyed => _isDestroyed;

        /// <summary>
        /// Constructs an empty Entity with only a Transform component.
        /// </summary>
        public Entity() : this(Enumerable.Empty<Component>()) { }

        /// <summary>
        /// Constructs a Entity with the provided components. If no
        /// Transform component is provided then one will be added.
        /// </summary>
        /// <param name="components"></param>
        public Entity(IEnumerable<Component> components)
        {
            _components = new List<Component>(components);
            if (!_components.OfType<Transform>().Any())
                _components.Add(new Transform());
        }

        /// <summary>
        /// Adds a component to this Entity.
        /// </summary>
        /// <param name="component"></param>
        public Entity AddComponent(Component component)
        {
            _components.Add(component);
            if (_isActivated)
            {
                component.Entity = this;
                component.Activate(_context);
            }
            return this;
        }

        internal void RemoveComponent(Component component)
        {
            _components.Remove(component);
            // TODO: add deactivate
        }

        /// <summary>
        /// The Entity is created and composed, but there is work that
        /// may need to be done to get it ready for gameplay. This is done
        /// in the activation step.
        /// </summary>
        internal override void Activate(Context context)
        {
            _context = context;
            _isActivated = true;
            var componentsToActivate = _components.ToList();
            componentsToActivate.ForEach(c =>
            {
                c.Entity = this;
                c.Activate(context);
            });
        }

        /// <summary>
        /// Destroys the Entity.
        /// </summary>
        internal void Destroy()
        {
            this._isDestroyed = true;
            foreach (var child in this.Transform.Children.Select(t => t.Entity))
                child.Destroy();
        }

        /// <summary>
        /// Broadcasts to this Entities components a message.
        /// </summary>
        /// <param name="message"></param>
        internal void DispatchMessage(object message)
        {
            var components = _components.ToArray();
            foreach (var component in _components)
                component.HandleMessage(message);
        }

        public Entity SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public Entity AddTag(string tag)
        {
            this.Tags.Add(tag);
            return this;
        }

        public Entity AddTags(string tag, params string[] tags)
        {
            this.Tags.Add(tag);
            this.Tags.AddRange(tags);
            return this;
        }

        public Entity SetPosition(float x, float y)
        {
            this.Transform.LocalPosition = new Vector2(x, y);
            return this;
        }

        public Entity SetPosition(Vector2 position)
        {
            this.Transform.LocalPosition = position;
            return this;
        }

        public Entity SetRotation(float rotationInRadians)
        {
            this.Transform.LocalRotation = rotationInRadians;
            return this;
        }

        public Entity SetRotationInDegrees(float rotationInDegrees)
        {
            this.Transform.Rotation = MathHelper.ToRadians(rotationInDegrees);
            return this;
        }

        public Entity SetScale(float scale)
        {
            this.Transform.Scale = scale;
            return this;
        }

        public Entity SetParent(Entity gameObject)
        {
            this.Transform.SetParent(gameObject.Transform);
            return this;
        }
    }
}

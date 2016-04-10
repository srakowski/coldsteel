using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    /// <summary>
    /// A composite game entity. All things in the game are GameObjects.
    /// </summary>
    public class GameObject
    {
        #region Composite Functionality

        /// <summary>
        /// The parent of this GameObject if added as a child to another.
        /// </summary>
        public GameObject Parent { get; private set; }

        /// <summary>
        /// Sets the parent of the GameObject.
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(GameObject parent)
        {
            if (this.Parent == parent)
                return;

            var oldParent = this.Parent;
            this.Parent = parent;

            if (oldParent?.IsAncestorOf(this) ?? false)
                oldParent?.RemoveChild(this);

            if (!(this.Parent?.IsAncestorOf(this) ?? true))
                this.Parent.AddChild(this);
        }

        private List<GameObject> _children = new List<GameObject>();

        /// <summary>
        /// GameObjects that are children of this GameObject that should be affected by
        /// modifications to this GameObject and it's parent
        /// </summary>
        public IEnumerable<GameObject> Children { get { return _children; } }

        /// <summary>
        /// Adds a child to this GameObject.
        /// </summary>
        /// <param name="child"></param>
        public GameObject AddChild(GameObject child)
        {
            if (child == this)
                throw new ArgumentException("GameObject may not parent itself");

            if (child.IsAncestorOf(this))
                throw new ArgumentException("GameObject may not be descendant of itself");

            _children.Add(child);
            child.SetParent(this);

            return this;
        }

        /// <summary>
        /// Is the provided GameObject a descendent of this GameObject?
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool IsAncestorOf(GameObject gameObject)
        {
            if (_children.Contains(gameObject))
                return true;

            foreach (var directChild in _children)
                if (directChild.IsAncestorOf(gameObject))
                    return true;

            return false;
        }

        /// <summary>
        /// Is the provided GameObject an ancestor of this GameObject?
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public bool IsDescendantOf(GameObject gameObject)
        {
            return Parent == gameObject || (Parent?.IsDescendantOf(gameObject) ?? false);
        }

        /// <summary>
        /// Removes a child from this GameObject.
        /// </summary>
        /// <param name="child"></param>
        public void RemoveChild(GameObject child)
        {
            child.SetParent(null);
            if (this.IsAncestorOf(child))
                _children.Remove(child);
        }

        #endregion

        #region Component Functionality

        private List<GameObjectComponent> _components = new List<GameObjectComponent>();

        /// <summary>
        /// Gets the components on this GameObject
        /// </summary>
        public IEnumerable<GameObjectComponent> Components
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Adds a GameoObjectComponent to this GameObject.
        /// </summary>
        /// <param name="component"></param>
        public GameObject AddComponent(GameObjectComponent component)
        {
            EnforceSingleComponent<Transform>(component);
            EnforceSingleComponent<Renderer>(component);
            component.AttachGameObject(this);
            _components.Add(component);
            return this;
        }

        /// <summary>
        /// Checks for more than one of the provided component type and throws and exception if one already exists on this GameObject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        private void EnforceSingleComponent<T>(GameObjectComponent component) where T : GameObjectComponent
        {
            if (!(component is T))
                return;

            if (this.GetComponent<T>() == null)
                return;

            throw new InvalidOperationException(String.Format("GameObject my only have 1 {0} component", typeof(T).Name));
        }

        /// <summary>
        /// Gets the GameObjectComponent of a given type. If multiple of same type then returns null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : GameObjectComponent
        {
            var components = GetComponents<T>();
            if (components.Count() > 1)
                throw new InvalidOperationException(String.Format("object has multiple components matching type"));

            return components.FirstOrDefault();
        }

        /// <summary>
        /// Gets all GameObjectComponents of a given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetComponents<T>() where T : GameObjectComponent
        {
            return _components.Where(x => x is T).Select(x => x as T);
        }

        /// <summary>
        /// Removes a GameObjectComponent from this GameObject.
        /// </summary>
        /// <param name="component"></param>
        public void RemoveComponent(GameObjectComponent component)
        {
            _components.Remove(component);
            component.DetachGameObject(this);
        }

        #endregion

        #region Game Loop Functionality

        /// <summary>
        /// Gets the Stage this GameObject belongs to.
        /// </summary>
        public GameStage GameStage { get; internal set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public GameObject()
        {
            AddComponent(new Transform());
        }

        /// <summary>
        /// Construction/initialization helper to set the initial position of the object.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public GameObject SetPosition(Vector2 position)
        {
            var transform = GetComponent<Transform>();
            transform.Position = position;
            return this;
        }

        /// <summary>
        /// Invoked when Input should be handled.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="input"></param>
        public void HandleInput(IGameTime gameTime, Input input)
        {
            var behaviors = GetComponents<Behavior>();
            foreach (var behavior in behaviors)
                behavior.HandleInput(gameTime, input);
        }

        /// <summary>
        /// Invoked when this GameObject should be updated.
        /// </summary>
        public void Update(IGameTime gameTime)
        {
            var componentsToUpdate = _components.ToList();
            componentsToUpdate.ForEach((c) => c.Update(gameTime));
        }

        /// <summary>
        /// Invoked when this GameObject should be rendered.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Render(IGameTime gameTime)
        {
            var renderer = GetComponent<Renderer>();
            renderer?.Render(gameTime);
        }

        #endregion
    }
}

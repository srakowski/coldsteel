using System;
using System.Linq;
using System.Collections.Generic;

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

        #region Component Management

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
            if (component is Transform)
                if (this.GetComponent<Transform>() != null)
                    throw new InvalidOperationException("GameObject my only have 1 Transform component");

            component.AttachGameObject(this);
            _components.Add(component);
            return this;
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

        /// <summary>
        /// Constructor
        /// </summary>
        public GameObject()
        {
            AddComponent(new Transform());
        }

        /// <summary>
        /// Update this GameObject.
        /// </summary>
        public void Update(IGameTime gameTime)
        {
            var componentsToUpdate = _components.ToList();
            componentsToUpdate.ForEach((c) => c.Update(gameTime));
        }
    }
}

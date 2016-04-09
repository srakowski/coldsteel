using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    /// <summary>
    /// A component of a GameObject.
    /// </summary>
    public abstract class GameObjectComponent
    {
        /// <summary>
        /// The GameObject this Behavior is atteched to.
        /// </summary>
        public GameObject GameObject { get; private set; }

        /// <summary>
        /// Provides the ability to attach this behavior to a GameObject.
        /// </summary>
        /// <param name="gameObject"></param>
        internal void AttachGameObject(GameObject gameObject)
        {
            this.GameObject = gameObject;
        }

        /// <summary>
        /// Detaches the GameObject if attached.
        /// </summary>
        /// <param name="gameObject"></param>
        internal void DetachGameObject(GameObject gameObject)
        {
            if (this.GameObject != gameObject)
                return;

            this.GameObject = null;
        }

        /// <summary>
        /// Gets the Transform of the GameObject this Behavior is applied to.
        /// </summary>
        protected Transform Transform { get { return GameObject?.GetComponent<Transform>(); } }

        /// <summary>
        /// Update the Component.
        /// </summary>
        public virtual void Update(IGameTime gameTime) { }
    }
}

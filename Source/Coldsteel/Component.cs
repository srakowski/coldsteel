// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

namespace Coldsteel
{
    /// <summary>
    /// Data for an Entity tied to a System.
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// The Entity this Component is bound to, if any.
        /// </summary>
        public Maybe<Entity> Entity { get; internal set; }

        /// <summary>
        /// Is this component currently activated?
        /// </summary>
        internal bool IsActive { get; private set; }

        /// <summary>
        /// Activates this component.
        /// </summary>
        internal void Activate()
        {
            IsActive = true;
        }

        /// <summary>
        /// Deactivates this component.
        /// </summary>
        internal void Deactivate()
        {
            IsActive = false;
        }
    }
}

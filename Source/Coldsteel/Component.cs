// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System;

namespace Coldsteel
{
    /// <summary>
    /// Data for an Entity tied to a System.
    /// </summary>
    public abstract class Component
    {
        private Maybe<GameState> _gameState = Maybe.None<GameState>();

        /// <summary>
        /// The Entity this Component is bound to, if any.
        /// </summary>
        public Maybe<Entity> Entity { get; internal set; }

        /// <summary>
        /// Is this component currently activated?
        /// </summary>
        internal bool IsActive => _gameState.HasValue;

        /// <summary>
        /// Activates this component.
        /// </summary>
        internal void Activate(GameState gameState)
        {
            _gameState = gameState;
            OnActivated(gameState);
        }

        /// <summary>
        /// Optional override for additional work when activated.
        /// </summary>
        internal virtual void OnActivated(GameState gameState) { }

        /// <summary>
        /// Deactivates this component.
        /// </summary>
        internal void Deactivate()
        {
            OnDeactivated(_gameState.Value);
            _gameState = Maybe.None<GameState>();
        }

        /// <summary>
        /// Optional override for additional work when deactivated.
        /// </summary>
        internal virtual void OnDeactivated(GameState gameState) { }
    }
}

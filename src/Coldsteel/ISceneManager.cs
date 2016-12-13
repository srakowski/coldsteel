// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace Coldsteel
{
    /// <summary>
    /// Public contract for the SceneManager component.
    /// </summary>
    public interface ISceneManager
    {
        /// <summary>
        /// Is triggered when the ActiveScene is updated.
        /// </summary>
        event EventHandler<EventArgs> ActiveSceneChanged;

        /// <summary>
        /// The currently active scene.
        /// </summary>
        Scene ActiveScene { get; }

        /// <summary>
        /// Transitions the game to play the scene with the provided name.
        /// </summary>
        /// <param name="sceneName"></param>
        void Start(string sceneName);
    }
}

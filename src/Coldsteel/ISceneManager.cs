﻿// MIT License - Copyright (C) Shawn Rakowski
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
        event EventHandler<SceneActivatedEventArgs> SceneActivated;

        /// <summary>
        /// The currently active scene.
        /// </summary>
        Scene ActiveScene { get; }

        /// <summary>
        /// Transitions the scene returned by the provided function.
        /// </summary>
        /// <param name="scene"></param>
        void Start(Func<Scene> scene);
    }
}

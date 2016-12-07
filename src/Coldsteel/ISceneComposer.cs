// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel
{
    /// <summary>
    /// Required Service.
    /// Providers implementing this service are responsible for composing 
    /// gameplay scenes. Coldsteel requires a provider to implement this 
    /// interface and be added to Game.Services collection.
    /// </summary>
    public interface ISceneComposer
    {
        /// <summary>
        /// Used to compose and configure a scene for gameplay.
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        Scene ComposeScene(string sceneName);
    }
}

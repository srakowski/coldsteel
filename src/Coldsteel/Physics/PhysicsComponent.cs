// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel.Physics
{
    public abstract class PhysicsComponent : Component
    {
        /// <summary>
        /// All Scenes have at least 1 world with this name. If a world is 
        /// registered to a scene with the same name that world will be used. If
        /// bodies are added to a Scene without specifying a world name then the
        /// world with this name is used.
        /// </summary>
        public static string DefaultWorldName { get; } = "default";

        /// <summary>
        /// The name of the world this Body belongs to.
        /// </summary>
        public string World { get; set; } = DefaultWorldName;
    }
}

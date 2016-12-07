// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel.Configuration
{
    public class Game
    {
        /// <summary>
        /// The title of this Game.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Assembly references required for this Game.
        /// </summary>
        public string[] References { get; set; }

        /// <summary>
        /// The name of the Scene that should be loaded when the Game is Loaded.
        /// </summary>
        public string StartupScene { get; set; }
    }
}

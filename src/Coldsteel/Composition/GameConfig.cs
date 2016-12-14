// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Content;

namespace Coldsteel.Composition
{
    public class GameConfig
    {
        /// <summary>
        /// The title of this Game.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Assembly references required for this Game.
        /// </summary>
        [ContentSerializer(Optional = true)]
        public string[] References { get; set; }

        /// <summary>
        /// The method used to compose the game. Coded or ...
        /// </summary>
        public string GameCompositionMethod { get; set; }

        /// <summary>
        /// The name of the Scene that should be loaded when the Game is Loaded.
        /// </summary>
        public string StartupScene { get; set; }
    }
}
// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

namespace Microsoft.Xna.Framework
{
    public static class MonoGameExtensions
    {
        public static Game AddColdsteelGameEngine(this Game game)
        {
            game.Components.Add(new Coldsteel.GameEngine(game));
            return game;
        }
    }
}

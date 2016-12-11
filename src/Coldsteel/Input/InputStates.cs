// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel.Input
{
    internal static class InputStates
    {
        public static Vector2 CenterScreen { get; set; } = Vector2.Zero;

        public static KeyboardInputState Keyboard { get; } = new KeyboardInputState();

        public static MouseInputState Mouse { get; } = new MouseInputState();

        public  static GamePadInputState[] GamePads = new[]
        {
            new GamePadInputState(PlayerIndex.One),
            new GamePadInputState(PlayerIndex.Two),
            new GamePadInputState(PlayerIndex.Three),
            new GamePadInputState(PlayerIndex.Four)
        };
    }
}

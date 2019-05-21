using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel
{
    internal static class Input
    {
        private static InputState GetState(PlayerIndex pi = PlayerIndex.One)
        {
            return new InputState(
                Keyboard.GetState(),
                Mouse.GetState(),
                GamePad.GetState(pi)
            );
        }
    }

    internal struct InputState
    {
        public InputState(
            KeyboardState kb,
            MouseState ms,
            GamePadState gp)
        {
            Keyboard = kb;
            Mouse = ms;
            GamePad = gp;
        }

        public KeyboardState Keyboard { get; }

        public MouseState Mouse { get; }

        public GamePadState GamePad { get; }
    }
}

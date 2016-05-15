using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Controls
{
    public class KeyboardDirectionalControl : DirectionalControl
    {
        private Keys _up, _left, _down, _right;

        // Creates a directional control with the defined directions, defaults to "WASD".
        public KeyboardDirectionalControl(
            Keys up = Keys.W,
            Keys left = Keys.A, 
            Keys down = Keys.S,
            Keys right = Keys.D)
        {
            _up = up;
            _left = left;
            _down = down;
            _right = right;
        }

        public override Vector2 Direction()
        {
            Vector2 direction = Vector2.Zero;

            if (InputDevices.CurrentKeyboardState.IsKeyDown(_up))
            {
                direction += new Vector2(0, -1);
            }

            if (InputDevices.CurrentKeyboardState.IsKeyDown(_left))
            {
                direction += new Vector2(-1, 0);
            }

            if (InputDevices.CurrentKeyboardState.IsKeyDown(_down))
            {
                direction += new Vector2(0, 1);
            }

            if (InputDevices.CurrentKeyboardState.IsKeyDown(_right))
            {
                direction += new Vector2(1, 0);
            }

            if (direction.Length() > 1)
            {
                direction.Normalize();
            }

            return direction;
        }
    }
}

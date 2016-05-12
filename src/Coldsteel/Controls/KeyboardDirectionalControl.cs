using Microsoft.Xna.Framework;

namespace Coldsteel.Controls
{
    public class KeyboardDirectionalControl : DirectionalControl
    {
        private Microsoft.Xna.Framework.Input.Keys _up, _left, _down, _right;

        // Creates a directional control with the defined directions, defaults to "WASD".
        public KeyboardDirectionalControl(
            Microsoft.Xna.Framework.Input.Keys up = Microsoft.Xna.Framework.Input.Keys.W,
            Microsoft.Xna.Framework.Input.Keys left = Microsoft.Xna.Framework.Input.Keys.A, 
            Microsoft.Xna.Framework.Input.Keys down = Microsoft.Xna.Framework.Input.Keys.S,
            Microsoft.Xna.Framework.Input.Keys right = Microsoft.Xna.Framework.Input.Keys.D)
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

            return direction;
        }
    }
}

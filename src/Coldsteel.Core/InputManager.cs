using Coldsteel.Core.Controls;
using Microsoft.Xna.Framework;

namespace Coldsteel.Core
{
    public class InputManager : GameComponent
    {
        public InputManager(Game game)
            : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Input.Update(gameTime);
        }
    }
}

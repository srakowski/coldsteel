using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Rendering
{
    public interface IRenderer
    {
        void Render(GameTime gameTime, SpriteBatch spriteBatch);
    }
}

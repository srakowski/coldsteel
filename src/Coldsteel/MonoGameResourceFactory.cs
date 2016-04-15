using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class MonoGameResourceFactory : IGameResourceFactory
    {
        private Game _game;

        public MonoGameResourceFactory(Game game)
        {
            _game = game;
        }

        public IContentManager CreateContentManager()
        {
            var gameContentManager = _game.Content;
            var contentManager = new ContentManager(
                gameContentManager.ServiceProvider, gameContentManager.RootDirectory);
            return new ContentManagerWrapper(contentManager);
        }

        public IGraphicsService CreateGraphicsService()
        {
            return new MonoGameGraphicsService(_game);
        }

        public SpriteBatch CreateSpriteBatch()
        {
            return new SpriteBatch(_game.GraphicsDevice);
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class ColdsteelGameComponent : DrawableGameComponent
    {
        private SceneManager _sceneManager;

        public ColdsteelGameComponent(Game game) : base(game)
        {
            _sceneManager = new SceneManager(game.Content);
        }

        public void Start<T>() where T : Scene, new() =>
            _sceneManager.Start<T>();

        public override void Initialize()
        {
            base.Initialize();
            _sceneManager.Initialize();
        }

        public override void Update(GameTime gameTime) =>
            _sceneManager.Update(gameTime);

        public override void Draw(GameTime gameTime) =>
            _sceneManager.Render(gameTime);
    }
}

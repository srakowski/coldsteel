using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Coldsteel.Core
{
    public class SceneManager : GameComponent
    {
        private SceneBuilder _sceneBuilder;

        public event EventHandler<EventArgs> ActiveSceneChanged;

        public Scene ActiveScene { get; private set; }

        public ISceneDirector SceneDirector { get; set; }

        public SceneManager(Game game) : base(game)
        {
             _sceneBuilder = new SceneBuilder(Game.Content);
        }

        public void Start(string sceneId) =>
            SceneDirector?.BeginConstruction(sceneId, _sceneBuilder);

        public override void Update(GameTime gameTime)
        {
            SceneDirector?.Update();
            if (_sceneBuilder.HasResult)
            {
                var newScene = _sceneBuilder.GetResult();
                newScene.Initialize();
                ActiveScene = newScene;
                ActiveSceneChanged?.Invoke(this, null);
            }
        }
    }
}

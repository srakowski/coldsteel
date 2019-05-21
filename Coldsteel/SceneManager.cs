using Microsoft.Xna.Framework;

namespace Coldsteel
{
    internal class SceneManager : GameComponent
    {
        private Scene _pendingScene;
        private Scene _activeScene;

        private readonly Engine _engine;

        private readonly ISceneFactory _sceneFactory;

        public SceneManager(Game game, Engine engine, ISceneFactory sceneFactory) : base(game)
        {
            _engine = engine;
            _sceneFactory = sceneFactory;
            game.Components.Add(this);
        }

        public Scene ActiveScene => _activeScene;

        internal void LoadScene(string sceneName)
        {
            var scene = _sceneFactory.Create(sceneName);
            _pendingScene = scene;
        }

        public override void Update(GameTime gameTime)
        {
            if (_pendingScene == null) return;

            _activeScene.Deactivate();
            _pendingScene.Activate(_engine);
            _activeScene = _pendingScene;
            _pendingScene = null;
        }
    }
}

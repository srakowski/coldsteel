using Coldsteel.Composition;
using Coldsteel.Core;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Coldsteel
{
    public class ColdsteelGame : Game
    {
        GraphicsDeviceManager _graphics;

        GameComposer _gameComposer;

        private SceneManager _sceneManager;

        private InputManager _inputManager;

        private ScriptingManager _scriptingManager;

        private RenderingManager _renderingManager;

        public ColdsteelGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _gameComposer = new GameComposer();

            _sceneManager = new SceneManager(this);

            _inputManager = new InputManager(this);
            Components.Add(_inputManager);

            _scriptingManager = new ScriptingManager(this, _sceneManager);
            Components.Add(_scriptingManager);

            _renderingManager = new RenderingManager(this, _sceneManager);
            Components.Add(_renderingManager);
        }

        protected override void Initialize()
        {
            base.Initialize();
            Debugger.Break();
            var gameConfig = Content.Load<Configuration.Game>("game");
            _sceneManager.SceneCatalog = _gameComposer.Compose(Content, gameConfig);
            _sceneManager.Start();

            //_sceneManager.Initialize();
        }
    }
}

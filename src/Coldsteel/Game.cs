using Coldsteel.Input;
using FarseerPhysics;
using System;

namespace Coldsteel
{
    public abstract class Game : IDisposable
    {
        protected InputManager Input { get; private set; }

        protected GameStage Stage { get; private set; }

        protected GameStateManager State { get; private set; }

        private ContentManager _content;

        private MonoGameImpl _gameImpl;

        public Game()
        {
            _gameImpl = new MonoGameImpl();
            _content = new ContentManager(_gameImpl.Content);
            Stage = new GameStage();
            Input = new InputManager();
            State = new GameStateManager(Input, _content, Stage);
            _gameImpl.State = State;
            ConvertUnits.SetDisplayUnitToSimUnitRatio(64f);
        }

        public abstract void Initialize();

        public void Dispose()
        {
            _gameImpl.Dispose();
            _gameImpl = null;
        }

        public void Run()
        {
            Initialize();
            _gameImpl.Run();
        }
    }
}

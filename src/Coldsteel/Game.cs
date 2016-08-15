using Coldsteel.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Game : IDisposable
    {
        private MonoGameImpl _gameImpl;

        public InputManager Input { get; private set; }

        public GameStateManager State { get; private set; }

        private ContentManager _contentManger;

        public Game()
        {
            _gameImpl = new MonoGameImpl();
            _contentManger = new ContentManager(_gameImpl);
            Input = new InputManager();
            State = new GameStateManager(Input, _contentManger);
        }

        public void Dispose()
        {
            _gameImpl.Dispose();
            _gameImpl = null;
        }

        public abstract void Initialize();

        public void Run()
        {
            Initialize();
            _gameImpl.Run();
        }
    }
}

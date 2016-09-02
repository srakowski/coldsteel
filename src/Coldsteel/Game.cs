using Coldsteel.Input;
using FarseerPhysics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Game : IDisposable
    {
        private MonoGameImpl _gameImpl;

        public InputManager Input { get; private set; }

        public GameStage Stage { get; private set; }

        public GameStateManager State { get; private set; }

        private ContentManager Content { get; set; }

        public Game()
        {
            _gameImpl = new MonoGameImpl();
            Content = new ContentManager(_gameImpl.Content);
            Stage = new GameStage();
            Input = new InputManager();
            State = new GameStateManager(Input, Content, Stage);
            _gameImpl.State = State;
            ConvertUnits.SetDisplayUnitToSimUnitRatio(64f);
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

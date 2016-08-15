using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class Game : IDisposable
    {
        private MonoGameImpl _gameImpl;

        public Game()
        {
            _gameImpl = new MonoGameImpl();
        }

        public void Dispose()
        {
            _gameImpl.Dispose();
        }

        public void Run()
        {
            _gameImpl.Run();
        }
    }
}

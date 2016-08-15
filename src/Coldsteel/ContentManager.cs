using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class ContentManager
    {
        private MonoGameImpl _gameImpl;

        internal ContentManager(MonoGameImpl _gameImpl)
        {
            this._gameImpl = _gameImpl;
        }

        public void Image(string name, string path = null)
        {
        }

        public void SpriteFont(string name, string path = null)
        {
        }
    }
}

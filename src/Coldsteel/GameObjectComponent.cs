using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Input;

namespace Coldsteel
{
    public class GameObjectComponent
    {
        private GameObject _gameObject;

        public GameObject GameObject
        {
            get { return _gameObject; }
            internal set
            {
                _gameObject = value;
                Initialize();
            }
        }

        public InputManager Input => GameObject?.Input;

        public Transform Transform => GameObject?.Transform;

        public IGameTime GameTime => GameObject?.GameTime;

        public World World => GameObject?.World;

        internal virtual void Initialize() { }
    }
}

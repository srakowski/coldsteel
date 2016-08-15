using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class GameObjectConfigurator
    {
        private GameObject _gameObject;

        public GameObjectConfigurator(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public GameObject Position(float x, float y)
        {
            return _gameObject;
        }

        public GameObject RotationDegrees(int degrees)
        {
            return _gameObject;
        }
    }
}

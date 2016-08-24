using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

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
            _gameObject.Transform.LocalPosition = new Vector2(x, y);
            return _gameObject;
        }

        public GameObject Position(Vector2 position)
        {
            _gameObject.Transform.LocalPosition = position;
            return _gameObject;
        }

        public GameObject RotationDegrees(int degrees)
        {
            _gameObject.Transform.Rotation = MathHelper.ToRadians(degrees);
            return _gameObject;
        }

        public GameObject Layer(string key)
        {
            _gameObject.Layer = _gameObject.Layers[key];
            return _gameObject;
        }
    }
}

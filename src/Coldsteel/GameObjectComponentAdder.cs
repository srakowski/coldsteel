using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class GameObjectComponentAdder
    {
        private GameObject _gameObject;

        public GameObjectComponentAdder(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public GameObject TextRenderer(string spriteFontKey, string text)
        {
            return _gameObject;
        }

        public GameObject SpriteRenderer(string imageKey)
        {
            return _gameObject;
        }

        public GameObject Component(GameObjectComponent component)
        {
            return _gameObject;
        }
    }
}

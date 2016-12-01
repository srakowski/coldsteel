using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class GameObjectCollection : IEnumerable<GameObject>
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        private bool _isInitialized = false;

        private Scene _scene;

        internal GameObjectCollection(Scene scene)
        {
            _scene = scene;
        }

        internal void Initialize()
        {
            _gameObjects.ForEach(go => go.Initialize());
            _isInitialized = true;
        }

        public void Add(GameObject gameObject)
        {
            gameObject.Scene = _scene;
            if (_isInitialized)
                gameObject.Initialize();

            _gameObjects.Add(gameObject);
        }

        public IEnumerator<GameObject> GetEnumerator() => 
            _gameObjects.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}

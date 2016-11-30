using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class GameObjectCollection : IEnumerable<GameObject>
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        public void Add(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        public IEnumerator<GameObject> GetEnumerator() => 
            _gameObjects.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}

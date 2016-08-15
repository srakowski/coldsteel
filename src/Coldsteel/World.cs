using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class World
    {
        private List<GameObject> _gameObjects;

        public GameObject AddGameObject()
        {
            var go = new GameObject();
            _gameObjects.Add(go);
            return go;
        }
    }
}

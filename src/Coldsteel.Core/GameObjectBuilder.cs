using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Core.Components;
using Microsoft.Xna.Framework;

namespace Coldsteel.Core
{
    public class GameObjectBuilder
    {
        private GameObject _gameObject = null;

        private GameObject _completedGameObject;

        public void Begin(string name)
        {
            _gameObject = new GameObject(name);
        }

        public void End()
        {
            _completedGameObject = _gameObject;
            _gameObject = null;
        }

        public GameObject GetResult()
        {
            var gameObject = _completedGameObject;
            _completedGameObject = null;
            return gameObject;
        }

        public void AddComponent(IComponent component) =>
            _gameObject.Add(component);
    }
}

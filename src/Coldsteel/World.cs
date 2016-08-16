using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class World
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        private GameState _gameState;

        internal World(GameState gameState)
        {
            _gameState = gameState;
        }

        public GameObject AddGameObject()
        {
            var go = new GameObject(_gameState);
            _gameObjects.Add(go);
            return go;
        }

        internal void Update(GameTime gameTime)
        {
            _gameObjects.ForEach(go => go.Update(gameTime));
        }
    }
}

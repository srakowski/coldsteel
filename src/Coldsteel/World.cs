using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Physics;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class World
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        private GameState _gameState;

        private PhysicalWorld _physicalWorld;        

        internal PhysicalWorld PhysicalWorld => _physicalWorld;

        internal World(GameState gameState)
        {
            _gameState = gameState;
            _physicalWorld = new PhysicalWorld();
        }

        public GameObject AddGameObject(params string[] tags)
        {
            var go = new GameObject(_gameState);
            PhysicalWorld.Add(go);
            go.Tags = tags;
            _gameObjects.Add(go);
            return go;
        }

        internal void RemoveGameObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
            PhysicalWorld.Remove(gameObject);            
        }

        internal void Update(GameTime gameTime)
        {
            _physicalWorld.Update(gameTime);
            var gameObjectsToUpdate = _gameObjects.ToArray();
            foreach (var go in gameObjectsToUpdate)
                go.Update(gameTime);
            foreach (var go in gameObjectsToUpdate)
                go.UpdateCoroutines(gameTime);
        }
    }
}

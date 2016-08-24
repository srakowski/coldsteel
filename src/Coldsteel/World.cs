using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Physics;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class World
    {
        public GameState GameState { get; private set; }

        private List<GameObject> _gameObjects = new List<GameObject>();

        private PhysicalWorld _physicalWorld;

        internal PhysicalWorld PhysicalWorld => _physicalWorld;

        internal World(GameState gameState)
        {
            GameState = gameState;
            _physicalWorld = new PhysicalWorld();
        }

        public GameObject AddGameObject(params string[] tags)
        {
            var go = new GameObject(this);
            go.Tags = tags;
            _gameObjects.Add(go);
            return go;
        }

        internal Camera AddCamera()
        {
            var camera = new Camera(this);
            _gameObjects.Add(camera);
            return camera;
        }

        internal void RemoveGameObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
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

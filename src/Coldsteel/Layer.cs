using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Rendering;

namespace Coldsteel
{
    public class Layer
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        internal Layer() { }

        internal void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _gameObjects.ForEach(go => go?.Renderer?.Render(gameTime, spriteBatch));
        }

        internal void AddGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        internal void RemoveGameObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }
    }
}

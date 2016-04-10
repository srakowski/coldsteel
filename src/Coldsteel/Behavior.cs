using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Behavior : GameObjectComponent
    {
        public virtual void HandleInput(IGameTime gameTime, Input input) { }

        /// <summary>
        /// Adds a GameObject to the Stage without added it to the GameObject of this Behavior
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddGameObject(GameObject gameObject)
        {
            this.GameObject.GameStage.AddGameObject(gameObject);
        }

        /// <summary>
        /// Retrieve already loaded content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T GetContent<T>(string path) where T : class
        {
            var gameStage = this.GameObject.GameStage;
            return gameStage?.GetContent<T>(path);
        }
    }
}

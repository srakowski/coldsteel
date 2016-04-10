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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    /// <summary>
    /// Represents a scene/level/screen in the game.
    /// </summary>
    public abstract class GameStage
    {
        private List<GameObject> _gameObjects = new List<GameObject>();

        /// <summary>
        /// Gets the GameObjects contained in this stage.
        /// </summary>
        public IEnumerable<GameObject> GameObjects { get { return _gameObjects; } }

        /// <summary>
        /// Adds a GameObject to the Stage
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
            gameObject.GameStage = this;
        }

        /// <summary>
        /// Called when Content should be loaded. This is called before Initialize.
        /// </summary>
        /// <param name="contentManager"></param>
        public virtual void LoadContent() { }

        /// <summary>
        /// Set the initial state of the GameStage. Create and initialize GameObjects.
        /// </summary>
        public virtual void Initialize() { }
    }
}

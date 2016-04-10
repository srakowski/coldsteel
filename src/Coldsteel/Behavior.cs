using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Behavior : GameObjectComponent
    {
        /// <summary>
        /// Get the DefaultLayer for the Stage this behavior is part of.
        /// </summary>
        public Layer DefaultLayer
        {
            get
            {
                var gameStage = this.GameObject.GameStage;
                return gameStage.DefaultLayer;
            }
        }

        /// <summary>
        /// Override to handle input.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="input"></param>
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

        private List<Coroutine> _coroutines = new List<Coroutine>();
                
        /// <summary>
        /// Coroutine support with args
        /// </summary>
        /// <param name="fire"></param>
        protected void StartCoroutine(IEnumerator coroutine)
        {
            _coroutines.Add(new Coroutine(coroutine).WhenDone((c) => _coroutines.Remove(c)));
        }

        /// <summary>
        /// Update any coroutines.
        /// </summary>
        internal void UpdateCoroutines(IGameTime gameTime)
        {
            if (_coroutines.Count == 0)
                return;

            var coroutinesToUpdate = _coroutines.ToArray();
            foreach (var coroutine in coroutinesToUpdate)
                coroutine.Update(gameTime);
        }

        /// <summary>
        /// Use with Coroutine to instruct the coroutine to wait at least a 
        /// given amount of milleseconds before the next entry.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        protected object WaitMSecs(int amount)
        {
            return CoroutineWait.WaitMilleseconds(amount);
        }
    }
}

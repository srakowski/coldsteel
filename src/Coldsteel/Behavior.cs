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
                return this.GameObject.DefaultLayer;
            }
        }

        /// <summary>
        /// Override to handle collisions with other GameObjects
        /// </summary>
        public virtual void OnCollision(Collision collision) { }

        /// <summary>
        /// Gets or sets the input provided to this Behavior for updates.
        /// </summary>
        public Input Input { get { return this.GameObject.Input; } }

        /// <summary>
        /// Gets the GameStageManager
        /// </summary>
        public GameStageManager GameStageManager { get { return GameObject.GameStage.GameStageManager; } }

        /// <summary>
        /// Adds a GameObject to the Stage without added it to the GameObject of this Behavior
        /// </summary>
        /// <param name="gameObject"></param>
        public GameObject AddGameObject(GameObject gameObject = null)
        {
            return this.GameObject.GameStage.AddGameObject(gameObject);
        }
        
        /// <summary>
        /// Auto add a game object with given tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public GameObject AddGameObject(string tag)
        {
            var go = AddGameObject();
            go.Tag = tag;
            return go;
        }

        /// <summary>
        /// Retrieve already loaded content.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T GetContent<T>(string path) where T : class
        {            
            return this.GameObject.GetContent<T>(path);
        }

        /// <summary>
        /// Gets a layer from the stage.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Layer GetLayer(string key)
        {
            return this.GameObject.GameStage.GetLayer(key);
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

        /// <summary>
        /// Completely removes the GameObject this Behavior belongs to from the Stage, including all Children.
        /// </summary>
        protected void Destroy()
        {
            this.GameObject.Destroy();
        }

        /// <summary>
        /// Gets a component of the given type from the GameObject.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="T"></param>
        /// <param name=""></param>
        /// <returns></returns>
        protected T GetComponent<T>() where T : GameObjectComponent
        {
            return this.GameObject.GetComponent<T>();
        }
    }
}

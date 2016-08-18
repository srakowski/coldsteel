using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Coldsteel.Rendering;

namespace Coldsteel
{
    public abstract class Behavior : GameObjectComponent
    {
        public World World => GameObject?.World;

        public Renderer Renderer => GameObject?.Renderer;

        public ContentManager Content => GameObject?.Content;

        public GameObject AddGameObject(params string[] tags) => GameObject.AddGameObject(tags);

        public virtual void Update() { }

        private List<Coroutine> _coroutines = new List<Coroutine>();

        /// <summary>
        /// Start a coroutine.
        /// </summary>
        /// <param name="coroutine"></param>
        public void StartCoroutine(IEnumerator coroutine)
        {
            _coroutines.Add(new Coroutine(coroutine).WhenDone((c) => _coroutines.Remove(c)));
        }

        /// <summary>
        /// Use within a Coroutine to instruct the coroutine to wait at least a 
        /// given amount of milleseconds before the next entry.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        protected object WaitMSecs(int amount)
        {
            return CoroutineWait.WaitMilleseconds(amount);
        }

        /// <summary>
        /// Update any coroutines.
        /// </summary>
        internal void UpdateCoroutines()
        {
            if (_coroutines.Count == 0)
                return;

            var coroutinesToUpdate = _coroutines.ToArray();
            foreach (var coroutine in coroutinesToUpdate)
                coroutine.Update(GameTime);
        }

        public virtual void OnCollision(GameObject with) { }

        public void Kill() => GameObject.Kill();
    }
}

using Coldsteel.Core.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core.Components
{
    public abstract class Behavior : Component
    {
        private List<Coroutine> _pendingCoroutines = new List<Coroutine>();

        private List<Coroutine> _coroutines = new List<Coroutine>();

        protected Transform Transform => GameObject?.Transform;

        protected ControlsManager Controls => GameObject?.Scene?.Controls;

        public GameTime GameTime { get; internal set; }

        public float Delta => (float)(GameTime?.ElapsedGameTime.TotalMilliseconds ?? 0f);

        public virtual void Update() { }

        public Coroutine StartCoroutine(string name, params object[] parameters)
        {
            var method = this.GetType().GetMethod(name);
            return StartCoroutine(method.Invoke(this, parameters) as IEnumerator);
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            var coroutine = new Coroutine(routine);
            _pendingCoroutines.Add(coroutine);
            return coroutine;
        }

        internal void UpdateCoroutines()
        {
            _coroutines.RemoveAll(c => c.IsComplete);
            _coroutines.AddRange(_pendingCoroutines);
            _pendingCoroutines.Clear();
            _coroutines.ForEach(c => c.Update(this.GameTime));
        }
    }
}

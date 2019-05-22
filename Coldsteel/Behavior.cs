// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Coldsteel
{
    public abstract class Behavior : Component
    {
        private List<Coroutine> _pendingCoroutines = new List<Coroutine>();

        private List<Coroutine> _coroutines = new List<Coroutine>();

        protected GameTime GameTime;

        protected float Delta;

        protected internal override void Activated()
        {
            Initialize();
        }

        internal void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            Delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Update();
        }

        protected virtual void Initialize() { }

        protected virtual void Update() { }

        protected Coroutine StartCoroutine(IEnumerator routine)
        {
            var coroutine = new Coroutine(routine);
            _pendingCoroutines.Add(coroutine);
            return coroutine;
        }

        protected YieldInstruction Wait(int millesecondsToWait) =>
            new YieldInstruction(millesecondsToWait);

        internal void UpdateCoroutines(GameTime gameTime)
        {
            _coroutines.RemoveAll(c => c.IsFinished);
            _coroutines.AddRange(_pendingCoroutines);
            _pendingCoroutines.Clear();
            _coroutines.ForEach(c => c.Update(gameTime));
        }
    }
}

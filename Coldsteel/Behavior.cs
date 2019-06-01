// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Controls;
using Microsoft.Xna.Framework;
using System;
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

        private protected override void Activated()
        {
            Engine.BehaviorSystem.AddBehavior(Scene, this);
            Initialize();
        }

        private protected override void Deactivated()
        {
            Engine.BehaviorSystem.RemoveBehavior(Scene, this);
        }

        internal void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            Delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Update();
        }

        protected virtual void Initialize() { }

        internal protected virtual void HandleCollision(Collision collision) { }

        protected virtual void Update() { }

        protected TControl GetControl<TControl>(string name) where TControl : Control
        {
            if (!Engine.Config.Controls.ContainsKey(name))
                throw new System.Exception($"control not defined: {name}");

            return Engine.Config.Controls[name] as TControl;
        }

        protected Coroutine StartCoroutine(IEnumerator routine)
        {
            var coroutine = new Coroutine(routine);
            _pendingCoroutines.Add(coroutine);
            return coroutine;
        }

        internal void UpdateCoroutines(GameTime gameTime)
        {
            _coroutines.RemoveAll(c => c.IsFinished);
            _coroutines.AddRange(_pendingCoroutines);
            _pendingCoroutines.Clear();
            _coroutines.ForEach(c => c.Update(gameTime));
        }
    }
}

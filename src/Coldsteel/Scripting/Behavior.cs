// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Coldsteel.Physics;

namespace Coldsteel.Scripting
{
    /// <summary>
    /// Developer defined Entity behavior. This is the primary
    /// mechanism for a developer to add functionality to the game.
    /// </summary>
    public abstract class Behavior : Component
    {
        private List<Coroutine> _pendingCoroutines = new List<Coroutine>();

        private List<Coroutine> _coroutines = new List<Coroutine>();

        /// <summary>
        /// The current GameTime.
        /// </summary>
        public GameTime GameTime { get; internal set; }

        /// <summary>
        /// The time, in milleseconds, since the last update.
        /// </summary>
        public float Delta => (float)(GameTime?.ElapsedGameTime.TotalMilliseconds ?? 0f);

        /// <summary>
        /// The Transform of the Entity.
        /// </summary>
        public new Transform Transform => base.Transform;

        /// <summary>
        /// The SceneManager object.
        /// </summary>
        public ISceneManager SceneManager { get; internal set; }

        /// <summary>
        /// The InputManager object.
        /// </summary>
        public IInputManager Input { get; internal set; }

        /// <summary>
        /// Content manager used to dynamically load or retrieve content.
        /// </summary>
        public ContentManager Content { get; private set; }

        /// <summary>
        /// The active scene the Entity is part of.
        /// </summary>
        public Scene Scene { get; private set; }

        /// <summary>
        /// Override to perform any initialization logic before entering
        /// the normal update cycle.
        /// </summary>
        public virtual void Activate() { }

        /// <summary>
        /// Override to respond to Collisions with other Entities.
        /// </summary>
        /// <param name="collision"></param>
        public virtual void OnCollision(Collision collision) { }

        /// <summary>
        /// Override to perform any updates to the Entity during
        /// scene execution.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Starts a coroutine of a given name with the provided parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Coroutine StartCoroutine(string name, params object[] parameters)
        {
            var method = this.GetType().GetMethod(name);
            return StartCoroutine(method.Invoke(this, parameters) as IEnumerator);
        }

        /// <summary>
        /// Starts a coroutine whose invocation has been triggered by the user.
        /// </summary>
        /// <param name="routine"></param>
        /// <returns></returns>
        public Coroutine StartCoroutine(IEnumerator routine)
        {
            var coroutine = new Coroutine(routine);
            _pendingCoroutines.Add(coroutine);
            return coroutine;
        }

        /// <summary>
        /// Destroyes the provided Entity, marking it for removal from
        /// the scene after the current frame has rendered.
        /// </summary>
        /// <param name="entity"></param>
        public void Destroy(Entity entity)
        {
            entity.Destroy();
        }

        public void Destroy(Component component)
        {
            component.Entity.RemoveComponent(component);
        }

        internal override void Activate(Context context)
        {
            this.Scene = context.Scene;
            this.SceneManager = context.SceneManager;
            this.Input = context.Input;
            this.Content = context.Content;
            Activate();
        }

        internal override void HandleMessage(object message)
        {
            if (message is Collision)
                OnCollision(message as Collision);
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

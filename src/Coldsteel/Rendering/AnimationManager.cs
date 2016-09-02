using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Rendering
{
    public class AnimationManager
    {
        internal int CurrentFrame { get { return _currentAnimation?.CurrentFrame ?? 0;  } }

        private Dictionary<string, AnimationState> _animations = new Dictionary<string, AnimationState>();

        private AnimationState _currentAnimation = null;

        public void Play(string key)
        {
            var animation = _animations[key];
            if (animation == _currentAnimation)
                return;

            _currentAnimation = _animations[key];
            _currentAnimation.Reset();
        }

        internal void Update(IGameTime gameTime)
        {
            _currentAnimation?.Update(gameTime);
        }

        public void Add(string key, int frame)
        {
            _animations[key] = new AnimationState(frame);
        }

        public void Add(string key, int[] frames, int rate)
        {
            _animations[key] = new AnimationState(frames, rate);
        }
    }
}

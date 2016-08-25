using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Rendering
{
    public class AnimationManager
    {
        internal int CurrentFrame { get { return _currentAnimation?.Frames[_currentAnimation.CurrentFrameIndex] ?? 0;  } }

        private Dictionary<string, AnimationState> _animations = new Dictionary<string, AnimationState>();

        private AnimationState _currentAnimation = null;

        public void Play(string key)
        {
            _currentAnimation = _animations[key];
            _currentAnimation.Reset();
        }

        public void Add(string key, int[] frames, int rate)
        {
            _animations[key] = new AnimationState(frames, rate);
        }

        internal void Update(IGameTime gameTime)
        {
            if (_currentAnimation == null)
                return;

            _currentAnimation.TimeToNextFrame -= gameTime.Delta;
            if (_currentAnimation.TimeToNextFrame <= 0)
                _currentAnimation.NextFrame();
        }
    }
}

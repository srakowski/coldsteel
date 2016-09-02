using System.Linq;

namespace Coldsteel.Rendering
{
    internal class AnimationState
    {
        public bool IsStatic { get; private set; }

        public int CurrentFrame { get; private set; }

        private int[] _frames;

        private int _rate;

        private double _timeToNextFrame;

        private int _frameIdx;

        public AnimationState(int frame)
        {
            this.IsStatic = true;
            this.CurrentFrame = frame;
        }

        public AnimationState(int[] frames, int rate)
        {
            this.IsStatic = false;
            this.CurrentFrame = frames.First();
                        
            _frames = frames;
            _rate = rate;
            Reset();
        }

        internal void Update(IGameTime gameTime)
        {
            if (this.IsStatic)
                return;

            this._timeToNextFrame -= gameTime.Delta;
            if (this._timeToNextFrame <= 0)
                this.NextFrame();
        }

        internal void NextFrame()
        {
            if (this.IsStatic)
                return;

            this._frameIdx++;
            if (this._frameIdx >= _frames.Length)
                this._frameIdx = 0;

            CurrentFrame = _frames[_frameIdx];
            _timeToNextFrame = _rate;
        }

        internal void Reset()
        {
            if (this.IsStatic)
                return;

            _timeToNextFrame = _rate;
            _frameIdx = 0;
            CurrentFrame = _frames[_frameIdx];
        }
    }
}

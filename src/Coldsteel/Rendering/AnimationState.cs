using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Rendering
{
    internal class AnimationState
    {
        public int[] Frames { get; set; }

        public int Rate { get; set; }

        public double TimeToNextFrame { get; set; }

        public int CurrentFrameIndex { get; set; }

        public AnimationState(int[] frames, int rate)
        {
            Frames = frames;
            Rate = rate;
            Reset();
        }

        internal void NextFrame()
        {
            this.CurrentFrameIndex++;
            if (this.CurrentFrameIndex >= Frames.Length)
                this.CurrentFrameIndex = 0;
            TimeToNextFrame = Rate;
        }

        internal void Reset()
        {
            TimeToNextFrame = Rate;
            CurrentFrameIndex = 0;
        }
    }
}

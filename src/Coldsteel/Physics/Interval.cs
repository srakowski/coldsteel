// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;

namespace Coldsteel.Physics
{
    internal struct Interval
    {
        public float Min;
        public float Max;

        public Interval(float initial)
        {
            Min = initial;
            Max = initial;
        }

        internal static float Distance(Interval i1, Interval i2) =>
            i1.Min < i2.Min
                ? i2.Min - i1.Max
                : i1.Min - i2.Max;
    }
}

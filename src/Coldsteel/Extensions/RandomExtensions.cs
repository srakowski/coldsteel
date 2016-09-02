using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Extensions
{
    public static class RandomExtensions
    {
        public static float NextFloat(this Random rand)
        {
            return (float)rand.NextDouble();
        }
    }
}

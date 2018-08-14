// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    internal static class Extensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> self, T value) => self.Concat(new[] { value });

    }
}
